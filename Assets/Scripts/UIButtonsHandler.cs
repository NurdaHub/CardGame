using System;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public event Action OnRestartButtonClickEvent;
    public event Action OnExitButtonClickEvent;

    private void Start()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnRestartButtonClicked()
    {
        OnRestartButtonClickEvent?.Invoke();
    }

    private void OnExitButtonClicked()
    {
        OnExitButtonClickEvent?.Invoke();
    }
}
