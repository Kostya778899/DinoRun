using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMath;

public class TestN0 : MonoBehaviour
{



    private void Start()
    {
        List<int> a = new List<int>() { 5, 10, 25, 77, 9, 1 };
        var b = CArray.Copy<int>(a);
        a[0] = 999;
        a[1] = 11;
        a[5] = -3;
        a = null;
        foreach (var item in b)
        {
            Debug.Log(item);
        }
    }
}
