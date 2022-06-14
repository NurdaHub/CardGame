using System;
using DG.Tweening;
using UnityEngine;

public class CardScaler : MonoBehaviour
{
    public event Action OnScaleEndEvent;
    
    private Tweener scaleTween;
    private float scaleDuration = 0.3f;

    public void Scale()
    {
        Scale(1);        
    }

    public void Unscale()
    {
        Scale(0);
    }
    
    private void Scale(float value)
    {
        scaleTween?.Kill();
        scaleTween = transform.DOScale(value, scaleDuration)
            .OnComplete(() => { OnScaleEndEvent?.Invoke(); });
    }
}
