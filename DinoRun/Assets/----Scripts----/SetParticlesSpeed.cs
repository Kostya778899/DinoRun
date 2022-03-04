using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SetParticlesSpeed : MonoBehaviour
{
    private ParticleSystem.MainModule _particles;


    public void SetSpeed(float value)
    {
        if (value < 0f) throw new ArgumentException();
        _particles.simulationSpeed = value;
    }

    protected virtual void Awake() => _particles = GetComponent<ParticleSystem>().main;
}
