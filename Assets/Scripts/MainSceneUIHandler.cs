using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordTMPro;
    [SerializeField] private Button startButton;

    private int gameSceneIndex = 1;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }

    private void SetRecordText(string text)
    {
        recordTMPro.text = text;
    }
}
