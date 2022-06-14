using System;
using DG.Tweening;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public event Action OnMoveCompleteAction;
    
    private float moveDuration = 0.4f;
    
    public void Move(Vector3 targetPosition)
    {
        transform.DOMove(targetPosition, moveDuration)
            .OnComplete(() => { OnMoveCompleteAction?.Invoke(); });
    }
}
