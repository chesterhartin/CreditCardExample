using System;

namespace CreditCard.CreditCardClass
{
    public static class AmountUtility
    {
        #region " Public Constructors and Methods "

        /// <summary>
        /// Given a number, if it begins with the currency symbol $, remove the character and try to convert 
        ///   the result to an integer
        /// </summary>
        /// <param name="number">the number string to check</param>
        /// <param name="result">the resulting integer</param>
        /// <returns>true if successfully removed the character, false otherwise</returns>
        public static bool TryStripCurrency(string number, out int result)
        {
            result = 0;
            if (number.StartsWith("$"))
            {
                number = number.Remove(0, 1);

                if (Int32.TryParse(number, out result))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
