using System.Collections.Generic;
using System.Linq;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// Test the output
    /// </summary>
    public class TestOutput :IOutput
    {
        #region " Public Properties "

        /// <summary>
        /// Expose the result set
        /// </summary>
        public List<Account> Accounts { get; private set; }

        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// Mock prints the list for testing
        /// </summary>
        /// <param name="cards">a collection of credit cards</param>
        public void Print(IEnumerable<Account> cards)
        {
            Accounts = new List<Account>();

            foreach (var card in cards.OrderBy(s => s.AccountName))
            {
                Accounts.Add(card);
            }
        }

        #endregion
    }
}
