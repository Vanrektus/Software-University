using System.Collections.Generic;

namespace ProductShop.Dtos.Output
{
    public class UserAndProductOutputDto
    {
        public int UsersCount { get; set; }

        public IEnumerable<UserInfoDto> Users { get; set; }
    }

    public class UserInfoDto
    {
        public string LastName { get; set; }

        public int? Age { get; set; }

        public SoldProductDto SoldProducts { get; set; }
    }

    public class SoldProductDto
    {
        public int Count { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }

    public class ProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
