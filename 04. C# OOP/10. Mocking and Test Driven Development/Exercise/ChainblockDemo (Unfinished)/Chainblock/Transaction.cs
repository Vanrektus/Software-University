using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        //---------------------------Properties---------------------------
        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }
    }
}
