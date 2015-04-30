namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// The account controller controls the behavior of the applications
    /// </summary>
    public class AccountsController : IController
    {
        #region " Private Properties "

        /// <summary>
        /// This is the account Bi for interacting with the account business logic
        /// </summary>
        private IAccountBI _accountBi = null;

        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// The controller constructor
        /// Note: initializes the accounts bi
        /// </summary>
        public AccountsController()
        {
            _accountBi = new AccountsBI();
        }

        /// <summary>
        /// Process one line's worth of data
        /// </summary>
        /// <param name="line">a string representing one transaction</param>
        /// <returns>True if the line processed successfully, false otherwise</returns>
        public bool ProcessLine(string line)
        {
            var transaction = new Transaction(line);
            var transactionSuccess = false;

            if (!transaction.IsValidTransaction)
            {
                transactionSuccess = transaction.IsValidTransaction;
                return transactionSuccess;
            }

            switch (transaction.Action)
            {
                case "add":
                    transactionSuccess = TryAddAccount(transaction);
                    break;
                case "charge":
                    transactionSuccess = TryChargeAccount(transaction);
                    break;
                case "credit":
                    transactionSuccess = TryCreditAccount(transaction);
                    break;
            }

            return transactionSuccess;
        }

        /// <summary>
        /// Report the output to the preferred device
        /// </summary>
        /// <param name="output"></param>
        public void Report(IOutput output)
        {
            _accountBi.Report(output);
        }

        #endregion

        #region " Private and Protected Methods "

        /// <summary>
        /// Attempt to add an account to the collection
        /// </summary>
        /// <param name="transaction">a transaction object in the add state</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool TryAddAccount(Transaction transaction)
        {
            return _accountBi.TryAddAccount(transaction);
        }

        /// <summary>
        /// Attempt to charge a card an amount
        /// </summary>
        /// <param name="transaction">a transaction object in the charge state</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool TryChargeAccount(Transaction transaction)
        {
            return _accountBi.TryChargeAccount(transaction);
        }

        /// <summary>
        /// Attempt to credit a card an amount
        /// </summary>
        /// <param name="transaction">a transaction object in the credit state</param>
        /// <returns>true if successful, false otherwise</returns>
        private bool TryCreditAccount(Transaction transaction)
        {
            return _accountBi.TryCreditAccount(transaction);
        }

        #endregion

    }
}
