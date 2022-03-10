using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using CMath;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //[Min(1)] public int JumpsCount = 1;
    public RollbackVar<int> JumpsCoun = new(1);
    [Min(0f)] public float JumpVelocity = 14f;
    [Min(0f)] public float DownDashForce = 1200f;

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
    private int _currentJumpsCount = 1;
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

        //if (_stateMachine.TrySetCurrentStateIndex(_jumpStateName)) _jumpsCount = JumpsCount;

        if (_currentJumpsCount > 0)
        {
            _currentJumpsCount--;

            //if (_jumpSequence.IsActive()) _jumpSequence.Pause();
            //_jumpSequence = DOTween.Sequence();

            //_rigidbody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpVelocity);
            //_jumpSequence.Append(_rigidbody.DOMoveY(transform.position.y + JumpHeight, _jumpDuration).SetEase(_jumpCurve)
            //    .OnComplete(() => _stateMachine.TrySetCurrentStateIndex(_runStateName)));
        }
    }
    public void TryRunSquat()
    {
        if (_stateMachine.GetCurrentState().Name == _jumpStateName)
        {
            //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -DownDashVelocity);
            _rigidbody.AddForce(new Vector2(0f, -DownDashForce));
        }
        _stateMachine.TrySetCurrentStateIndex(_runSquatStateName);
    }
    public void TryKill()
    {
        _stateMachine.TrySetCurrentStateIndex(_killStateName);
        //_jumpSequence.Pause();
    }

    public void OnCollisionWithGround()
    {
        if (_stateMachine.GetCurrentState().Name == _jumpStateName/* && _rigidbody.velocity.y <= 0f*/) _stateMachine.TrySetCurrentStateIndex(_runStateName);
        _currentJumpsCount = JumpsCoun.Current;
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
