namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the standard interface for accounts
    /// </summary>
    interface IAccount
    {
        /// <summary>
        /// Try to chage the card an amount
        /// </summary>
        /// <param name="amount">the amount to deduct</param>
        /// <returns>True if successful, false otherwise</returns>
        bool TryChargeAccount(int amount);

        /// <summary>
        /// Try to credit the card an amount
        /// </summary>
        /// <param name="amount">the amount to credit the account</param>
        /// <returns>True if successful, false otherwise</returns>
        bool TryCreditAccount(int amount);

    }
}
