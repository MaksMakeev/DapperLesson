namespace DapperLesson
{
    internal class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Order(int id, int customerId, int productId, int quantity)
        {
            Id = id;
            CustomerId = customerId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
