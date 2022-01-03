namespace Restaurant
{
    public class Product
    {
        //---------------------------Properties---------------------------
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        //---------------------------Constructors---------------------------
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
