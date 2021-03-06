using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirJumpsBoost : TemporaryBoost
{
    [SerializeField] private int _jumpsCount = 3;

    private PlayerMovement _playerMovement;


    public override void Activate(GameObject target)
    {
        base.Activate(target);
        //ActivateUiIcon<TemporaryBoostUiIcon>().Activate();
        var uiIcon = CreateUiIcon<TemporaryBoostUiIcon_>();
        uiIcon.Activate();
        Timer.OnStep01.AddListener(uiIcon.SetTimerFill);
        Timer.OnCompletion.AddListener(uiIcon.DeActivate);

        _playerMovement = target.GetComponentInChildren<PlayerMovement>();
        transform.SetParent(_playerMovement.transform);
        transform.localPosition = Vector3.zero;

        _playerMovement.JumpsCount.Current = _jumpsCount;
    }
    public override void DeActivate()
    {
        base.DeActivate();
        _playerMovement.JumpsCount.Reset();
    }
}
