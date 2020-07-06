using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Bytevaultstudio.Utils;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;
using System.Threading;
using System.Diagnostics;

namespace Bytevaultstudio.Network
{
    public static class nNetwork
    {
        public static WebClient wc = null;
        public static bool processOngoing = false;
        public static string fullPath = "";
        public static int currentPercent = 0;
        public static long currentBytes = 0;
        public static long currentMaxBytes = 0;
        public static string stringData = "";

        public static Action cancelMethod = null;
        public static Action errorMethod = null;
        public static Action completeMethod = null;
        public static Action<string> completeMethodStr = null;

        /// <summary>
        /// Check if internet connection could be made to google.com
        /// </summary>
        /// <returns>boolean</returns>
        public static bool IsInternetConnectionAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com/")) return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Check if url is valid.
        /// </summary>
        /// <param name="url">string</param>
        /// <returns>boolean</returns>
        public static bool IsValidURL(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        static void resetMethods()
        {
            cancelMethod = null;
            errorMethod = null;
            completeMethod = null;
            completeMethodStr = null;
        }

         /*
            <?php
                date_default_timezone_set(‘Europe/Stockholm’);
                echo date(“d-m-Y H:i:s”);;
            ?>
         */
         /// <summary>
         /// Get the current server Date and Time from php.
         /// </summary>
         /// <param name="url">string</param>
         /// <param name="_cancelMethod">Action</param>
         /// <param name="_completeMethod">Action string</param>
         /// <param name="_errorMethod">Action</param>
        public static void GetServerDateTime(string url, Action _cancelMethod, Action<string> _completeMethod, Action _errorMethod)
        {
            if (wc != null)
                return;

            processOngoing = true;
            stringData = "";
            currentPercent = 0;

            resetMethods();

            cancelMethod = _cancelMethod;
            errorMethod = _errorMethod;
            completeMethodStr = _completeMethod;

            using (wc = new WebClient())
            {
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                wc.Headers.Add("Cache-Control", "no-cache");

                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;

                wc.DownloadStringAsync(new Uri(url));
            }
        }

        static void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                processOngoing = false;

                cancelMethod?.Invoke();

                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                processOngoing = false;

                errorMethod?.Invoke();

                return;
            }

            processOngoing = false;
            UnityEngine.Debug.Log("Download completed!");

            if(completeMethodStr != null)
                completeMethodStr(e.Result);
        }

        /// <summary>
        /// Start the download of a file async
        /// </summary>
        /// <param name="savePath">Path where file should be saved.</param>
        /// <param name="downloadURL">The path of the file to download</param>
        /// <param name="saveFileName">Name of the downloaded file</param>
        /// <param name="_canceledMethod">Method to call when download is canceled</param>
        /// <param name="_errorMethod">Method to call when download recieves error</param>
        /// <param name="_completeMethod">Method to call when download is complete</param>
        public static void StartDownloadFileAsync(string savePath, string downloadURL, string saveFileName, Action _canceledMethod, Action _errorMethod, Action _completeMethod)
        {
            processOngoing = true;
            currentPercent = 0;

            cancelMethod = _canceledMethod;
            errorMethod = _errorMethod;
            completeMethod = _completeMethod;

            if (savePath == "")
            {
                savePath = nUtils.GetCurrentPath() + "\\Downloads";
                #if UNITY_EDITOR
                    savePath = "C:\\Downloads";
                #endif
            }

            fullPath = savePath + "\\" + saveFileName;

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            using (wc = new WebClient())
            {
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                wc.Headers.Add("Cache-Control", "no-cache");

                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                wc.DownloadFileAsync(new Uri(downloadURL), savePath + "\\" + saveFileName);
            }
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            currentPercent = e.ProgressPercentage;
            currentBytes = e.BytesReceived;
            currentMaxBytes = e.TotalBytesToReceive;
        }

        static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                if(File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                processOngoing = false;

                cancelMethod?.Invoke();

                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                UnityEngine.Debug.Log("An error ocurred while trying to download file. " + e.Error.Message);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                processOngoing = false;

                errorMethod?.Invoke();

                return;
            }

            processOngoing = false;
            UnityEngine.Debug.Log("Download completed!");

            completeMethod?.Invoke();
        }

        /// <summary>
        /// StartCourutine : Upload PNG to a url
        /// </summary>
        /// <param name="url">PHP upload script or reciever</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator UploadPNG(string url)
        {
            // We should only read the screen after all rendering is complete
            yield return new WaitForEndOfFrame();

            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = Screen.height;
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();

            // Encode texture into PNG
            byte[] bytes = tex.EncodeToPNG();
            UnityEngine.Object.Destroy(tex);

            // Create a Web Form
            WWWForm form = new WWWForm();
            form.AddField("frameCount", Time.frameCount.ToString());
            form.AddBinaryData("fileUpload", bytes, "screenShot.png", "image/png");

            // Upload to a cgi script
            using (var w = UnityWebRequest.Post(url, form))
            {
                yield return w.SendWebRequest();
                if (w.isNetworkError || w.isHttpError)
                {
                    UnityEngine.Debug.LogError(w.error);
                }
                else
                {
                    UnityEngine.Debug.Log("Finished Uploading Screenshot");
                }
            }
        }

        /// <summary>
        /// StartCourutine : Get newest version information from url
        /// </summary>
        /// <param name="failMethod">Method to run if error</param>
        /// <param name="successMethod">Method to run if sucess</param>
        /// <param name="url">API url</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator GetVersionInformation(Action<string> failMethod, Action<string> successMethod, string url = "http://bytevaultstudio.se/updates/Serenity/")
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                UnityEngine.Debug.Log(www.downloadHandler.text);
                string[] data = www.downloadHandler.text.Split('>');

                foreach (string s in data)
                {
                    UnityEngine.Debug.Log(s);
                }
            }
        }


        /// <summary>
        /// Download data using IEnumerator.
        /// </summary>
        /// <param name="successMethod">Method to run if success</param>
        /// <param name="failMethod">Method to run if fail</param>
        /// <param name="url">Download URL</param>
        /// <returns></returns>
        public static IEnumerator DownloadData(Action<string> successMethod, Action<string> failMethod, string url)
        {
            // Create a download object
            var download = UnityWebRequest.Get(url);

            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError)
            {
                failMethod("Error downloading: " + download.error);
            }
            else
            {
                successMethod(download.downloadHandler.text);
            }
        }
    }
}
