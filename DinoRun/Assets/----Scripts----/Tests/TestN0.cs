using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMath;

public class TestN0 : MonoBehaviour
{



    private void Start()
    {
        Invoke("ABD", 1f);
        this.Invoke(() => ABD("1"), 1f);
        
    }

    private void ABD() => Debug.Log("0");
    private void ABD(in string value) => Debug.Log(value);
}
