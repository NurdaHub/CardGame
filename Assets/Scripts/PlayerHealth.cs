using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    public int Health { get; private set; }

    public void Heal(int value)
    {
        Health += value;
        SetText(Health);
    }

    public void Damage(int value)
    {
        Health -= value;
        SetText(Health);
    }

    private void SetText(int value)
    {
        healthText.text = value.ToString();
    }
}
