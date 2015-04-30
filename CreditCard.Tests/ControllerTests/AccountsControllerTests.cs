using CreditCard.CreditCardClass;
using NUnit.Framework;

namespace CreditCard.Tests.ControllerTests
{
    [TestFixture]
    class AccountsControllerTests
    {
        #region " Private Methods "

        private AccountsController _controller;
        
        #endregion

        #region " Setup and Teardown "

        [SetUp]
        public void AccountController_Setup()
        {
            _controller = new AccountsController();
        }

        [TearDown]
        public void AccountController_Teardown()
        {
            _controller = null;
        }

        #endregion

        #region " Tests "

        [Test]
        public void AccountController_Test_InvalidAdd()
        {
            //arrange
            //act
            var setup = _controller.ProcessLine("Quincy 1234567890123456 2000");

            //assert
            Assert.IsFalse(setup);
        }

        [Test]
        public void AccountController_Test_InvalidAdd_Duplicate()
        {
            //arrange
            var setup = _controller.ProcessLine("Add Tom 4111111111111111 $1000");

            //act
            var success = _controller.ProcessLine("Add Tom 3111111111111111 $2000");

            //assert
            Assert.IsTrue(setup);
            Assert.IsFalse(success);
        }

        [Test]
        public void AccountController_Test_TooFewColumns()
        {
            //arrange
            //act
            var setup = _controller.ProcessLine("Add Tom");

            //assert
            Assert.IsFalse(setup);
        }

        [Test]
        public void AccountController_Test_TooMayColumns()
        {
            //arrange
            //act
            var setup = _controller.ProcessLine("Add Tom 4111111111111111 $1000 Awesome");

            //assert
            Assert.IsFalse(setup);
        }

        [Test]
        public void AccountController_Test_DeniedCharge()
        {
            //arrange
            var setup = _controller.ProcessLine("Add Tom 4111111111111111 $1000");

            //act
            var success = _controller.ProcessLine("Charge Tom $1500"); ;

            //assert
            Assert.IsTrue(setup);
            Assert.IsFalse(success);
        }

        [Test]
        public void AccountController_Test_Charge()
        {
            //arrange
            var setup = _controller.ProcessLine("Add Tom 4111111111111111 $1000");

            //act
            var success = _controller.ProcessLine("Charge Tom $500"); ;

            //assert
            Assert.IsTrue(setup);
            Assert.IsTrue(success);
        }

        [Test]
        public void AccountController_Test_Credit()
        {
            //arrange
            var setup = _controller.ProcessLine("Add Tom 4111111111111111 $1000");

            //act
            var success = _controller.ProcessLine("Credit Tom $500"); ;

            //assert
            Assert.IsTrue(setup);
            Assert.IsTrue(success);
        }

        [Test]
        public void AccountController_TestResults()
        {
            //arrange
            _controller.ProcessLine("Add Tom 4111111111111111 $1000");
            _controller.ProcessLine("Add Lisa 5454545454545454 $3000");
            _controller.ProcessLine("Add Quincy 1234567890123456 $2000");
            _controller.ProcessLine("Charge Tom $500");
            _controller.ProcessLine("Charge Tom $800");
            _controller.ProcessLine("Charge Lisa $7");
            _controller.ProcessLine("Credit Lisa $100");
            _controller.ProcessLine("Credit Quincy $200");

            //act
            var output = new TestOutput();
            _controller.Report(output);

            //assert
            Assert.AreEqual(output.Accounts.Count,3);
            Assert.AreEqual(output.Accounts[0].AccountName, "Lisa");
            Assert.AreEqual(output.Accounts[0].Balance, -93);
            Assert.AreEqual(output.Accounts[1].AccountName, "Quincy");
            Assert.AreEqual(output.Accounts[1].IsValid, false);
            Assert.AreEqual(output.Accounts[2].AccountName, "Tom");
            Assert.AreEqual(output.Accounts[2].Balance, 500);

        }

        #endregion
    }
}
