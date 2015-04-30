using System.Collections.Generic;

namespace CreditCard.CreditCardClass
{
    public interface IOutput
    {
        /// <summary>
        /// Given a list of credit cards, export to the preferred output
        /// </summary>
        /// <param name="cards">a collection of credit cards</param>
        void Print(IEnumerable<Account> cards);
    }
}
