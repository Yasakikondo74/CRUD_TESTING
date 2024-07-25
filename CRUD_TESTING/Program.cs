namespace SimpleCRUD
{
    public class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
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
                            CreateProduct();
                            break;
                        case 2:
                            ReadProducts();
                            break;
                        case 3:
                            UpdateProduct();
                            break;
                        case 4:
                            DeleteProduct();
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

        static void CreateProduct()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            double price = double.Parse(Console.ReadLine());

            products.Add(new Product { ID = id, Name = name, Price = price });
            Console.WriteLine("Product created successfully.");
        }

        static void ReadProducts()
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

        static void UpdateProduct()
        {
            Console.Write("Enter product ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var productToUpdate = products.Find(p => p.ID == id);

            if (productToUpdate != null)
            {
                Console.Write("Enter new product name: ");
                productToUpdate.Name = Console.ReadLine();
                Console.Write("Enter new product price: ");
                productToUpdate.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Enter product ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var productToDelete = products.Find(p => p.ID == id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }

    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
