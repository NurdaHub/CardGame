using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health { get; private set; }

    public void Heal(int value)
    {
        Health += value;
    }

    public void Damage(int value)
    {
        Health -= value;
    }
}
