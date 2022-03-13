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
    [SerializeField] private BoostUiIcon _uiIconPrefab;
    [SerializeField] private UnityEvent<GameObject> _onActivate, _onDeActivate;


    protected virtual T CreateUiIcon<T>() where T : BoostUiIcon => (T)_availableBoostsUi.Get<AvailableBoostsUi>().AddBoostUiIcon(_uiIconPrefab);
    public virtual void Activate(GameObject target)
    {
        Target = target;

        _onActivate?.Invoke(Target);
    }
    public virtual void DeActivate() => _onDeActivate?.Invoke(Target);

}
