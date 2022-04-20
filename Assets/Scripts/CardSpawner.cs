using System.Linq;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private PlayerCard playerCard;
    [SerializeField] private Card redCardPrefab;
    [SerializeField] private Card greenCardPrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Slot[] allSlots;

    private Pool<Card> redCardsPool;
    private Pool<Card> greenCardsPool;
    private int cardsCount = 5;
    private float maxChance = 50;
    public float multiplier = 0.1f;

    private void Start()
    {
        CreatePool();
        SpawnAllCards();
        playerCard.OnCardMoveCompleteAction += NewRandomCard;
    }

    private void CreatePool()
    {
        redCardsPool = new Pool<Card>(redCardPrefab, cardsCount, transform);
        greenCardsPool = new Pool<Card>(greenCardPrefab, cardsCount, transform);
    }

    private void SpawnAllCards()
    {
        for (int i = 0; i < allSlots.Length - 1; i++)
        {
            NewRandomCard();
        }
    }

    private void SpawnRedCard()//Vector3 _position, Vector3[] _neighbours)
    {
        SpawnNewCard(redCardsPool);//, _position, _neighbours);
    }

    private void SpawnGreenCard()//Vector3 _position, Vector3[] _neighbours)
    {
        SpawnNewCard(greenCardsPool); //, _position, _neighbours);
    }

    private void SpawnNewCard(Pool<Card> cardsPool)//, Vector3 _position, Vector3[] _neighbours)
    {
        Slot slot = GetFreeSlot();
        var newCard = cardsPool.GetFreeElement();
        //newCard.transform.position = _position;
        newCard.Init(playerCard, mainCamera, slot);
    }

    public void NewRandomCard()
    {
        float random = Random.Range(0, 100);
        float chance = levelManager.level * multiplier;
        // var slot = GetFreeSlot();
        // slot.isFree = false;
        // Vector3 spawnPosition = slot.transform.position;
        // Vector3[] neighbours = slot.neighbours;
        
        if (random < chance)
            SpawnRedCard();
        else
            SpawnGreenCard();
    }

    private Slot GetFreeSlot()
    {
        foreach (var slot in allSlots)
        {
            if (slot.isFree)
                return slot;
        }

        return null;//allSlots.First(s => s.isFree);
    }
}
