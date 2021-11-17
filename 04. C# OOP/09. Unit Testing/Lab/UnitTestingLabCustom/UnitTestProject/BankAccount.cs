using System;

namespace UnitTestProject
{
    public class BankAccount
    {
        //---------------------------Fields---------------------------
        private decimal amount;

        //---------------------------Properties---------------------------
        public decimal Amount
        {
            get
            {
                return amount;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Amount cannot be negative!");
                }

                amount = value;
            }
        }

        //---------------------------Constructors---------------------------
        public BankAccount(decimal amount)
        {
            this.Amount = amount;
        }

        //---------------------------Methods---------------------------
        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be more than 0!");
            }

            this.Amount += depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0)
            {
                throw new InvalidOperationException("Withdraw amount must be more than 0!");
            }

            this.Amount -= withdrawAmount;
        }
    }
}
