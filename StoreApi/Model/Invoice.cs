namespace StoreApi.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public int[] ProductsId { get; set; }
        public int UserId {  get; set; }    
        public decimal totalPrice { get; set; }

    }
}
