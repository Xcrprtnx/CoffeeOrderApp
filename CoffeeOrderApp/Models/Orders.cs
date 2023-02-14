using System.Collections.Generic;

namespace CoffeeOrderApp.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int deskId { get; set; }
        public List<Products> productList { get; set; }

    }
}
