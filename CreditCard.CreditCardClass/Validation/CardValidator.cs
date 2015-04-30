using System.Linq;
using System.Text.RegularExpressions;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is a card validator class.
    /// </summary>
    public class CardValidator
    {
        #region " Private Properties "

        /// <summary>
        /// The maximum length of a card number
        /// </summary>
        private const int MaxLength = 19;

        /// <summary>
        /// The minum length of a card number
        /// Note: while min-length was not specified, I'm checking to be on the safe side
        /// </summary>
        private const int MinLength = 3;

        /// <summary>
        /// The regex to validate the number. This is a tad bit restrictive since non-arabic numbers
        ///   will not be supported
        /// </summary>
        private static readonly Regex NumberRegex = new Regex(@"^[0-9]+$");
        
        #endregion 

        #region " Public Constructors and Methods "

        /// <summary>
        /// Given a string, validate that it's length meets the minimum and maximum length criteria.
        /// Note: spec sheet did not mention a minimum length.
        /// </summary>
        /// <param name="number">a string</param>
        /// <returns>true if with-in valid length, false otherwise</returns>
        public static bool IsValidLength(string number)
        {
            // ensure that the length is within our expected bounds
            if (number.Length >= MinLength && number.Length <= MaxLength)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Given a string of integers "12345", validate that this is a valid Luhn10. 
        /// Note: while the spec sheet says that the credit card numbers will always be numeric,
        ///       it's fairly cheap to double-check. The bulk of the luhn algorithm was found here
        ///       and has been slightly modified:
        ///       http://www.codeproject.com/Tips/515367/Validate-credit-card-number-with-Mod-algorithm
        /// </summary>
        /// <param name="number">a string of integers containing only arabic numerals.</param>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidLuhn10(string number)
        {
            //quick check to make sure the string is not empty
            if (string.IsNullOrWhiteSpace(number))
            {
                return false;
            }

            if (!NumberRegex.IsMatch(number))
            {
                return false;
            }

            // 1. For characters 0-9
            // 2. Reverse
            // 3. Convert the character to an integer
            // 4. If the index is even, multiple by 2, else multiple by 1 (no change)
            // 5. If the resulting digit is not a single digit number (i.e. 11) add these numbers together to get a single digit (1 + 1 = 2)
            // 6. Get the total sum of all digits 
            int sum = number.Where((num) => num >= '0' && num <= '9')
                            .Reverse()
                            .Select((num, i) => ((int)num - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((num) => num / 10 + num % 10);

            // if the sum is divisible by 10, the number is a valid Luhn10, else it is invalid
            return sum % 10 == 0;
        }
       
        #endregion
    }
}
