namespace Chainblock.Contracts
{
    using System;

    public interface ITransaction
    {
        //---------------------------Properties---------------------------
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        double Amount { get; set; }
    }
}