using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score { get; private set; }

    [SerializeField] private LevelManager levelManager;
    private int perScore = 10;
    private int scoreForLevelUp = 10;

    private void Start()
    {
        score = 0;
    }

    public void ScoreUp()
    {
        score++;

        if (score >= scoreForLevelUp)
        {
            levelManager.LevelUp();
            scoreForLevelUp += perScore;
        }
    }
}
