using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CMath;

public abstract class TemporaryBoost : Boost
{
    [SerializeField] private float _lifetime = 5f;


    public override async void Activate(GameObject target)
    {
        base.Activate(target);

        await Task.Delay(CConvert.Milliseconds(_lifetime));
        DeActivate();
    }
    public override void DeActivate()
    {
        base.DeActivate();
    }
}
