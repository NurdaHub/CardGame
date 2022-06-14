using TMPro;
using UnityEngine;

public class CardCanvas : MonoBehaviour
{
    [SerializeField] private Canvas cardCanvas;
    [SerializeField] private TextMeshProUGUI valueText;

    public void Init(Camera currentCamera, string text)
    {
        cardCanvas.worldCamera = currentCamera;
        valueText.text = text;
    }
}
