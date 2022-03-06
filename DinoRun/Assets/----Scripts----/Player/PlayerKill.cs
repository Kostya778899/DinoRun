using UnityEngine;
using UnityEngine.Events;

public class PlayerKill : MonoBehaviour
{
    public UnityEvent OnKill;


    [SerializeField] private AnimationCurve _setTimeScaleCurve;
    [SerializeField] private float _setTimeScaleDuration = 1.5f;


    public void Kill()
    {
        OnKill?.Invoke();
    }
}
