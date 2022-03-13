using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using Sirenix.OdinInspector;

public abstract class Boost : MonoBehaviour
{
    protected GameObject Target;

    [PreviewField(60f), SerializeField] private Sprite _icon;
    [SerializeField] private ComponentsContainer _availableBoostsUi;
    [SerializeField] private BoostUiIcon _uiIconPrefab;
    [SerializeField] private UnityEvent<GameObject> _onActivate, _onDeActivate;


    public virtual void Activate(GameObject target)
    {
        Target = target;


        _onActivate?.Invoke(Target);
    }
    public virtual void DeActivate() => _onDeActivate?.Invoke(Target);

    protected virtual T CreateUiIcon<T>() where T : BoostUiIcon
    {
        T uiIcon = (T)_availableBoostsUi.Get<AvailableBoostsUi>().AddBoostUiIcon(_uiIconPrefab);
        uiIcon.SetIcon(_icon);
        return uiIcon;
    }
}
