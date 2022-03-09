using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class ButtonToHotkeys : MonoBehaviour
{
    [SerializeField] private RegisterKeyType _registerKeysType;
    [SerializeField] private KeyCode _key;
    [SerializeField] private EventTriggerType _eventType;

    private EventTrigger _eventTrigger;

    private enum RegisterKeyType { Down, Up, Click }


    private void Awake() => _eventTrigger = GetComponent<EventTrigger>();
    private void Update()
    {
        switch (_registerKeysType)
        {
            case RegisterKeyType.Down: if (!Input.GetKeyDown(_key)) return; break;
            case RegisterKeyType.Up: if (!Input.GetKeyUp(_key)) return; break;
            case RegisterKeyType.Click: if (!Input.GetKey(_key)) return; break;
            default: break;
        }

        foreach (var item in _eventTrigger.triggers)
            if (item.eventID == _eventType) item.callback?.Invoke(new BaseEventData(EventSystem.current));
    }
}
