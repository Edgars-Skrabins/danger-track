public class AllowedTurnActions
{
    public bool CanPickupGoldCardFromOutsideDeck { get; set; } = true;

    public void Reset()
    {
        CanPickupGoldCardFromOutsideDeck = true;
    }
}
