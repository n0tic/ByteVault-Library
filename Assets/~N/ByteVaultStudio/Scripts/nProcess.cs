using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace Bytevaultstudio.nProcess
{
    public class nProcess
    {
        public static Process process = null;
        //public static StreamWriter messageStream;

        /// <summary>
        /// StartProcess will start a process outside the game with the help of a path and arguments.
        /// </summary>
        /// <param name="fullFilePath"></param>
        /// <param name="arguments"></param>
        public static void StartProcess(string fullFilePath, List<string> arguments)
        {
            try
            {
                process = new Process();
                process.EnableRaisingEvents = false;
                process.StartInfo.FileName = fullFilePath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = false;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardError = false;
                process.StartInfo.Arguments = "";

                foreach(string str in arguments)
                {
                    process.StartInfo.Arguments += "\"" + str + "\"  ";
                }

                //process.OutputDataReceived += new DataReceivedEventHandler(DataReceived);
                //process.ErrorDataReceived += new DataReceivedEventHandler(ErrorReceived);

                if(process.Start())
                    UnityEngine.Debug.Log("Successfully launched app");
                else
                    UnityEngine.Debug.LogError("Start failed.");

                //process.BeginOutputReadLine();
                //messageStream = process.StandardInput;


            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Unable to launch app: " + e.Message);
            }
        }


        static void DataReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            // Handle it
        }


        static void ErrorReceived(object sender, DataReceivedEventArgs eventArgs)
        {
            UnityEngine.Debug.LogError(eventArgs.Data);
        }


        static void OnApplicationQuit()
        {
            if (process != null && !process.HasExited) process.Kill();
        }
    }
}