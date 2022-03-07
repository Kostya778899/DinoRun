using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CMath;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject, Collision2D> _onCollision;
    [SerializeField] private OnCollisionObjectHasTag[] _onCollisionWithTags;
    [SerializeField] private OnCollisionObjectHasComponent[] _onCollisionWithComponents;

    [SerializeField] private bool _collisionWithParticles = false;

    private abstract class OnCollisionObjectHasValue<T>
    {
        public UnityEvent<T, Collision2D> Event;


        public abstract void OnCollision(GameObject @object, Collision2D collision);
    }

    [Serializable]
    private class OnCollisionObjectHasTag : OnCollisionObjectHasValue<GameObject>
    {
        [TagSelector, SerializeField] private string _tag;

        public override void OnCollision(GameObject @object, Collision2D collision) { if (@object.tag == _tag) Event?.Invoke(@object, collision); }
    }
    [Serializable]
    private class OnCollisionObjectHasComponent : OnCollisionObjectHasValue<Component>
    {
        [SerializeField] private Component _component;

        public override void OnCollision(GameObject @object, Collision2D collision) {
            if (@object.TryGetComponent(_component.GetType(), out Component component)) Event?.Invoke(component, collision); }
    }


    private void OnCollisionEnter2D(Collision2D collision) => OnCollision(collision.gameObject, collision);
    private void OnParticleCollision(GameObject other) { if (_collisionWithParticles) OnCollision(other); }

    private void OnCollision(GameObject @object, Collision2D collision = null)
    {
        _onCollision?.Invoke(@object, collision);

        foreach (var item in _onCollisionWithTags) item.OnCollision(@object, collision);
        foreach (var item in _onCollisionWithComponents) item.OnCollision(@object, collision);
        //foreach (var item in _onCollisionWithTags) if (item.TagToCollision == @object.tag) item.Event?.Invoke(@object, collision);
    }
}
