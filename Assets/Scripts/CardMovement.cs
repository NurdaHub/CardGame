using System;
using DG.Tweening;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    public Action OnMoveCompleteAction;
    private float moveDuration = 1;
    
    public void Move(Vector3 targetPosition)
    {
        transform.DOMove(targetPosition, moveDuration).OnComplete(() => { OnMoveCompleteAction?.Invoke(); });
    }
}
