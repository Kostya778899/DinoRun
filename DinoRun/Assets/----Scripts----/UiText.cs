using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UiText : MonoBehaviour
{
    [SerializeField] private string _text = "Value: {Value}.";
    [SerializeField] private string _valueField = "{Value}";

    private TMP_Text _uiText;


    public void TrySetText(string value)
    {
        _text = value;
        if (_uiText && _uiText.text != _text) _uiText.SetText(_text);
    }

    public void SetValueField(string value) => TrySetText(_uiText.text.Replace(_text, value));
    public void SetValueField(int value) => SetValueField(value.ToString());

    private void OnEnable()
    {
        if (!_uiText) _uiText = GetComponent<TMP_Text>();
        TrySetText(_text);
    }
}
