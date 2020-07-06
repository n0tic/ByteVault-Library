using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bytevaultstudio.Ints
{
    public class nInt
    {
        public static int GetRandomInt(int length)
        {
            System.Random random = new System.Random();
            const string chars = "0123456789";
            return Int32.Parse(new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()));
        }
    }
}
