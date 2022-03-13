using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using Si
using CMath;

public class CTimer : MonoBehaviour, CMath.IIncluded
{
    public UnityEvent<float> OnStep;
    public UnityEvent<float> OnStep01;
    public UnityEvent OnCompletion;

    [SerializeField] private bool _enabledOnStart = true;
    [SerializeField] private NullableVar<float> _time = new NullableVar<float>(30f);
    [Min(0f), SerializeField] private float _stepSize = 1f;
    [SerializeField] private bool _usingRealtime = false;

    private bool _isPaused = false;


    public void Pinpoint()
    {
        Activate();
        StartCoroutine(PinpointCorutine());
    }
    public void Activate() => SetActive(true);
    public void DeActivate() => SetActive(false);
    private void SetActive(bool isActive) => _isPaused = !isActive;
    public IEnumerator PinpointCorutine()
    {
        for (float t = 0f; _time.IsNull || t < _time.Value; t += _stepSize)
        {
            yield return new WaitWhile(() => _isPaused);

            OnStep?.Invoke(t);
            OnStep01?.Invoke(Mathf.InverseLerp(0f, _time.Value, t));

            if (t >= float.MaxValue) t = 0f;
            if (_usingRealtime) yield return new WaitForSecondsRealtime(_stepSize);
            else yield return new WaitForSeconds(_stepSize);
        }
        OnStep01?.Invoke(1f);
        OnCompletion?.Invoke();
    }

    private void Start() { if (_enabledOnStart) Pinpoint(); }
}
