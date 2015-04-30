namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the account business logic interface
    /// </summary>
    interface IAccountBI
    {
        /// <summary>
        /// Try to add an account
        /// </summary>
        /// <param name="transaction">a transaction to add</param>
        /// <returns>true if successful, false otherwise</returns>
        bool TryAddAccount(Transaction transaction);

        /// <summary>
        /// Try to chage the card an amount
        /// </summary>
        /// <param name="transaction">a transaction to deduct</param>
        /// <returns>True if successful, false otherwise</returns>
        bool TryChargeAccount(Transaction transaction);

        /// <summary>
        /// Try to credit the card an amount
        /// </summary>
        /// <param name="transaction">a transaction to credit</param>
        /// <returns>True if successful, false otherwise</returns>
        bool TryCreditAccount(Transaction transaction);

        /// <summary>
        /// Prepares the report to the output device
        /// </summary>
        /// <param name="output">The output device</param>
        void Report(IOutput output);
    }
}
