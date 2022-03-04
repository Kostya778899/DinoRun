using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using CMath;

public class GameSpeedTuner : MonoBehaviour
{
    public UnityEvent<float> OnUpdateGameProgress;
    public UnityEvent<float> OnUpdateGameSpeed;
    public float Progress = 0f;

    [SerializeField] private AnimationCurve _gameSpeedCurve;
    [SerializeField] private float _tuneGameSpeedDuration = 60f;

    private (float InStart, float InEnd) _speed;


    private void Start()
    {
        _speed = (_gameSpeedCurve.GetFirstKey().value, _gameSpeedCurve.GetLastKey().value);

        OnUpdateGameProgress.AddListener((float value) => OnUpdateGameProgress?.Invoke(Mathf.InverseLerp(_speed.InStart, _speed.InEnd, value)));
        DOTween.To(() => _speed.InStart, x => OnUpdateGameProgress.Invoke(x), _speed.InEnd, _tuneGameSpeedDuration).SetEase(Ease.Linear);
    }
}
