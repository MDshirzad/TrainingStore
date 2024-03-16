using StoreApi.Model;

namespace StoreApi.Repo
{
    public static class DbContext
    {

        public static List<User> Users()
        {
            List<User> users = new()
            {
                new User {Id=1, Name="Hossein Mohammadi" },
                new User {Id=2, Name="Ali Ahmadi" },
                new User {Id=3, Name="Reza Sadeghi" }

            };
            return users;
        }

        public static List<Product> Products()
        {
            var Products =  new List<Product>() { new() { Name = "Tablet", Price = 15000000, Id = 1 , Quantity=10}, new() { Name = "Mobile", Price = 20000000, Id = 2, Quantity = 13 }, new() { Name = "Laptop", Price = 30000000, Id = 3, Quantity = 19 } };
            return Products;
        }


        public static List<DiscountCode> DiscountCodes()
        {
            var discountcodes = new List<DiscountCode>() { new() { Id = 1, Percentage = 20, Name = "20per", forProduct = 1 }, new() { Id = 2, Percentage = 10, Name = "10per", forProduct = 2 }, new() { Id = 3, Percentage = 50, Name = "50per", forProduct = 3 } };
            return discountcodes;
        }

        public static List<Invoice> Invoices()
        {
            var Invoices = new List<Invoice>() { new() { Id = 1, ProductsId = [1, 2],UserId=1 }, new() { Id = 2, ProductsId = [3, 2] ,UserId=2} };
            return Invoices;
        }

    }
}
