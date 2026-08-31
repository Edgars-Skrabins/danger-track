public interface IDeckContent<TCardData> where TCardData : CardData
{
    TCardData CardData { get; }
    int Amount { get; }
}
