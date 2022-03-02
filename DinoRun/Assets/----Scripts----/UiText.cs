using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UiText : MonoBehaviour
{
    [SerializeField] private string _valueField = "{Value}";

    private TMP_Text _text;


    public void SetText(string value) => _text.SetText(value);

    public void SetValueField(string value) => SetText(_text.text.Replace(_valueField, value));
    public void SetValueField(int value) => SetValueField(value.ToString());

    private void Awake() => _text = GetComponent<TMP_Text>();
}
