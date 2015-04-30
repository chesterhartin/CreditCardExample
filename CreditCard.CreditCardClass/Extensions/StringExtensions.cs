namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// Extend the string class 
    /// </summary>
    public static class StringExtensions
    {
        #region " Public Constructors and Methods "

        /// <summary>
        /// Run all tests for validity
        /// </summary>
        /// <returns>true if valid, false otherwise</returns>
        public static bool IsValidCard(this string number)
        {
            if (!CardValidator.IsValidLength(number))
            {
                return false;
            }

            if (!CardValidator.IsValidLuhn10(number))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
