using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject, Collision2D> _onCollision;
    [SerializeField] private OnCollisionWithTag[] _onCollisionWithTags;

    [SerializeField] private bool _collisionWithParticles = false;

    [System.Serializable]
    private struct OnCollisionWithTag
    {
        [CMath.TagSelector] public string TagToCollision;
        public UnityEvent<GameObject, Collision2D> Event;
    }


    private void OnCollisionEnter2D(Collision2D collision) => OnCollision(collision.gameObject, collision);
    private void OnParticleCollision(GameObject other) { if (_collisionWithParticles) OnCollision(other); }

    private void OnCollision(GameObject @object, Collision2D collision = null)
    {
        Debug.Log(collision);
        _onCollision?.Invoke(@object, collision);
        foreach (var item in _onCollisionWithTags) if (item.TagToCollision == @object.tag) item.Event?.Invoke(@object, collision);
    }
}
