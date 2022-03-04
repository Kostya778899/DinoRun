using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticlesSpeedByTuner : SetParticlesSpeed
{
    [SerializeField] private GameSpeedTuner _tuner;
    [SerializeField] private float _speedRatio = 1f;


    protected override void Awake()
    {
        base.Awake();
        _tuner.OnUpdateGameSpeed.AddListener((float value) => SetSpeed(value * _speedRatio));
    }
}
