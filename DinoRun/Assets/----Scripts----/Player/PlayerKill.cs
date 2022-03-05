using UnityEngine;
using UnityEngine.Events;

public class PlayerKill : MonoBehaviour
{
    [SerializeField] private UnityEvent _onKill;
    [SerializeField] private AnimationCurve _setTimeScaleCurve;
    [SerializeField] private float _setTimeScaleDuration = 1.5f;


    public void Kill()
    {
        _onKill?.Invoke();
    }
}
