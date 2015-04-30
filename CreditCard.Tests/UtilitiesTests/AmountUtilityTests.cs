using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.UtilitiesTests
{
    /// <summary>
    /// This tests the Amount Utility functions
    /// </summary>
    [TestFixture]
    class AmountUtilityTests
    {
        #region " Private Strings "

        /// <summary>
        /// An invalid 0 currency
        /// </summary>
        private string invalid0Currency = "0";

        /// <summary>
        /// An invalid 100 currency
        /// </summary>
        private string invalid100Currency = "100";

        /// <summary>
        /// An invalid Max currency
        /// </summary>
        private string invalidMaxCurrency = int.MaxValue.ToString();

        /// <summary>
        /// A valid $0 currency
        /// </summary>
        private string valid0Currency = "$0";

        /// <summary>
        /// A valid $100 currency
        /// </summary>
        private string valid100Currency = "$100";

        /// <summary>
        /// A valid $Max currency
        /// </summary>
        private string validMaxCurrency = "$" + int.MaxValue;
        
        #endregion

        #region " Setup and Teardown "
        [SetUp]
        public void CardValidator_Setup()
        {
            //intentionally left blank for this test
        }

        [TearDown]
        public void CardValidator_Teardown()
        {
            //intentionally left blank for this test
        }
        #endregion

        #region " Tests "
        [Test]
        public void AmountUtility_Test_TryStripCurrency()
        {
            int testNum;
            Assert.True(AmountUtility.TryStripCurrency(valid0Currency, out testNum));
            Assert.AreEqual(testNum, 0);
            Assert.True(AmountUtility.TryStripCurrency(valid100Currency, out testNum));
            Assert.AreEqual(testNum, 100);
            Assert.True(AmountUtility.TryStripCurrency(validMaxCurrency, out testNum));
            Assert.AreEqual(testNum, int.MaxValue);

            Assert.False(AmountUtility.TryStripCurrency(invalid0Currency, out testNum));
            Assert.False(AmountUtility.TryStripCurrency(invalid100Currency, out testNum));
            Assert.False(AmountUtility.TryStripCurrency(invalidMaxCurrency, out testNum));
        }

        #endregion

    }
}
