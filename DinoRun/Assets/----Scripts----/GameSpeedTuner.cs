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
    public UnityEvent<float> OnUpdateGameProgress01;
    public UnityEvent<float> OnUpdateGameSpeed;

    [SerializeField] private AnimationCurve _gameSpeedCurve;
    [SerializeField] private float _tuneGameSpeedDuration = 60f;

    private (float InStart, float InEnd) _speed;


    private void Start()
    {
        _speed = (_gameSpeedCurve.GetFirstKey().value, _gameSpeedCurve.GetLastKey().value);
        Time.timeScale = 1f;

        OnUpdateGameProgress.AddListener((float value) => OnUpdateGameProgress01.Invoke(Mathf.InverseLerp(_speed.InStart, _speed.InEnd, value)));
        OnUpdateGameProgress01.AddListener((float value) => OnUpdateGameSpeed?.Invoke(_gameSpeedCurve.Evaluate(value)));

        DOTween.To(() => _speed.InStart, x => OnUpdateGameProgress.Invoke(x), _speed.InEnd, _tuneGameSpeedDuration).SetEase(Ease.Linear);
    }
}
