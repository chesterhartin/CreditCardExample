using System.Collections.Generic;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the public interface for the data access layer
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// Try to add an account to the datastore
        /// </summary>
        /// <param name="account">an instance of the account</param>
        /// <returns>true if successful</returns>
        bool TryAddAccount(Account account);

        /// <summary>
        /// Try to get the account from the datastore
        /// </summary>
        /// <param name="name">the account name to lookup</param>
        /// <returns>An account. Null account == not found</returns>
        Account SelectAccountByName(string name);

        /// <summary>
        /// Select All the accounts
        /// </summary>
        /// <returns></returns>
        IEnumerable<Account> SelectAllAccounts();
    }
}
