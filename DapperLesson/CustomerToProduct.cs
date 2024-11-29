namespace DapperLesson
{
    internal class CustomerToProduct
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProductID { get; set; }
        public int StockQuantity { get; set; }
        public float Price { get; set; }
        public CustomerToProduct(int customerId, string firstName, string lastName, int productId, int stockQuantity, float price)
        {
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            ProductID = productId;
            StockQuantity = stockQuantity;
            Price = price;
        }
    }
}
