public class RedCard : Card
{
    protected override void PlayerHealthChange()
    {
        playerCard.GetPlayerHealth().Damage(cardValue);
    }
}
