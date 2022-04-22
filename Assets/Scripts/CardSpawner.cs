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

    private void SpawnRedCard()
    {
        SpawnNewCard(redCardsPool);
    }

    private void SpawnGreenCard()
    {
        SpawnNewCard(greenCardsPool);
    }

    private void SpawnNewCard(Pool<Card> cardsPool)
    {
        Slot slot = GetFreeSlot();
        var newCard = cardsPool.GetFreeElement();
        newCard.Init(playerCard, mainCamera, slot, GetRandomValue());
    }

    public void NewRandomCard()
    {
        float random = Random.Range(0, 100);
        float chance = levelManager.level * multiplier;

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

    private int GetRandomValue()
    {
        int range = Random.Range(0, levelManager.level);
        return 1 + range;
    }
}
