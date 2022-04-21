using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public ScoreCounter ScoreCounter { get; private set; }
    public PlayerCard PlayerCard { get; private set; }
    public CardSpawner CardSpawner { get; private set; }

    private void Start()
    {
        PlayerCard.OnCardMoveCompleteAction += OnCardMove;
    }

    public void OnCardMove()
    {
        
    }
}
