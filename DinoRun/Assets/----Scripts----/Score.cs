using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [HideInInspector] public int Value { get; private set; } = 0;

    [SerializeField] private UnityEvent<int> _onSetScore;
    [SerializeField] private string _saveKey = "Score";

    private const int _defaultValue = 0;


    public void SetScore(int value)
    {
        if (value >= 0) Value = value;
        else throw new Exception();
        Save();
        _onSetScore?.Invoke(Value);
    }

    private void Awake() => Load();
    private void Start() => SetScore(Value);

    private void Save() => PlayerPrefs.SetInt(_saveKey, Value);
    private void Load() => Value = PlayerPrefs.GetInt(_saveKey, _defaultValue);
}
