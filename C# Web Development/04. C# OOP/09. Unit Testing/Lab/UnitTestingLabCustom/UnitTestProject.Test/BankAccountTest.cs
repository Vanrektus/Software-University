using NUnit.Framework;

namespace UnitTestProject.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        private BankAccount account;

        [SetUp]
        public void CreateBankAccount()
        {
            account = new BankAccount(1000);
        }

        [Test]
        public void CreateBankAccountWithPositiveAmount()
        {
            Assert.That(account.Amount, Is.EqualTo(1000), "Wrong amount added to account on creation.");
        }

        [Test]
        public void CreateBankAccountWithNegativeAmount()
        {
            Assert.That(() => account = new BankAccount(-50),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Amount cannot be negative!"));
        }

        [Test]
        public void DepositPositiveAmount()
        {
            account.Deposit(500);

            Assert.That(account.Amount, Is.EqualTo(1500), "Wrong amount deposited to account.");
        }

        [Test]
        public void DepositNegativeAmount()
        {
            Assert.That(() => account.Deposit(-50),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Deposit amount must be more than 0!"));
        }
    }
}
