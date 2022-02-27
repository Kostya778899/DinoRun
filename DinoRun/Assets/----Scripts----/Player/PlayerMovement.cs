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

    //[SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private UnityEvent _onStartJump, _onEndJump;

    private Rigidbody2D _rigidbody;
    private bool _isJumping = false;


    public void TryJump()
    {
        if (!_isJumping)
        {
            _isJumping = true;
            _onStartJump?.Invoke();
            _rigidbody.DOMoveY(0f, _jumpDuration).SetEase(_jumpCurve).OnComplete(() =>
            {
                _isJumping = false;
                _onEndJump?.Invoke();
            });
        }
    }

    private void Start() => _rigidbody = GetComponent<Rigidbody2D>();
}
