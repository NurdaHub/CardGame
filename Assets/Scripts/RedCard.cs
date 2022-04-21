public class RedCard : Card
{
    protected override void PlayerHealthChange()
    {
        playerCard.PlayerHealth.Damage(CardValue);
    }
}
