using Dapper;
using Npgsql;

namespace DapperLesson
{
    internal class DBConnector
    {
        private readonly string _connectionString;

        public DBConnector(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateCustomer(Customer customer)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO customers(id, firstname, lastname, age) VALUES (@Id, @FirstName, @LastName, @Age);";
                connection.Execute(query, customer);
            }
        }

        public void CreateProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO products(id, name, description, stockquantity, price) VALUES (@Id, @Name, @Description, @StockQuantity, @Price);";
                connection.Execute(query, product);
            }
        }

        public void CreateOrder(Order order)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO orders(id, customerid, productid, quantity) VALUES (@Id, @CustomerId, @ProductId, @Quantity);";
                connection.Execute(query, order);
            }
        }
        
        public List<Customer> GetCustomerById(int clientId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM customers WHERE id = @clientId";
                return connection.Query<Customer>(query, new { clientId }).AsList();
            }
        }

        public List<Product> GetProductById(int productId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM products WHERE id = @productId";
                return connection.Query<Product>(query, new { productId }).AsList();
            }
        }

        public List<Order> GetOrderById(int orderId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM orders WHERE id = @orderId";
                return connection.Query<Order>(query, new { orderId }).AsList();
            }
        }

        public List<CustomerToProduct> GetOrderByAgeAndProductId(int age, int productId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT o.customerId, c.firstName, c.lastName, o.productId, p.stockQuantity, p.price FROM public.orders o join public.customers c on c.id = o.customerid join public.products p on p.id = o.productid where c.Age > @age and p.id = @productId";
                return connection.Query<CustomerToProduct>(query, new { age, productId }).AsList();
            }
        }
    }
}
