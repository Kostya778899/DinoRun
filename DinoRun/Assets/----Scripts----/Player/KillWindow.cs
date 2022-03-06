using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMath;
using UnityEngine.Events;

public class KillWindow : MonoBehaviour, IIncluded
{
    [SerializeField] private GameObject _graphics;
    [SerializeField] private UnityEvent _onActivate;


    public void Activate()
    {
        SetActive(true);
        _onActivate?.Invoke();
    }
    public void DeActivate()
    {
        SetActive(false);
    }
    private void SetActive(bool isActive)
    {
        _graphics.SetActive(isActive);
    }

    private void Start() => DeActivate();
}
