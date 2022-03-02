using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private UnityEvent _onKill;
    [SerializeField] private AnimationCurve _setTimeScaleCurve;
    [SerializeField] private float _setTimeScaleDuration = 1.5f;


    public void Kill()
    {
        _onKill?.Invoke();
        DOTween.To(() => 1f, x => Time.timeScale = x, 0f, _setTimeScaleDuration).SetEase(_setTimeScaleCurve).SetUpdate(true);
    }
}
