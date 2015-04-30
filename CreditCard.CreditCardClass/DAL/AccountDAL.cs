using System.Collections.Generic;
using System.Linq;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// The Accoutn DAL class
    /// </summary>
    public class AccountDAL : IDAL
    {
        #region " Private Properties "

        /// <summary>
        /// The accounts dal
        /// </summary>
        private List<Account> _accounts = null;

        #endregion
        
        #region " Public Constructors and Methods "

        /// <summary>
        /// The DAL for the Account
        /// </summary>
        public AccountDAL()
        {
            if (_accounts == null)
            {
                _accounts = new List<Account>();                
            }
        }

        /// <summary>
        /// Try to add an account to the datastore
        /// </summary>
        /// <param name="account">an instance of the account</param>
        /// <returns>true if successful</returns>
        public bool TryAddAccount(Account account)
        {
            //check to see if the account already exists
            var user = _accounts.FirstOrDefault(a => a.AccountName == account.AccountName);

            if (user != null)
            {
                //user already exists
                return false;
            }

            _accounts.Add(account);

            return true;
        }

        /// <summary>
        /// Try to get the account from the datastore
        /// </summary>
        /// <param name="name">the account name to lookup</param>
        /// <returns>An account. Null account == not found</returns>
        public Account SelectAccountByName(string name)
        {
            return _accounts.FirstOrDefault(a => a.AccountName == name);
        }

        /// <summary>
        /// Get the account collection 
        /// </summary>
        /// <returns>the account collection</returns>
        public IEnumerable<Account> SelectAllAccounts()
        {
            return _accounts;
        }

        #endregion

    }
}
