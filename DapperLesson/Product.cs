namespace DapperLesson
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public float Price { get; set; }
        public Product(int id, string name, string description, int stockQuantity, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            StockQuantity = stockQuantity;
            Price = price;
        }
    }
}
