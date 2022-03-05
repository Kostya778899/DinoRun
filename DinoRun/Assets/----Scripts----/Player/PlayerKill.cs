using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private UnityEvent _onKill;
    [SerializeField] private AnimationCurve _setTimeScaleCurve;
    [SerializeField] private float _setTimeScaleDuration = 1.5f;


    public void Kill()
    {
        _onKill?.Invoke();
        //DOTween.Sequence().Append(DOTween.To(() => 1f, x => Time.timeScale = x, 0f, _setTimeScaleDuration).SetEase(_setTimeScaleCurve).SetUpdate(true));
        //DOTween.Sequence().Delay();
    }

    private IEnumerator SetTimeScaleSmoothly(float value, float time)
    {
        for (int t = 0; t < time; t++)
        {
            yield return null;
        }
    }

    //private void Start()
    //{
    //    SceneManager.sceneUnloaded += OnSceneUnloaded;
    //}
    //private void OnSceneUnloaded(Scene scene) => DOTween.Sequence().Delay();
}
