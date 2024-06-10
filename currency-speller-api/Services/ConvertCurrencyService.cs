namespace currency_speller_api.Services
{
    /// <summary>
    /// The CurrencyConvertService class converts a currency amount (dollars and cents) in numerical
    /// into its equivalent word representation.
    /// </summary>
    public class ConvertCurrencyService : IConvertCurrency
    {
        private static readonly string[] UnitsArray = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        private static readonly string[] TeensArray = ["ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"];
        private static readonly string[] TensArray = ["", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
        private static readonly string[] ThousandsArray = ["", "thousand", "million", "billion"];

        /// <summary>
        /// Convert the double input number into word representation.
        /// </summary>
        /// <param name="amount">The double amount to convert.</param>
        /// <returns>The word representation of double amount.</returns>
        public string Convert(double amount)
        {
            // Handle the case where the amount is zero.
            if (amount == 0) return "zero dollars";

            // Handle the case where the amount is zero.
            if (amount == 1) return "one dollar";

            // Handle the case when the amount is negative, by converting it to positive and prefixing with 'minus'.
            if (amount < 0) return "minus " + Convert(Math.Abs(amount));

            // Extract the dollar part of the amount.
            long dollars = (long)amount;

            // Extract the cents part of the amount.
            long cents = (long)((amount - dollars) * 100);

            string wordRepresentation = $"{ConvertNumberToWords(dollars)} dollars";

            // Add cent when value is equal to 1.
            if (cents == 1)
            {
                wordRepresentation += $" and one cent";
            }
            // Add cent when value is greater than 1.
            else if (cents > 1)
            {
                wordRepresentation += $" and {ConvertNumberToWords(cents)} cents";
            }

            // Return the word representation of amount.
            return wordRepresentation;
        }

        /// <summary>
        /// Converts an long amount into its word representation.
        /// </summary>
        /// <param name="amount">The long amount to convert.</param>
        /// <returns>The word representation of the long amount.</returns>
        private string ConvertNumberToWords(long amount)
        {
            // Handle the case where the amount is zero.
            if (amount == 0) return "zero";

            // Handle the case when the amount is negative, by converting it to positive and prefixing with 'minus'.
            if (amount < 0) return "minus " + ConvertNumberToWords(Math.Abs(amount));

            string words = "";

            int thousandGroup = 0;

            // For each thousands.
            while (amount > 0)
            {
                // Convert the three digit from last  to words, when they are not  zero.
                if (amount % 1000 != 0)
                {
                    string numberPrefix = ConvertHundreds(amount % 1000);
                    words = numberPrefix + ThousandsArray[thousandGroup] + " " + words;
                }

                // Process the next thousands.
                amount /= 1000;
                thousandGroup++;
            }

            return words.Trim();
        }

        /// <summary>
        /// Converts a amount less than 1000 into its word representation.
        /// </summary>
        /// <param name="amount">The amount to convert.</param>
        /// <returns>The word representation of the amount.</returns>

        private string ConvertHundreds(long amount)
        {
            string words = "";

            // Check if the amount is in the hundreds place
            if ((amount / 100) > 0)
            {
                // Append the hundreds place word representation.
                words += UnitsArray[amount / 100] + " hundred ";

                // Reduce the number by removing the hundreds place.
                amount %= 100;
            }

            // Check if the remaining amount is greater than zero.
            if (amount > 0)
            {
                // If the number is less than 10, use the units array.
                if (amount < 10) words += UnitsArray[amount];

                // If the number is between 10 and 19, use the teens array.
                else if (amount < 20) words += TeensArray[amount - 10];

                else
                {
                    // If the number is 20 or more, use the tens array.
                    words += TensArray[amount / 10];

                    // If there's a unit place, add it with a hyphen.
                    if ((amount % 10) > 0) words += "-" + UnitsArray[amount % 10];
                }
            }

            // Return the word representation with a trailing space.
            return words + " ";
        }
    }
}
