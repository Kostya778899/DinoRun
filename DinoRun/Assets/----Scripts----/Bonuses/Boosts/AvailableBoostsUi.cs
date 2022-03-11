using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableBoostsUi : MonoBehaviour
{
    [SerializeField] private BoostUiIcon _boostUiIconPrefab;
    [SerializeField] private Transform _content;


    public void AddBoost(Boost value)
    {
        var boostUiIcon = Instantiate(_boostUiIconPrefab.gameObject, _content).GetComponent<BoostUiIcon>();
        (value as TemporaryBoost)?.Timer.OnStep01.AddListener((float value) => boostUiIcon.FilledImage.fillAmount = value);
    }
}
