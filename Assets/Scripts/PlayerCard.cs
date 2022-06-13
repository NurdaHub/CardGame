using System;
using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    [SerializeField] private CardMovement cardMovement;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slot slot;
    
    public event Action OnCardMoveCompleteAction;

    private void Start()
    {
        cardMovement.OnMoveCompleteAction += OnMoveComplete;
        slot.isFree = false;
    }

    private void OnDisable()
    {
        cardMovement.OnMoveCompleteAction -= OnMoveComplete;
    }

    private void OnMoveComplete()
    {
        OnCardMoveCompleteAction?.Invoke();
    }

    public void SetSlot(Slot _slot)
    {
        slot.isFree = true;
        slot = _slot;
        cardMovement.Move(slot.transform.position);
    }

    public PlayerHealth GetPlayerHealth()
    {
        return playerHealth;
    }
}