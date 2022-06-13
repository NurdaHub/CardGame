using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthTextSetter healthTextSetter;
    
    private int health;

    public void Heal(int value)
    {
        health += value;
        healthTextSetter.SetText(health.ToString());
    }

    public void Damage(int value)
    {
        health -= value;
        healthTextSetter.SetText(health.ToString());
    }
}
