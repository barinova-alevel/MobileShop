namespace Basket.Host.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public static ShoppingCart Empty { get; } = new ();

        public List<ShoppingCartItem> Items { get; set; } = new ();

        public decimal TotalPrice
        {
            get
            {
                return Items.Aggregate(0M, (a, item) => a + (item.Price * item.Quantity));
            }
        }

        public int TotalQuantity
        {
            get
            {
                return Items.Aggregate(0, (a, item) => a + item.Quantity);
            }
        }
    }
}
