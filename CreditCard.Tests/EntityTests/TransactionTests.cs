using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.EntityTests
{
    [TestFixture]
    class TransactionTests
    {        
        #region " Setup and Teardown "
        [SetUp]
        public void Transaction_Setup()
        {
            //intentionally left blank for this test
        }

        [TearDown]
        public void Transaction_Teardown()
        {
            //intentionally left blank for this test
        }
        #endregion

        #region " Tests "
        [Test]
        public void Transaction_Test_InvalidAdd()
        {
            //arrange
            var testTransaction = "Add Tom 4111111111111111 1000";
            //act
            var t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.AccountNumber, "4111111111111111");
            Assert.AreEqual(t.Action, "add");
            Assert.AreEqual(t.AccountName, "Tom");
            Assert.AreEqual(t.AccountLimit, 0);
        }


        [Test]
        public void Transaction_Test_ValidAdd()
        {
            //arrange
            var testTransaction = "Add Tom 4111111111111111 $1000";
            //act
            var t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.AccountNumber, "4111111111111111");
            Assert.AreEqual(t.Action, "add");
            Assert.AreEqual(t.AccountName, "Tom");
            Assert.AreEqual(t.AccountLimit, 1000);
        }

        [Test]
        public void Transaction_Test_ValidCharge()
        {
            //arrange
            var testTransaction = "CHARGE Tom $1000";
            //act
            Transaction t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.Action, "charge");
            Assert.AreEqual(t.AccountName, "Tom");
            Assert.AreEqual(t.Amount, 1000);
        }

        [Test]
        public void Transaction_Test_ValidCredit()
        {
            //arrange
            var testTransaction = "CREDIT Tom $1000";
            //act
            Transaction t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.Action, "credit");
            Assert.AreEqual(t.AccountName, "Tom");
            Assert.AreEqual(t.Amount, 1000);
        }

        [Test]
        public void Transaction_Test_InvalidAction()
        {
            //arrange
            var testTransaction = "Highfive Jim $1000";
            //act
            Transaction t = new Transaction(testTransaction);
            //assert
            //assert
            Assert.AreEqual(t.IsValidTransaction, false);
        }

        [Test]
        public void Transaction_Test_ToofewColumns()
        {
            //arrange
            var testTransaction = "Add Tom";
            //act
            Transaction t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.IsValidTransaction,false);
        }

        [Test]
        public void Transaction_Test_TooManyColumns()
        {
            //arrange
            var testTransaction = "Add Tom 4111111111111111 $1000 Awesome";
            //act
            var t = new Transaction(testTransaction);
            //assert
            Assert.AreEqual(t.IsValidTransaction, false);
        }

        #endregion

    }
}
