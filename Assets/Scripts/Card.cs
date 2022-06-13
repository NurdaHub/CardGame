using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField] private CardScaler cardScaler;
    [SerializeField] private CardUI cardUI;

    private Slot slot;
    private Vector3[] neighbours;
    private bool isMouseDown;
    
    protected PlayerCard playerCard;
    protected int cardValue;

    private void Start()
    {
        cardScaler.OnScaleEndAction += OnScaleEnd;
    }

    public void Init(PlayerCard _playerCard, Camera currentCamera, Slot _slot, int _cardValue)
    {
        playerCard = _playerCard;
        slot = _slot;
        cardValue = _cardValue;
        SetSlot();
        cardUI.Init(currentCamera, cardValue.ToString());
        cardScaler.Scale();
    }

    private void SetSlot()
    {
        slot.isFree = false;
        neighbours = slot.neighbours;
        transform.position = slot.transform.position;
    }

    private void OnMouseDown()
    {
        if (!IsNeighbour())
            return;

        isMouseDown = true;
        cardScaler.Unscale();
    }

    private void OnScaleEnd()
    {
        if (isMouseDown)
        {
            PlayerHealthChange();
            playerCard.SetSlot(slot);
            isMouseDown = false;
            gameObject.SetActive(false);
        }
    }

    private bool IsNeighbour()
    {
        foreach (var neighbour in neighbours)
        {
            if (neighbour == playerCard.transform.position)
                return true;
        }

        return false;
    }

    protected abstract void PlayerHealthChange();
}
