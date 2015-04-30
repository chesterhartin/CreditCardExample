using System;
using System.IO;
using System.Linq;
using CreditCard.CreditCardClass;

namespace CreditCard
{
    class Program
    {
        /// <summary>
        /// This is the starting point for the CreditCard Account Processor Console
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine("No file arguments passed in");
                EndOfProgram();
                return;
            }

            var fileName = args[0];

            var controller = new AccountsController();


            if (!File.Exists(fileName))
            {
                Console.WriteLine("Unable to find the file: {0}", fileName);
                EndOfProgram();
                return;
            }
            else
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var readLine = reader.ReadLine();
                        if (readLine != null)
                        {
                            controller.ProcessLine(readLine);
                        }
                    }
                }
            }

            controller.Report(new ConsoleOutput());

            EndOfProgram();
        }

        /// <summary>
        /// Report a friendly message and wait for user response
        /// </summary>
        private static void EndOfProgram()
        {
            Console.WriteLine();
            Console.WriteLine("Press the enter key to continue.");
            Console.ReadLine();            
        }
    }
}
