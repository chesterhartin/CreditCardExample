namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the account business logic class
    /// </summary>
    public class AccountsBI : IAccountBI
    {

        #region " Private Properties "

        /// <summary>
        /// A collection of credit card accounts
        /// </summary>
        private readonly IDAL _accounts;

        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// The controller constructor
        /// Note: initializes the accounts dal
        /// </summary>
        public AccountsBI()
        {
            _accounts = new AccountDAL();
        }

        /// <summary>
        /// Try to add an account
        /// </summary>
        /// <param name="transaction">a transaction to add</param>
        /// <returns>true if successful, false otherwise</returns>
        public bool TryAddAccount(Transaction transaction)
        {
            if (string.IsNullOrEmpty(transaction.AccountName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(transaction.AccountNumber))
            {
                return false;
            }

            if (transaction.AccountLimit < 0)
            {
                return false;
            }

            return
                _accounts.TryAddAccount(new Account(transaction.AccountName, transaction.AccountNumber,
                    transaction.AccountLimit));
        }

        /// <summary>
        /// Try to chage the account an amount
        /// </summary>
        /// <param name="transaction">a transaction to deduct</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool TryChargeAccount(Transaction transaction)
        {
            if (string.IsNullOrEmpty(transaction.AccountName))
            {
                return false;
            }

            if (transaction.Amount < 0)
            {
                return false;
            }

            var user = _accounts.SelectAccountByName(transaction.AccountName);

            if (user == null)
            {
                //user not found
                return false;
            }

            return user.TryChargeAccount(transaction.Amount);
        }

        /// <summary>
        /// Try to credit the account an amount
        /// </summary>
        /// <param name="transaction">a transaction to credit</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool TryCreditAccount(Transaction transaction)
        {
            if (string.IsNullOrEmpty(transaction.AccountName))
            {
                return false;
            }

            if (transaction.Amount < 0)
            {
                return false;
            }

            var user = _accounts.SelectAccountByName(transaction.AccountName);

            if (user == null)
            {
                //user not found
                return false;
            }

            return user.TryCreditAccount(transaction.Amount);
        }

        /// <summary>
        /// Report the output to the preferred device
        /// </summary>
        /// <param name="output"></param>
        public void Report(IOutput output)
        {
            output.Print(_accounts.SelectAllAccounts());
        }

        #endregion

    }
}
