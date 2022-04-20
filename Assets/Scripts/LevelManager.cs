using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level { get; private set; }

    public void LevelUp()
    {
        level++;
    }
}
