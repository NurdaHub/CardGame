using UnityEngine;

[RequireComponent(typeof(MouseClickDetector))]
public abstract class Card : MonoBehaviour
{
    [SerializeField] private CardScaler cardScaler;
    [SerializeField] private CardCanvas cardCanvas;
    [SerializeField] private MouseClickDetector mouseClickDetector;

    private Slot slot;
    private Vector3[] neighbours;
    private bool isMouseDown;
    
    protected PlayerCard playerCard;
    protected int cardValue;

    private void OnEnable()
    {
        mouseClickDetector.OnMouseClickedEvent += OnMouseClicked;
        cardScaler.OnScaleEndEvent += OnScaleEnd;
    }

    private void OnDisable()
    {
        mouseClickDetector.OnMouseClickedEvent -= OnMouseClicked;
        cardScaler.OnScaleEndEvent -= OnScaleEnd;
    }

    public void Init(PlayerCard _playerCard, Camera currentCamera, Slot _slot, int _cardValue)
    {
        playerCard = _playerCard;
        slot = _slot;
        cardValue = _cardValue;
        SetSlot();
        cardCanvas.Init(currentCamera, cardValue.ToString());
        cardScaler.Scale();
    }

    private void SetSlot()
    {
        slot.isFree = false;
        neighbours = slot.GetNeighboursPosition();
        transform.position = slot.transform.position;
    }

    private void OnMouseClicked()
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
