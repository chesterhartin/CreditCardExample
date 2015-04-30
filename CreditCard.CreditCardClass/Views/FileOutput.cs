using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// Output the results to a file name and path
    /// </summary>
    public class FileOutput : IOutput
    {
        #region " Public Properties "

        /// <summary>
        /// The file to export to
        /// </summary>
        public string FileName { get; set; }

        #endregion

        #region " Public Constructors and Methods "

        /// <summary>
        /// The constructor for file output
        /// </summary>
        /// <param name="fileName">the name with path of the file to create. e.g. c:\\results.txt</param>
        public FileOutput(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        /// Given a list of credit cards, export to a file
        /// </summary>
        /// <param name="cards">a collection of credit cards</param>
        public void Print(IEnumerable<Account> cards)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                //normally we would throw an error here, or log the event
                return;
            }

            using (var file = new StreamWriter(FileName))
            {
                foreach (var card in cards.OrderBy(s => s.AccountName))
                {
                    file.WriteLine("{0}: {1}", card.AccountName, card.IsValid ? string.Concat("$", card.Balance) : "error");
                }                
            }
        }

        #endregion
    }
}
