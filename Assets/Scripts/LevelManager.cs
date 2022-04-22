using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level { get; private set; }
    public TextMeshProUGUI levelText;

    public void LevelUp()
    {
        level++;
        levelText.text = level.ToString();
    }
}
