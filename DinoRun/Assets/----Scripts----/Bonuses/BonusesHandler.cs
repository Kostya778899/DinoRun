using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesHandler : MonoBehaviour
{
    [SerializeField] private CollisionCheck _collisionCheck;


    private void Awake()
    {
        var onCollisionObjectEvent = new CollisionCheck.OnCollisionObjectHasComponent(typeof(Bonus));
        onCollisionObjectEvent.Event.AddListener((Component component, Collision2D collision) => Activate((Bonus)component));
        _collisionCheck.OnCollisionWithComponents.Add(onCollisionObjectEvent);
    }

    public void Activate(Bonus bonus)
    {
        bonus.Activate(this.gameObject);
    }
}
