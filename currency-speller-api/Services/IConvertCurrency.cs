namespace currency_speller_api.Services
{
    /// <summary>
    /// Interface for converting amount to words representaation.
    /// </summary>
    public interface IConvertCurrency
    {
        string Convert(double amount);
    }
}
