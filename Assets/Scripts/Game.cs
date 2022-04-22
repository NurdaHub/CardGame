using UnityEngine;

public class Game : MonoBehaviour
{
    public ScoreCounter ScoreCounter;
    public PlayerCard PlayerCard;
    public CardSpawner CardSpawner;
    public LevelManager LevelManager;

    private void Start()
    {
        PlayerCard.OnCardMoveCompleteAction += OnPlayerCardMoveComplete;
    }

    public void OnPlayerCardMoveComplete()
    {
        ScoreCounter.ScoreUp();
        CardSpawner.NewRandomCard();
    }
}
