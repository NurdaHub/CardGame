public class GreenCard : Card
{
    protected override void PlayerHealthChange()
    {
        playerCard.PlayerHealth.Heal(CardValue);
    }
}
