using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// Output the results to the console
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        #region " Public Constructors and Methods "

        /// <summary>
        /// Given a list of credit cards, export to the screen
        /// </summary>
        /// <param name="cards">a collection of credit cards</param>
        public void Print(IEnumerable<Account> cards)
        {
            foreach (var card in cards.OrderBy(s => s.AccountName))
            {
                Console.WriteLine("{0}: {1}", card.AccountName, card.IsValid ? string.Concat("$", card.Balance) : "error");
            }
        }

        #endregion

    }
}