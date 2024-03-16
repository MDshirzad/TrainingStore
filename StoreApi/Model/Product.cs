using System.Text.Json.Serialization;

namespace StoreApi.Model
{
    public class Product
    {
        public Product()
        {
            Id = nextId++; // Assign the current value of nextId to Id, then increment nextId
        }
        private static int nextId = 1; // Static field to keep track of the next ID value

        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
