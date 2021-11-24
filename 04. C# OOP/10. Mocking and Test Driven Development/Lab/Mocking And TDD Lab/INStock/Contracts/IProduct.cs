namespace INStock.Contracts
{
    using System;

    public interface IProduct : IComparable<IProduct>
    {
        //---------------------------Properties---------------------------
        string Label { get; }

        decimal Price { get; } 

        int Quantity { get;}
    }
}