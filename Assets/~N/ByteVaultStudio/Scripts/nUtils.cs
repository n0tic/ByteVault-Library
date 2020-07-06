using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Bytevaultstudio.Utils
{
    public class nUtils
    {
        /// <summary>
        /// Creates a singleton from the class provided.
        /// </summary>
        /// <typeparam name="T">Type {CLASS}</typeparam>
        /// <param name="instance">Public static {CLASS} variable</param>
        /// <param name="_this">Current session; "this"</param>
        /// <param name="obj">Monobehaviour : this.gameObject</param>
        public static void CreateSingleton<T>(ref T instance, T _this, GameObject obj)
        {
            if (instance == null) instance = _this; // If there is no instance, set it to current instance.
            if (!EqualityComparer<T>.Default.Equals(instance, _this)) MonoBehaviour.Destroy(obj); // If this instance is a new instance, destroy object.

            MonoBehaviour.DontDestroyOnLoad(obj); // If this instance was not destroyed it should persist.
        }

        /// <summary>
        /// Check if the mouseclick find a object with tag
        /// </summary>
        /// <param name="tag">String tag of object</param>
        /// <returns>Boolean</returns>
        public static bool RayCastMouseClickYieldHit (string tag)
        {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity);
            if (Input.GetKeyDown(KeyCode.Mouse0) && hit && hitInfo.collider.gameObject.tag == tag)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check if the mouseclick find a object with tag
        /// </summary>
        /// <param name="tag">String tag of object</param>
        /// <returns>Hit GameObject</returns>
        public static GameObject RayCastMouseClickGetObject(string tag)
        {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity);
            if (Input.GetKeyDown(KeyCode.Mouse0) && hit && hitInfo.collider.gameObject.tag == tag)
                return hitInfo.collider.gameObject;
            else
                return null;
        }

        /// <summary>
        /// Freelook behaviour for cameras.
        /// </summary>
        /// <param name="rotateSpeed">float</param>
        public static void FreelookCamera(float rotateSpeed = 5f) => Camera.main.transform.rotation = Quaternion.Euler(Input.GetAxis("Mouse Y") * rotateSpeed + Camera.main.transform.rotation.eulerAngles.x, -Input.GetAxis("Mouse X") * rotateSpeed + Camera.main.transform.rotation.eulerAngles.y, 0);

        /// <summary>
        /// Get the root path of the game.
        /// </summary>
        /// <returns>String root path</returns>
        public static string GetCurrentPath() => @AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Parse a float, return default if failed
        /// </summary>
        /// <param name="txt">string</param>
        /// <param name="_default">float</param>
        /// <returns>float</returns>
        public static float Parse_Float(string txt, float _default)
		{
			float f;
			if (!float.TryParse(txt, out f))
			{
				f = _default;
			}
			return f;
		}

        /// <summary>
        /// Parse a int, return default if failed
        /// </summary>
        /// <param name="txt">string</param>
        /// <param name="_default">float</param>
        /// <returns>float</returns>
        public static int Parse_Int(string txt, int _default)
		{
			int i;
			if (!int.TryParse(txt, out i))
			{
				i = _default;
			}
			return i;
		}

        /// <summary>
        /// Get Mouse Position in World with Z = 0f
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
        {
            return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        /// <summary>
        /// Check if pointer is over UI element.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool IsPointerOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }
            else
            {
                PointerEventData pe = new PointerEventData(EventSystem.current);
                pe.position = Input.mousePosition;
                List<RaycastResult> hits = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pe, hits);
                return hits.Count > 0;
            }
        }

        /// <summary>
        /// Get random bool value
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool GetRandomBool()
        {
            return UnityEngine.Random.Range(0, 2) == 0;
        }

        /// <summary>
        /// StartCourutine : Waits for X seconds and runs a method.
        /// </summary>
        /// <param name="time">float</param>
        /// <param name="method">Action</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator WaitForSeconds(float time, Action method)
        {
            Debug.Log("Waiting..");
            yield return new WaitForSeconds(time);
            Debug.Log("Running..");
            method();
        }
        /// <summary>
        /// StartCourutine : Waits for X seconds and runs a method with string parameter.
        /// </summary>
        /// <param name="time">float</param>
        /// <param name="method">Action string</param>
        /// <param name="methodString">string</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator WaitForSeconds(float time, Action<string> method, string methodString)
        {
            Debug.Log("Waiting..");
            yield return new WaitForSeconds(time);
            Debug.Log("Running..");
            method(methodString);
        }
        /// <summary>
        /// StartCourutine : Waits for X seconds and runs a method with int parameter.
        /// </summary>
        /// <param name="time">float</param>
        /// <param name="method">Action int</param>
        /// <param name="methodInt">int</param>
        /// <returns>IEnumerator</returns>
        public static IEnumerator WaitForSeconds(float time, Action<int> method, int methodInt)
        {
            Debug.Log("Waiting..");
            yield return new WaitForSeconds(time);
            Debug.Log("Running..");
            method(methodInt);
        }

        /// <summary>
        /// Get current time in UTC used for "tricking" website to get no-cached information.
        /// </summary>
        /// <returns>string</returns>
        public static string getUTCTime()
        {
            System.Int32 unixTimestamp = (System.Int32)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp.ToString();
        }
    }
}

