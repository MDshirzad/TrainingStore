namespace StoreApi.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public decimal totalPrice { get; set; }

    }
}
