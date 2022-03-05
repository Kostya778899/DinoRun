using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "PauseGameChanger", fileName = "New" + nameof(PauseGameChanger))]
public class PauseGameChanger : ScriptableObject, CMath.IIncluded
{
    [HideInInspector] public bool IsPaused { get; private set; } = false;
    [HideInInspector] public event Action OnPause, OnResume;


    public void Activate()
    {
        SetActive(true);
        OnPause?.Invoke();
    }
    public void DeActivate()
    {
        SetActive(false);
        OnResume?.Invoke();
    }
    private void SetActive(bool isActive)
    {
        IsPaused = isActive;
        //Time.timeScale = Convert.ToInt32(!isActive);
    }
}
