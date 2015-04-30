using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.ExtensionTests
{
    [TestFixture]
    class StringExtensionsTests
    {
        #region " Private Strings "
        
        //setup

        /// <summary>
        /// An empty string
        /// </summary>
        private string emptyNumber = string.Empty;

        /// <summary>
        /// A non-standard numerical format
        /// </summary>
        private string nonArabicCardNumber = "٠١٢٣٤٥٦٧٨٩";

        /// <summary>
        /// An invalid length, valid Luhn
        /// </summary>
        private string invalidLengthTwoValidLuhn = "18";

        /// <summary>
        /// An invalid length, invalid Luhn
        /// </summary>
        private string invalidLengthTwentyInvalidLuhn = "12345678901234567890";

        /// <summary>
        /// An invalid length, invalid Luhn
        /// </summary>
        private string invalidLengthTwoInvalidLuhn = "12";

        /// <summary>
        /// A valid length number, non-valid Lunh10
        /// </summary>
        private string validLengthNinteenInvalidLuhn = "123456789012345678";

        /// <summary>
        /// An valid length, valid Luhn
        /// </summary>
        private string validLengthSixteenValidLuhn = "4111111111111111";

        /// <summary>
        /// A verified invalid card number
        /// </summary>
        private string validLengthTenInvalidLuhn = "7992739871";

        /// <summary>
        /// A valid lengthm non-valid Lunh10
        /// </summary>
        private string validLengthThreeInvalidLuhn = "123";

        /// <summary>
        /// An valid length, valid Luhn
        /// </summary>
        private string validLengthThreeValidLuhn = "810";

        #endregion

        #region " Setup and Teardown "

        [SetUp]
        public void StringExtension_Setup()
        {
            //intentionally left blank for this test
        }

        [TearDown]
        public void StringExtension_Teardown()
        {
            //intentionally left blank for this test
        }

        #endregion

        #region " Tests "

        [Test]
        public void StringExtensions_Test_IsValidCard()
        {
            //test the Card validity
            Assert.False(emptyNumber.IsValidCard());
            Assert.False(nonArabicCardNumber.IsValidCard());
            Assert.False(invalidLengthTwentyInvalidLuhn.IsValidCard());
            Assert.False(invalidLengthTwoInvalidLuhn.IsValidCard());
            Assert.False(validLengthNinteenInvalidLuhn.IsValidCard());
            Assert.False(validLengthTenInvalidLuhn.IsValidCard());
            Assert.False(validLengthThreeInvalidLuhn.IsValidCard());
            Assert.False(invalidLengthTwoValidLuhn.IsValidCard());

            Assert.True(validLengthSixteenValidLuhn.IsValidCard());
            Assert.True(validLengthThreeValidLuhn.IsValidCard());
        }
        
        #endregion
    }
}
