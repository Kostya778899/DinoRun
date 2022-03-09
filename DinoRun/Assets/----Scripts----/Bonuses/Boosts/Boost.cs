using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class Boost : MonoBehaviour
{
    protected GameObject Target;

    [SerializeField] private float _workTime = 5f;
    [SerializeField] private UnityEvent<GameObject> _onActivate, _onDeActivate;


    public virtual void Activate(GameObject target)
    {
        Target = target;
        _onActivate?.Invoke(Target);
    }
    public virtual void DeActivate() => _onDeActivate?.Invoke(Target);
}
