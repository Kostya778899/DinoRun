using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [HideInInspector] public int Value { get; protected set; } = 0;

    [SerializeField] private UnityEvent<int> _onSetScore;
    [SerializeField] private UiText[] _texts;
    [SerializeField] private bool _updateCurrentValueIfLessNewValue = true;


    public virtual void SetScore(int value)
    {
        if (value >= 0) Value = value;
        else throw new Exception();
        _onSetScore?.Invoke(Value);
    }
    public void TrySetScore(int value) { if (value >= 0 && (_updateCurrentValueIfLessNewValue || Value <= value)) SetScore(value); }

    protected virtual void Awake() => _onSetScore.AddListener((int value) => { foreach (var item in _texts) item.SetValueField(value); });
    private void Start() => TrySetScore(Value);
}
