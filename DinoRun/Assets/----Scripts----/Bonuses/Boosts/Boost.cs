using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class Boost : MonoBehaviour
{
    protected GameObject Target;

    [SerializeField] private ComponentsContainer _availableBoostsUi;
    [SerializeField] private BoostUiIcon UiIconPrefab;
    [SerializeField] private UnityEvent<GameObject> _onActivate, _onDeActivate;


    protected virtual T ActivateUiIcon<T>() where T : BoostUiIcon => _availableBoostsUi.Get<AvailableBoostsUi>().AddBoostUiIcon(UiIconPrefab) as T;
    public virtual void Activate(GameObject target)
    {
        Target = target;

        _onActivate?.Invoke(Target);
    }
    public virtual void DeActivate() => _onDeActivate?.Invoke(Target);

}
