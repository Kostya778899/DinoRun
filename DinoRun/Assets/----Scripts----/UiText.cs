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


    public void SetText(string value) => _uiText.SetText(_text = value);

    public void SetValueField(string value) => SetText(_uiText.text.Replace(_text, value));
    public void SetValueField(int value) => SetValueField(value.ToString());

    private void Awake() => _uiText = GetComponent<TMP_Text>();
}
