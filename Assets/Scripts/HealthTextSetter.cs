using TMPro;
using UnityEngine;

public class HealthTextSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    
    public void SetText(string text)
    {
        healthText.text = text;
    }
}
