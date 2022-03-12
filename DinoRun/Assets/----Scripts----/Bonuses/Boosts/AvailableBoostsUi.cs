using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableBoostsUi : MonoBehaviour
{
    [SerializeField] private Transform _content;
    //[SerializeField] private BoostUiIcon _boostUiIconPrefab;


    //public void AddBoost(Boost boost)
    //{
    //    var boostUiIcon = Instantiate(_boostUiIconPrefab.gameObject, _content).GetComponent<BoostUiIcon>();
    //    boostUiIcon.Activate();

    //    var temporaryBoost = boost as TemporaryBoost;
    //    if (temporaryBoost)
    //    {
    //        temporaryBoost.Timer.OnStep01.AddListener((float value) => boostUiIcon.FilledImage.fillAmount = value);
    //        temporaryBoost.Timer.OnCompletion.AddListener(() => boostUiIcon.DeActivate());
    //    }
    //}

    public BoostUiIcon AddBoostUiIcon(BoostUiIcon boostUiIcon) => Instantiate(boostUiIcon.gameObject, _content).GetComponent<BoostUiIcon>();
}
