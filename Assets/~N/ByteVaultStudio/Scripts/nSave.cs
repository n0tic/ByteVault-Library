using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Bytevaultstudio.Save
{
    public class nSave
    {
        /*
         * I have not yet tested these methods. They may contain bugs. Testing soon.
        */

        #region BinaryFormatter Save
        public static bool DoesSaveExist(int? saveID)
        {
            string filename;

            if (saveID != null)
                filename = "data" + saveID + ".dat";
            else
                filename = "data.dat";

            return File.Exists(filename) ? true : false;
        }

        public static bool SaveDataToFile(object data, int? saveID)
        {
            FileStream fs;
            bool returnState;

            if (saveID != null)
                fs = new FileStream("data" + saveID + ".dat", FileMode.Create);
            else
                fs = new FileStream("data.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, data);
                returnState = true;
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
                returnState = false;
            }

            fs.Close();
            return returnState;
        }

        public static object LoadFromFile<T>(int? saveID)
        {
            object _data;
            string filename;

            if (saveID != null)
                filename = "data" + saveID + ".dat";
            else
                filename = "data.dat";

            if (File.Exists(filename))
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    var bformatter = new BinaryFormatter();
                    try
                    {
                        _data = (object)bformatter.Deserialize(stream);
                        stream.Close();
                        return (T)_data;
                    }
                    catch (System.Runtime.Serialization.SerializationException e)
                    {
                        stream.Close();
                        File.Delete(filename);
                        return null;
                    }
                }
            }
            else { return null; }
        }
        #endregion BinaryFormatter Save

        #region PlayerPrefs Save  // Credits Comp3Interactive
        public static void SetString(string key, string val) => PlayerPrefs.SetString(key, val);

        public static string GetString(string key) => PlayerPrefs.GetString(key);

        public static void SetInt(string key, int val) => PlayerPrefs.SetInt(key, val);

        public static int GetInt(string key) => PlayerPrefs.GetInt(key);

        public static void SetBool(string key, bool val) => PlayerPrefs.SetInt(key, val == false ? 0 : 1);

        public static bool GetBool(string key) { return PlayerPrefs.GetInt(key) == 0 ? false : true; }

        public static void SetVector3(string key, Vector3 v3) => PlayerPrefs.SetString(key, DelimitFloats(new float[] { v3.x, v3.y, v3.z }));

        public static Vector3 GetVector3(string key)
        {
            Vector3 v3 = new Vector3(0, 0, 0);

            if (PlayerPrefs.HasKey(key))
            {
                float[] f = ParseDelimitedFloats(PlayerPrefs.GetString(key));

                v3.x = f[0];
                v3.y = f[1];
                v3.z = f[2];
            }

            return v3;
        }

        public static void SetVector2(string key, Vector2 v2) => PlayerPrefs.SetString(key, DelimitFloats(new float[] { v2.x, v2.y }));

        public static Vector2 GetVector2(string key)
        {
            Vector2 v2 = new Vector3(0, 0, 0);

            if (PlayerPrefs.HasKey(key))
            {
                float[] f = ParseDelimitedFloats(PlayerPrefs.GetString(key));

                v2.x = f[0];
                v2.y = f[1];
            }

            return v2;
        }

        public static void SetQuaternion(string key, Quaternion q) => PlayerPrefs.SetString(key, DelimitFloats(new float[] { q.x, q.y, q.z, q.w }));

        public static Quaternion GetQuaternion(string key)
        {
            Quaternion q = new Quaternion(0, 0, 0, 0);

            if (PlayerPrefs.HasKey(key))
            {
                float[] f = ParseDelimitedFloats(PlayerPrefs.GetString(key));

                q.x = f[0];
                q.y = f[1];
                q.z = f[2];
                q.w = f[3];
            }

            return q;
        }
        #endregion PlayerPrefs Save

        #region Interal Utility Methods
        private static string DelimitFloats(float[] floats)
        {
            string s = "";

            foreach (float f in floats)
                s += f.ToString() + "-";

            return s.Substring(0, s.Length - 1);
        }

        private static float[] ParseDelimitedFloats(string key)
        {
            var floatList = new List<float>();

            foreach (string s in key.Split('-'))
                floatList.Add(float.Parse(s));

            return floatList.ToArray();
        }
        #endregion
    }
}