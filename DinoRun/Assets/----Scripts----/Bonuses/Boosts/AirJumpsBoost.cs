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

        _playerMovement = target.GetComponentInChildren<PlayerMovement>();
        _playerMovement.JumpsCount.Current = _jumpsCount;
    }
    public override void DeActivate()
    {
        base.DeActivate();
        _playerMovement.JumpsCount.Reset();
    }
}
