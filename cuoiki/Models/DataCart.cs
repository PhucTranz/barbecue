namespace cuoiki.Models
{
    using cuoiki.Models;
    using System.Collections.Generic;

    public class DataCart
    {
        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<DetailCart> DetailCarts { get; set; }
        public IEnumerable<Food> Foods { get; set; }
        public IEnumerable<TypeFood> TypeFoods { get; set; }
    }
}
