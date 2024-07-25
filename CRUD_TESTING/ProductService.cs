using SimpleCRUD;
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}

public class ProductService
{
    private List<Product> products = new List<Product>();

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
        var existingProduct = products.FirstOrDefault(p => p.ID == product.ID);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        }
    }

    public void DeleteProduct(int? id)
    {
        var productToDelete = products.FirstOrDefault(p => p.ID == id);
        if (productToDelete != null)
        {
            products.Remove(productToDelete);
        }
    }
}
