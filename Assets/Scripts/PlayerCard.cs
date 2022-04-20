using System;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private CardMovement cardMovement;
    public PlayerHealth PlayerHealth;
    public Slot Slot;
    public Action OnCardMoveCompleteAction;

    private void Start()
    {
        cardMovement.OnMoveCompleteAction += OnMoveComplete;
        Slot.isFree = false;
    }

    public void SetSlot(Slot _slot)
    {
        Slot.isFree = true;
        Slot = _slot;
        cardMovement.Move(Slot.transform.position);
    }

    private void OnMoveComplete()
    {
        //slot.isFree = true;
        OnCardMoveCompleteAction?.Invoke();
    }
}