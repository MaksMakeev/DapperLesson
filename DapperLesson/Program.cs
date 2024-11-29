namespace DapperLesson
{
    internal class Program
    {
        static DBConnector dbConnector = new DBConnector("Server=localhost:5432;Database=Shop;User ID=postgres;Password=1488;");
        static void Main(string[] args)
        {
            //Console.WriteLine("Создание покупателя");
            //Console.WriteLine("Введите идентификатор покупателя");
            //var customerId = int.Parse(Console.ReadLine());
            //Console.WriteLine("Введите имя покупателя");
            //var customerFirstName = Console.ReadLine();
            //Console.WriteLine("Введите фамилию покупателя");
            //var customerLastName = Console.ReadLine();
            //Console.WriteLine("Введите возраст покупателя");
            //var customerAge = int.Parse(Console.ReadLine());
            //CreateCustomer(customerId, customerFirstName, customerLastName, customerAge);


            //CreateProduct(12, "Тухлая селедка", "Для настоящих викингов", 67, 30.56f);
            //CreateOrder(10, 10, 10, 3);

            var customers = GetCustomer(10);
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}, {customer.FirstName}, {customer.LastName}, {customer.Age}");
            }

            var products = GetProduct(5);
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.StockQuantity}");
            }

            var orders = GetOrder(3);
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Id}, {order.Quantity}, {order.CustomerId}, {order.ProductId}");
            }

            var otherOrders = GetOrderByAgeAndProductId(30, 1);
            foreach (var order in otherOrders)
            {
                Console.WriteLine($"{order.CustomerID}, {order.FirstName}, {order.LastName}, {order.StockQuantity}, {order.ProductID}, {order.Price}");
            }
        }

        static void CreateCustomer(int id, string firstName, string lastName, int age)
        {
            var customer = new Customer(id, firstName, lastName, age);
            dbConnector.CreateCustomer(customer);
        }

        static void CreateProduct(int id, string name, string description, int stockQuantity, float price)
        {
            var product = new Product(id, name, description, stockQuantity, price);
            dbConnector.CreateProduct(product);
        }

        static void CreateOrder(int id, int customerId, int productId, int quantity)
        {
            var order = new Order(id, customerId, productId, quantity);
            dbConnector.CreateOrder(order);
        }

        static List<Customer> GetCustomer(int id)
        {
            return dbConnector.GetCustomerById(id);
        }

        static List<Product> GetProduct(int id)
        {
            return dbConnector.GetProductById(id);
        }

        static List<Order> GetOrder(int id)
        {
            return dbConnector.GetOrderById(id);
        }

        static List<CustomerToProduct> GetOrderByAgeAndProductId(int age, int productId)
        {
            return dbConnector.GetOrderByAgeAndProductId(age, productId);
        }
    }
}
