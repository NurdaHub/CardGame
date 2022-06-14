public class GreenCard : Card
{
    protected override void PlayerHealthChange()
    {
        playerCard.GetPlayerHealth().Heal(cardValue);
    }
}
