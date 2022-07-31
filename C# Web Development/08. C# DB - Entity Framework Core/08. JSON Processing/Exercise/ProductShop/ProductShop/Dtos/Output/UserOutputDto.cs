using System.Collections.Generic;

namespace ProductShop.Dtos.Output
{
    public class UserOutputDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<UserSoldProductDto> SoldProducts { get; set; }
    }

    public class UserSoldProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string BuyerFirstName { get; set; }

        public string BuyerLastName { get; set; }
    }
}
