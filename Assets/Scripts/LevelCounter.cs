using System;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public int Level { get; private set; }

    public event Action OnLevelUpEvent;

    public void LevelUp()
    {
        Level++;
        OnLevelUpEvent?.Invoke();
    }
}
