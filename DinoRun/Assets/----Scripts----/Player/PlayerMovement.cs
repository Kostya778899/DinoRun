using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _jumpDuration = 1f;

    //[SerializeField] private UnityEvent _onStartJump, _onEndJump;

    [SerializeField] private StateMachine<StateSettings> _stateMachine;

    private const string _runStateName = "Run";
    private const string _jumpStateName = "Jump";
    private const string _runSquatStateName = "RunSquat";
    private const string _killStateName = "Kill";

    private Rigidbody2D _rigidbody;
    private bool _isJumping = false;


    [System.Serializable]
    private struct StateSettings
    {
        public GameObject GraphicsObject;
        public Collider2D Collider;


        public void SetActive(bool value)
        {
            if (GraphicsObject) GraphicsObject.SetActive(value);
            if (Collider) Collider.enabled = value;
        }
    }

    public void TryRun() => _stateMachine.TrySetCurrentStateIndex(_runStateName);
    public void TryJump()
    {
        if (_stateMachine.GetCurrentState().Name != _runSquatStateName && _stateMachine.TrySetCurrentStateIndex(_jumpStateName))
            _rigidbody.DOMoveY(0f, _jumpDuration).SetEase(_jumpCurve).OnComplete(() => _stateMachine.TrySetCurrentStateIndex(_runStateName));
    }
    public void TryRunSquat() => _stateMachine.TrySetCurrentStateIndex(_runSquatStateName);
    public void TryKill() => _stateMachine.TrySetCurrentStateIndex(_killStateName);

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _stateMachine.OnChangeState.AddListener((newState) =>
        {
            for (int i = 0; i < _stateMachine.States.Length; i++) _stateMachine.States[i].Value.SetActive(false);
            newState.Value.SetActive(true);
        });
    }
}
