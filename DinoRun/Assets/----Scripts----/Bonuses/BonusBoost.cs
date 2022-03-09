using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBoost : Bonus
{
    [SerializeField] private Boost _boostPrefab;


    public override void Activate(GameObject target)
    {
        base.Activate(target);

        Boost boost = Instantiate(_boostPrefab, target.transform);
        boost.Activate(target);
    }
}
