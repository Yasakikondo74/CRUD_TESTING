using SimpleCRUD;
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }
}
public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }
}

public class ProductService
{
    private List<Product> products = new List<Product>();
    private List<Employee> employees = new List<Employee>();
    private List<Customer> customers = new List<Customer>();
    public void CreateProduct(Product product)
    {
        products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return products;
    }

    public void UpdateProduct(Product product)
    {
        var existing = products.FirstOrDefault(p => p.ID == product.ID);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Price = product.Price;
        }
    }

    public void DeleteProduct(int? id)
    {
        var Delete = products.FirstOrDefault(p => p.ID == id);
        if (Delete != null)
        {
            products.Remove(Delete);
        }
    }
    public void CreateEmpoloyee(Employee employee)
    {
        employees.Add(employee);
    }

    public List<Employee> GetEmployees()
    {
        return employees;
    }

    public void UpdateEmployee(Employee employee)
    {
        var existing = employees.FirstOrDefault(p => p.ID == employee.ID);
        if (existing != null)
        {
            existing.Name = employee.Name;
            existing.Salary = employee.Salary;
        }
    }

    public void DeleteEmployee(int? id)
    {
        var Delete = employees.FirstOrDefault(p => p.ID == id);
        if (Delete != null)
        {
            employees.Remove(Delete);
        }
    }
    public void CreateCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public List<Customer> GetCustomers()
    {
        return customers;
    }

    public void UpdateCustomer(Customer customer)
    {
        var existing = customers.FirstOrDefault(p => p.ID == customer.ID);
        if (existing != null)
        {
            existing.Name = customer.Name;
            existing.Score = customer.Score;
        }
    }

    public void DeleteCustomer(int? id)
    {
        var Delete = customers.FirstOrDefault(p => p.ID == id);
        if (Delete != null)
        {
            customers.Remove(Delete);
        }
    }
}
