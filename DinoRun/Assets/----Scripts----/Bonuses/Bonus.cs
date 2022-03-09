using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CMath;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> _onActivate;


    public virtual void Activate(GameObject target) => _onActivate?.Invoke(target);
}
