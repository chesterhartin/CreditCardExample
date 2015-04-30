using System.Collections.Generic;
using System.Linq;
using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.EntityTests
{
    [TestFixture]
    class DALTests
    {
        #region " Private "

        private IDAL _account = null;

        #endregion

        #region " Setup and Teardown "

        [SetUp]
        public void DAL_Setup()
        {
            _account = new AccountDAL();
        }

        [TearDown]
        public void DAL_Teardown()
        {
            _account = null;
        }

        #endregion

        #region " Tests "

        [Test]
        public void DAL_Test_InvalidAdd()
        {
            //arrange
            var setup = _account.TryAddAccount(new Account("Quincy", "1234567890123456", 2000));
            //act
            var success = _account.TryAddAccount(new Account("Quincy", "1234567890123456", 2000));
            //assert
            Assert.IsTrue(setup);
            Assert.IsFalse(success);
        }

        [Test]
        public void DAL_Test_ValidAdd()
        {
            //arrange
            var setup = _account.TryAddAccount(new Account("Quincy", "1234567890123456", 2000));
            //act
            Account acct = _account.SelectAccountByName("Quincy");
            //assert
            Assert.IsTrue(setup);
            Assert.AreEqual(acct.AccountName, "Quincy");
            Assert.AreEqual(acct.AccountNumber, "1234567890123456");
            Assert.AreEqual(acct.AccountLimit, 2000);
        }


        [Test]
        public void DAL_Test_SelectByAccountName_Found()
        {
            //arrange
            var setup = _account.TryAddAccount(new Account("Quincy", "1234567890123456", 2000));
            //act
            Account acct = _account.SelectAccountByName("Quincy");
            //assert
            Assert.IsTrue(setup);
            Assert.AreEqual(acct.AccountName, "Quincy");
            Assert.AreEqual(acct.AccountNumber, "1234567890123456");
            Assert.AreEqual(acct.AccountLimit, 2000);
        }


        [Test]
        public void DAL_Test_SelectByAccountName_NotFound()
        {
            //arrange
            var setup = _account.TryAddAccount(new Account("Quincy", "1234567890123456", 2000));
            //act
            Account acct = _account.SelectAccountByName("Tom");
            //assert
            Assert.IsTrue(setup);
            Assert.IsNull(acct);
        }

        [Test]
        public void DAL_Test_SelectAll()
        {

            //arrange
            Account quincy = new Account("Quincy", "1234567890123456", 2000);
            Account tom = new Account("Tom", "4111111111111111", 1000);
            Account lisa = new Account("Lisa", "5454545454545454", 3000);

            List<Account> account = new List<Account>();
            
            //act
            _account.TryAddAccount(quincy);
            _account.TryAddAccount(tom);
            _account.TryAddAccount(lisa);

            account.Add(quincy);
            account.Add(tom);
            account.Add(lisa);

            //assert
            Assert.AreEqual(_account.SelectAllAccounts().Count(), account.Count);
            Assert.AreEqual(_account.SelectAllAccounts().Except(account).Count(), account.Except(_account.SelectAllAccounts()).Count());
            Assert.AreEqual(_account.SelectAllAccounts().Intersect(account).Count(), account.Intersect(_account.SelectAllAccounts()).Count());
        }

        #endregion
    }
}
