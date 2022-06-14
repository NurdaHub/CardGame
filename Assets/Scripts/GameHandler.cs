using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private LevelCounter levelCounter;
    [SerializeField] private PlayerCard playerCard;
    [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private UITextHandler uiTextHandler;
    [SerializeField] private UIButtonsHandler uiButtonsHandler;

    private int currentSceneIndex = 0;

    private void Start()
    {
        SetActions();
    }

    private void SetActions()
    {
        playerCard.OnCardMoveCompleteAction += OnPlayerCardMoveComplete;
        levelCounter.OnLevelUpEvent += OnLevelUp;
        scoreCounter.OnScoreUpEvent += OnScoreUp;
        uiButtonsHandler.OnRestartButtonClickEvent += Restart;
        uiButtonsHandler.OnExitButtonClickEvent += Exit;
    }

    private void OnDisable()
    {
        playerCard.OnCardMoveCompleteAction -= OnPlayerCardMoveComplete;
        levelCounter.OnLevelUpEvent -= OnLevelUp;
        scoreCounter.OnScoreUpEvent -= OnScoreUp;
        uiButtonsHandler.OnRestartButtonClickEvent -= Restart;
        uiButtonsHandler.OnExitButtonClickEvent -= Exit;
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

    private void Restart()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
