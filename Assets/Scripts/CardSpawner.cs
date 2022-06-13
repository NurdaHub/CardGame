using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private LevelCounter levelCounter;
    [SerializeField] private PoolsService poolsService;
    [SerializeField] private PlayerCard playerCard;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Slot[] allSlots;
    
    private int minValue = 1;
    private float minPercent = 0;
    private float maxPercent = 100;
    private float maxChance = 50;
    private float multiplier = 10f;

    private void Start()
    {
        poolsService.CreatePool();
        SpawnAllCards();
    }

    

    private void SpawnAllCards()
    {
        for (int i = 0; i < allSlots.Length - 1; i++)
            NewRandomCard();
    }

    private void SpawnRedCard()
    {
        Card redCard = poolsService.GetRedCard();
        SpawnNewCard(redCard);
    }

    private void SpawnGreenCard()
    {
        Card greenCard = poolsService.GetGreenCard();
        SpawnNewCard(greenCard);
    }

    private void SpawnNewCard(Card card)
    {
        Slot slot = GetFreeSlot();
        
        if (slot == null)
            return;
        
        card.Init(playerCard, mainCamera, slot, GetRandomValue());
    }

    public void NewRandomCard()
    {
        float random = Random.Range(minPercent, maxPercent);
        float chance = levelCounter.Level * multiplier;

        if (maxChance < chance)
            chance = maxChance;

        if (random < chance)
            SpawnRedCard();
        else
            SpawnGreenCard();
    }

    private Slot GetFreeSlot()
    {
        foreach (var slot in allSlots)
            if (slot.isFree)
                return slot;

        return null;
    }

    private int GetRandomValue()
    {
        int random = Random.Range(0, levelCounter.Level);
        int randomValue = minValue + random;
        
        return randomValue;
    }
}
