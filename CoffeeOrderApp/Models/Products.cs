namespace CoffeeOrderApp.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public int categoryId { get; set; }
        public int price { get; set;}
    }
}
