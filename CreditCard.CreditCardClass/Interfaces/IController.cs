namespace CreditCard.CreditCardClass
{
    /// <summary>
    /// This is the controller interface
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Process one line's worth of data
        /// </summary>
        /// <param name="line">a string representing one transaction</param>
        /// <returns>True if the line processed successfully, false otherwise</returns>
        bool ProcessLine(string line);

        /// <summary>
        /// Report the output to the preferred device
        /// </summary>
        /// <param name="output"></param>
        void Report(IOutput output);
    }
}
