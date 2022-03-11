using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusesHandler : MonoBehaviour
{
    public UnityEvent<Bonus> OnActivate;

    [SerializeField] private CollisionCheck _collisionCheck;


    public void Activate(Bonus bonus)
    {
        bonus.Activate(this.gameObject);
        OnActivate?.Invoke(bonus);
    }

    private void Awake()
    {
        var onCollisionObjectEvent = new CollisionCheck.OnCollisionObjectHasComponent(typeof(Bonus));
        onCollisionObjectEvent.Event.AddListener((Component component, Collision2D collision) => Activate((Bonus)component));
        _collisionCheck.OnCollisionWithComponents.Add(onCollisionObjectEvent);
    }
}
