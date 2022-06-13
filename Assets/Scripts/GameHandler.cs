using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private LevelCounter levelCounter;
    [SerializeField] private PlayerCard playerCard;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private UITextHandler uiTextHandler;

    private void Start()
    {
        SetActions();
    }

    private void SetActions()
    {
        playerCard.OnCardMoveCompleteAction += OnPlayerCardMoveComplete;
        levelCounter.OnLevelUpEvent += OnLevelUp;
        scoreCounter.OnScoreUpEvent += OnScoreUp;
    }

    private void OnDisable()
    {
        playerCard.OnCardMoveCompleteAction -= OnPlayerCardMoveComplete;
        levelCounter.OnLevelUpEvent -= OnLevelUp;
        scoreCounter.OnScoreUpEvent -= OnScoreUp;
    }

    private void OnPlayerCardMoveComplete()
    {
        scoreCounter.ScoreUp();
        cardSpawner.NewRandomCard();
    }

    private void OnLevelUp()
    {
        string text = levelCounter.Level.ToString();
        uiTextHandler.SetLevelText(text);
    }

    private void OnScoreUp()
    {
        string text = scoreCounter.Score.ToString();
        uiTextHandler.SetScoreText(text);
    }
}
