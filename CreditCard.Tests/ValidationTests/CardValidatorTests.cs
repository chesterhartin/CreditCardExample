using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.ValidationTests
{
    [TestFixture]
    class CardValidatorTests
    {
        #region " Private Strings "
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
        public void CardValidator_Test_IsValidLength()
        {
            //Test the length of the given string
            Assert.False(CardValidator.IsValidLength(emptyNumber));
            Assert.False(CardValidator.IsValidLength(invalidLengthTwoValidLuhn));
            Assert.False(CardValidator.IsValidLength(invalidLengthTwentyInvalidLuhn));
            Assert.False(CardValidator.IsValidLength(invalidLengthTwoInvalidLuhn));

            Assert.True(CardValidator.IsValidLength(nonArabicCardNumber));
            Assert.True(CardValidator.IsValidLength(validLengthNinteenInvalidLuhn));
            Assert.True(CardValidator.IsValidLength(validLengthSixteenValidLuhn));
            Assert.True(CardValidator.IsValidLength(validLengthTenInvalidLuhn));
            Assert.True(CardValidator.IsValidLength(validLengthThreeInvalidLuhn));
            Assert.True(CardValidator.IsValidLength(validLengthThreeValidLuhn));
        }

        [Test]
        public void CardValidator_Test_IsValidLuhn()
        {
            //test the Luhn validity of the given string
            Assert.False(CardValidator.IsValidLuhn10(emptyNumber));
            Assert.False(CardValidator.IsValidLuhn10(nonArabicCardNumber));
            Assert.False(CardValidator.IsValidLuhn10(invalidLengthTwentyInvalidLuhn));
            Assert.False(CardValidator.IsValidLuhn10(invalidLengthTwoInvalidLuhn));
            Assert.False(CardValidator.IsValidLuhn10(validLengthNinteenInvalidLuhn));
            Assert.False(CardValidator.IsValidLuhn10(validLengthTenInvalidLuhn));
            Assert.False(CardValidator.IsValidLuhn10(validLengthThreeInvalidLuhn));

            Assert.True(CardValidator.IsValidLuhn10(invalidLengthTwoValidLuhn));
            Assert.True(CardValidator.IsValidLuhn10(validLengthSixteenValidLuhn));
            Assert.True(CardValidator.IsValidLuhn10(validLengthThreeValidLuhn));
        }

        #endregion

    }
}
