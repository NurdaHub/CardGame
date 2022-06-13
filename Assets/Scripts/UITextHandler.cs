using TMPro;
using UnityEngine;

public class UITextHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTMPro;
    [SerializeField] private TextMeshProUGUI scoreTMPro;

    public void SetLevelText(string text)
    {
        levelTMPro.text = text;
    }

    public void SetScoreText(string text)
    {
        scoreTMPro.text = text;
    }
}
