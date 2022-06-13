using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private LevelCounter levelCounter;
    
    public int Score { get; private set; }

    public event Action OnScoreUpEvent;
    
    private int perScore = 10;
    private int scoreForLevelUp = 10;

    private void Start()
    {
        Score = 0;
    }

    public void ScoreUp()
    {
        Score++;
        OnScoreUpEvent?.Invoke();

        if (Score >= scoreForLevelUp)
        {
            levelCounter.LevelUp();
            scoreForLevelUp += perScore;
        }
    }
}
