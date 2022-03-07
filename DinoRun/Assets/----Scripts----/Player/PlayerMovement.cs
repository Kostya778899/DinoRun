using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Min(1)] public int JumpsCount = 1;
    [Min(0)] public float JumpForce = 500f;

    //[SerializeField] private AnimationCurve _jumpCurve;
    //[SerializeField] private float _jumpDuration = 1f;

    //[SerializeField] private UnityEvent _onStartJump, _onEndJump;

    [SerializeField] private StateMachine<StateSettings> _stateMachine;

    private const string _runStateName = "Run";
    private const string _jumpStateName = "Jump";
    private const string _runSquatStateName = "RunSquat";
    private const string _killStateName = "Kill";

    private Rigidbody2D _rigidbody;
    //private Sequence _jumpSequence;
    private int _jumpsCount = 1;
    //private bool _isJumping = false;


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

    public void TryRun()
    {
        if (_stateMachine.GetCurrentState().Name != _killStateName) _stateMachine.TrySetCurrentStateIndex(_runStateName);
    }
    public void TryJump()
    {
        if (_stateMachine.GetCurrentState().Name == _runSquatStateName) return;

        if (_stateMachine.TrySetCurrentStateIndex(_jumpStateName)) _jumpsCount = JumpsCount;

        if (_jumpsCount > 0)
        {
            _jumpsCount--;

            //if (_jumpSequence.IsActive()) _jumpSequence.Pause();
            //_jumpSequence = DOTween.Sequence();

            _rigidbody.AddForce(new Vector2(0f, JumpForce));
            //_jumpSequence.Append(_rigidbody.DOMoveY(transform.position.y + JumpHeight, _jumpDuration).SetEase(_jumpCurve)
            //    .OnComplete(() => _stateMachine.TrySetCurrentStateIndex(_runStateName)));
        }
    }
    public void TryRunSquat() => _stateMachine.TrySetCurrentStateIndex(_runSquatStateName);
    public void TryKill()
    {
        _stateMachine.TrySetCurrentStateIndex(_killStateName);
        //_jumpSequence.Pause();
    }

    public void OnCollisionWithGround()
    {
        if (_stateMachine.GetCurrentState().Name == _jumpStateName) _stateMachine.TrySetCurrentStateIndex(_runStateName);
    }

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
