using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using CMath;

[RequireComponent(typeof(CTimer))]
public abstract class TemporaryBoost : Boost
{
    [HideInInspector] public CTimer Timer { get; private set; }


    public override void Activate(GameObject target)
    {
        base.Activate(target);

        Timer.Pinpoint();
    }
    public override void DeActivate()
    {
        base.DeActivate();
    }

    private void Awake()
    {
        Timer = GetComponent<CTimer>();
        Timer.OnCompletion.AddListener(DeActivate);
    }
}
