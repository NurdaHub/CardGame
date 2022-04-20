using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardScaler cardScaler;
    [SerializeField] private Canvas cardCanvas;
    private PlayerCard playerCard;
    private Slot slot;
    private Vector3[] neighbours;
    private bool isMouseDown;

    private void Start()
    {
        cardScaler.OnScaleEndAction += OnScaleEnd;
    }

    public void Init(PlayerCard _playerCard, Camera _camera, Slot _slot)
    {
        playerCard = _playerCard;
        slot = _slot;
        neighbours = _slot.neighbours;
        _slot.isFree = false;
        transform.position = _slot.transform.position;
        cardCanvas.worldCamera = _camera;
        cardScaler.Scale();
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
}
