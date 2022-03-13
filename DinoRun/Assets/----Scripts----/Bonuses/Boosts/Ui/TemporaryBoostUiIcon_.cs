using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemporaryBoostUiIcon_ : BoostUiIcon
{
    [SerializeField] private Image _timerFilledImage;


    public override void Activate()
    {
        base.Activate();

    }
    public override void DeActivate()
    {
        base.DeActivate();

    }
    public void SetTimerFill(float value) => _timerFilledImage.fillAmount = value;
}
