public class AllowedTurnActions
{
    public bool CanPickupResourceCards { get; set; } = true;
    public bool CanPickupTrainCards { get; set; } = true;

    public void Reset()
    {
        CanPickupResourceCards = true;
        CanPickupTrainCards = true;
    }
}
