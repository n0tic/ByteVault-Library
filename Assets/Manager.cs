using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bytevaultstudio.Utils;
using Bytevaultstudio.Network;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;

    void Awake() => nUtils.CreateSingleton<Manager>(ref instance, this, this.gameObject);
}