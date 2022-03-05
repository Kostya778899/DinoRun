using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMath;

public class KillWindow : MonoBehaviour, IIncluded
{
    [SerializeField] private GameObject _graphics;


    public void Activate()
    {
        SetActive(true);
    }
    public void DeActivate()
    {
        SetActive(false);
    }
    public void SetActive(bool isActive)
    {
        _graphics.SetActive(isActive);
    }

    private void Start() => DeActivate();
}
