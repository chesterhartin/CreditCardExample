using System.Collections.Generic;
using System.Linq;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the transaction parser
    /// </summary>
    public class Transaction
    {
        #region " Public Properties "
        
        /// <summary>
        /// The action such as add, charge, credit
        /// </summary>
        public string Action { get; private set; }

        /// <summary>
        /// The transaction amount
        /// </summary>
        public int Amount { get; private set; }

        /// <summary>
        /// The transaction card number
        /// </summary>
        public string AccountNumber { get; private set; }

        /// <summary>
        /// The transaction account name
        /// </summary>
        public string AccountName { get; private set; }

        /// <summary>
        /// The transaction credit limit
        /// </summary>
        public int AccountLimit { get; private set; }

        /// <summary>
        /// Is this a properly formatted transaction
        /// </summary>
        public bool IsValidTransaction { get; private set; }
       
        #endregion

        #region " Private Properties "

        /// <summary>
        /// A list of valid actions for a transaction
        /// </summary>
        private static List<string> validActions = new List<string>(){"add","charge","credit"}; 

        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// Given a string, attempt to parse it into a transaction. 
        /// e.g. ADD Jim 123456 $1000
        ///      CREDIT Jim $123
        ///      CHARGE Jim $1234
        /// </summary>
        /// <param name="input"></param>
        public Transaction(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                IsValidTransaction = TryParseTransaction(input);
            }
        }

        #endregion

        #region " Private Methods "

        /// <summary>
        /// Given the transaction string, populate the class properties if valid
        /// </summary>
        /// <param name="transaction">a string representing a single line transaction</param>
        /// <returns>true if successfully parsed, false otherwise</returns>
        private bool TryParseTransaction(string transaction)
        {
            var inputArray = transaction.Split(' ');

            if (inputArray.Count() < 3 || inputArray.Count() > 4)
            {
                return false;
            }

            Action = inputArray[0].ToLower();

            if (!validActions.Contains(Action))
            {
                return false;
            }

            AccountName = inputArray[1];

            AccountNumber = inputArray[2];

            int parsedInt;

            if (AmountUtility.TryStripCurrency(inputArray[2], out parsedInt))
            {
                Amount = parsedInt;
            }

            if (inputArray.Count() == 4)
            {
                if (AmountUtility.TryStripCurrency(inputArray[3], out parsedInt))
                {
                    AccountLimit = parsedInt;
                }
            }

            return true;
        }

        #endregion
    }
}
