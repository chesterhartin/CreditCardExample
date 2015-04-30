namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This represents a user with a credit card acct
    /// </summary>
    public class Account : IAccount
    {
        #region " Public Properties "
        
        /// <summary>
        /// The User Name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// The Credit Card Number
        /// </summary>
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// The Card Account Limit
        /// </summary>
        public int AccountLimit { get; set; }
        
        /// <summary>
        /// The Card Account Balance
        /// </summary>
        public int Balance { get; set; }
        
        /// <summary>
        /// The current state of the card: false = error 
        /// </summary>
        public bool IsValid { get; private set; }
        
        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// The constructor for the account.
        /// Note: validates card as part of initialization
        /// </summary>
        /// <param name="name">the account name</param>
        /// <param name="number">the account number</param>
        /// <param name="limit">the account limit</param>
        public Account(string name, string number, int limit)
        {
            AccountName = name;
            AccountLimit = limit;
            AccountNumber = number;
            IsValid = TryValidateCard();
        }

        /// <summary>
        /// Try to charge the card an amount
        /// </summary>
        /// <param name="amount">the amount to deduct</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool TryChargeAccount(int amount)
        {
            if (!IsValid)
            {
                return false;
            }

            //note: this doesn't check negative amounts
            if (Balance + amount > AccountLimit)
            {
                return false;
            }

            Balance += amount;

            return true;
        }

        /// <summary>
        /// Try to credit the card an amount
        /// </summary>
        /// <param name="amount">the amount to credit the account</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool TryCreditAccount(int amount)
        {
            if (!IsValid)
            {
                return false;
            }

            //note: this doesn't check negative amounts
            Balance -= amount;

            return true;
        }

        #endregion

        #region " Private Methods "

        /// <summary>
        /// Given an account number, check the validity of it
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        private bool TryValidateCard()
        {
            return AccountNumber.IsValidCard();
        }

        #endregion
    }
}
