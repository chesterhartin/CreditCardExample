using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.EntityTests
{
    [TestFixture]
    class AccountTests
    {
        #region " Setup and Teardown "

        [SetUp]
        public void Account_Setup()
        {
            //intentionally left blank for this test
        }

        [TearDown]
        public void Account_Teardown()
        {
            //intentionally left blank for this test
        }

        #endregion

        #region " Tests "

        [Test]
        public void Account_Test_InvalidAdd()
        {
            //arrange
            //act
            var acct = new Account("Quincy", "1234567890123456", 2000);

            //assert
            Assert.IsFalse(acct.IsValid);
        }

        [Test]
        public void Account_Test_InvalidCharge()
        {
            //arrange
            var acct = new Account("Quincy", "1234567890123456", 2000);
            //act
            var success = acct.TryChargeAccount(1000);
            //assert
            Assert.IsFalse(acct.IsValid);
            Assert.IsFalse(success);
        }

        [Test]
        public void Account_Test_InvalidCredit()
        {
            //arrange
            var acct = new Account("Quincy", "1234567890123456", 2000);
            //act
            var success = acct.TryCreditAccount(1000);
            //assert
            Assert.IsFalse(acct.IsValid);
            Assert.IsFalse(success);
        }

        [Test]
        public void Account_Test_ValidAdd()
        {
            //arrange
            //act
            var acct = new Account("Tom", "4111111111111111", 1000);

            //assert
            Assert.AreEqual(acct.AccountLimit, 1000);
            Assert.AreEqual(acct.AccountName, "Tom");
            Assert.AreEqual(acct.AccountNumber, "4111111111111111");
            Assert.IsTrue(acct.IsValid);
        }

        [Test]
        public void Account_Test_ValidCharge()
        {
            //arrange
            var acct = new Account("Tom", "4111111111111111", 1000);

            //act
            var success = acct.TryChargeAccount(500);

            //assert
            Assert.AreEqual(acct.AccountLimit, 1000);
            Assert.AreEqual(acct.AccountName,"Tom");
            Assert.AreEqual(acct.AccountNumber, "4111111111111111");
            Assert.AreEqual(acct.Balance,500);
            Assert.IsTrue(acct.IsValid);
            Assert.IsTrue(success);
        }

        [Test]
        public void Account_Test_DeniedCharge()
        {
            //arrange
            var acct = new Account("Tom", "4111111111111111", 1000);

            //act
            var success = acct.TryChargeAccount(1500);

            //assert
            Assert.AreEqual(acct.AccountLimit, 1000);
            Assert.AreEqual(acct.AccountName, "Tom");
            Assert.AreEqual(acct.AccountNumber, "4111111111111111");
            Assert.AreEqual(acct.Balance, 0);
            Assert.IsTrue(acct.IsValid);
            Assert.IsFalse(success);
        }

        [Test]
        public void Account_Test_ValidCredit()
        {
            //arrange
            var acct = new Account("Tom", "4111111111111111", 1000);

            //act
            var success = acct.TryCreditAccount(500);

            //assert
            Assert.AreEqual(acct.AccountLimit, 1000);
            Assert.AreEqual(acct.AccountName, "Tom");
            Assert.AreEqual(acct.AccountNumber, "4111111111111111");
            Assert.AreEqual(acct.Balance, -500);
            Assert.IsTrue(acct.IsValid);
            Assert.IsTrue(success);
        }

        #endregion

    }
}
