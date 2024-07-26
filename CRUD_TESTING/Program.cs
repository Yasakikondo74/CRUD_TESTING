namespace SimpleCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Products");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Customer");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            p.Customer();
                            break;
                        case 2:
                            p.Employee();
                            break;
                        case 3:
                            p.Customer();
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (choice != 4);
        }
        public string type = "pd";
        static List<Product> products = new List<Product>();
        static List<Employee> employees = new List<Employee>();
        static List<Customer> customers = new List<Customer>();
        public void Employee()
        {
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Read Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            type = "em";
                            Create();
                            break;
                        case 2:
                            type = "em";
                            Read();
                            break;
                        case 3:
                            type = "em";
                            Update();
                            break;
                        case 4:
                            type = "em";
                            Delete();
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (choice != 5);
        }
        public void Customer()
        {
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Read Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            type = "cus";
                            Create();
                            break;
                        case 2:
                            type = "cus";
                            Read();
                            break;
                        case 3:
                            type = "cus";
                            Update();
                            break;
                        case 4:
                            type = "cus";
                            Delete();
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (choice != 5);
        }
        public void Product()
        {
            int choice;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Read Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            type = "pd";
                            Create();
                            break;
                        case 2:
                            type = "pd";
                            Read();
                            break;
                        case 3:
                            type = "pd";
                            Update();
                            break;
                        case 4:
                            type = "pd";
                            Delete();
                            break;
                        case 5:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            } while (choice != 5);
        }

        public void Create()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            double deci = double.Parse(Console.ReadLine());
            if (type == "pd")
            {
                products.Add(new Product { ID = id, Name = name, Price = deci });
                Console.WriteLine("Product created successfully.");
            }
            if (type == "cus")
            {
                customers.Add(new Customer { ID = id, Name = name, Score = deci });
                Console.WriteLine("Customer created successfully.");
            }
            if (type == "em")
            {
                employees.Add(new Employee { ID = id, Name = name, Salary = deci });
                Console.WriteLine("Employee created successfully.");
            }
        }

        public void Read()
        {
            if (type == "pd")
            {
                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                }
                else
                {
                    Console.WriteLine("Products:");
                    foreach (var product in products)
                    {
                        Console.WriteLine($"ID: {product.ID}, Name: {product.Name}, Price: {product.Price}");
                    }
                }
            }
            if (type == "cus")
            {
                if (customers.Count == 0)
                {
                    Console.WriteLine("No customer found.");
                }
                else
                {
                    Console.WriteLine("Customer:");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"ID: {customer.ID}, Name: {customer.Name}, Price: {customer.Score}");
                    }
                }
            }
            if (type == "em")
            {
                if (employees.Count == 0)
                {
                    Console.WriteLine("No employees found.");
                }
                else
                {
                    Console.WriteLine("Employee::");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Price: {employee.Salary}");
                    }
                }
            }
        }

        public void Update()
        {
            if (type == "pd")
            {
                Console.Write("Enter product ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var Update = products.Find(p => p.ID == id);

                if (Update != null)
                {
                    Console.Write("Enter new product name: ");
                    Update.Name = Console.ReadLine();
                    Console.Write("Enter new product price: ");
                    Update.Price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            if (type == "cus")
            {
                Console.Write("Enter customer ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var Update = customers.Find(p => p.ID == id);

                if (Update != null)
                {
                    Console.Write("Enter new customer name: ");
                    Update.Name = Console.ReadLine();
                    Console.Write("Enter new customer score: ");
                    Update.Score = double.Parse(Console.ReadLine());
                    Console.WriteLine("Customer updated successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            if (type == "em")
            {
                Console.Write("Enter employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var Update = employees.Find(p => p.ID == id);

                if (Update != null)
                {
                    Console.Write("Enter new employee name: ");
                    Update.Name = Console.ReadLine();
                    Console.Write("Enter new employee price: ");
                    Update.Salary = double.Parse(Console.ReadLine());
                    Console.WriteLine("Employee updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }

        public void Delete()
        {
            if (type == "pd")
            {
                Console.Write("Enter product ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var Delete = products.Find(p => p.ID == id);

                if (Delete != null)
                {
                    products.Remove(Delete);
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            if (type == "cus")
            {
                Console.Write("Enter customer ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var Delete = customers.Find(p => p.ID == id);

                if (Delete != null)
                {
                    customers.Remove(Delete);
                    Console.WriteLine("Customer deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            if (type == "em")
            {
                Console.Write("Enter employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var Delete = employees.Find(p => p.ID == id);

                if (Delete != null)
                {
                    employees.Remove(Delete);
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
        }
    }

    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }
    }
}
