using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using CMath;

public class BoostUiIcon : MonoBehaviour, IIncluded
{
    [SerializeField] private Image _icon;

    [SerializeField] private float _setActiveAnimationDuration = 0.8f;


    public virtual void Activate()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, _setActiveAnimationDuration).SetEase(Ease.OutElastic);
    }
    public virtual void DeActivate() => transform.DOScale(0f, _setActiveAnimationDuration).SetEase(Ease.OutQuad).OnComplete(() => Destroy(this.gameObject));

    public virtual void SetIcon(Sprite sprite) => _icon.sprite = sprite;
}
