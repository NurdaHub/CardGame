using UnityEngine;

public class PoolsService : MonoBehaviour
{
    [SerializeField] private Card redCardPrefab;
    [SerializeField] private Card greenCardPrefab;
    
    private Pool<Card> redCardsPool;
    private Pool<Card> greenCardsPool;
    
    private int poolCardsCount = 5;
    
    public void CreatePool()
    {
        Transform parentTransform = transform;
        redCardsPool = new Pool<Card>(redCardPrefab, poolCardsCount, parentTransform);
        greenCardsPool = new Pool<Card>(greenCardPrefab, poolCardsCount, parentTransform);
    }

    public Card GetRedCard()
    {
        return redCardsPool.GetFreeElement();
    }

    public Card GetGreenCard()
    {
        return greenCardsPool.GetFreeElement();
    }
}
