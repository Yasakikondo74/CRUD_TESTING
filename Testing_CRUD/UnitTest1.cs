using System.Diagnostics;

namespace Testing_CRUD
{
    [TestFixture]
    public class CreateTest
    {
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService();
        }

        [Test]
        public void Test01_CreateValidProductWithPositiveIdAndPrice()
        {
            var product = new Product { ID = 1, Name = "Product1", Price = 10.0 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test02_CreateValidProductWithPositiveIdAndPrice_2()
        {
            var product = new Product { ID = 2, Name = "Product2", Price = 20.0 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test03_CreateValidProductWithPositiveIdAndPrice_3()
        {
            var product = new Product { ID = 3, Name = "pd3", Price = 35.5 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test04_CreateValidProductWithPositiveIdAndPrice_4()
        {
            var product = new Product { ID = 4, Name = "4", Price = 104.2 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test05_CreateValidProductWithPositiveIdAndPrice_5()
        {
            var product = new Product { ID = 5, Name = "Product", Price = 2222.2 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test06_CreateValidProductWithPositiveIdAndPrice_6()
        {
            var product = new Product { ID = 60, Name = "pro6", Price = 499.9 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test07_CreateProductWithNegativePrice()
        {
            var product = new Product { ID = 77, Name = "-7", Price = -10.0 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test08_CreateProductWithNegativeIdAndPrice()
        {
            var product = new Product { ID = 888, Name = "-888.2342 product", Price = -222.0 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test09_CreateProductWithNegativeIdAndPositivePrice()
        {
            var product = new Product { ID = -9, Name = "Product-888.2342", Price = 123123.2 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test10_CreateProductWithNegativeIdAndPositivePrice_2()
        {
            var product = new Product { ID = -199, Name = "Product1+1231241", Price = 155.5 };
            _productService.CreateProduct(product);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }
    }

    [TestFixture]
    public class UpdateTest
    {
        private ProductService _productService;
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService();
            _product = new Product { ID = 1, Name = "Product1", Price = 10.0 };
            _productService.CreateProduct(_product);
        }
        [Test]
        public void Test01_UpdateName()
        {
            _product.Name = "NewProductName";
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Name, Is.EqualTo("NewProductName"));
        }

        [Test]
        public void Test02_UpdatePrice()
        {
            _product.Price = 20.0;
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Price, Is.EqualTo(20.0));
        }
        [Test]
        public void Test03_UpdateNonExistentProduct()
        {
            var newProduct = new Product { ID = 2, Name = "NonExistentProduct", Price = 9.99 };
            _productService.UpdateProduct(newProduct);
            Assert.That(_productService.GetProducts().Count(), Is.EqualTo(1));
        }
        [Test]
        public void Test04_UpdateWithInvalidPrice()
        {
            _product.Price = -5.0;
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Price, Is.Not.EqualTo(5.0));
        }
        [Test]
        public void Test05_UpdateWithEmptyName()
        {
            _product.Name = "";
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Name, Is.Empty);
        }

        [Test]
        public void Test06_UpdateWithNullName()
        {
            _product.Name = null;
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Name, Is.Null);
        }

        [Test]
        public void Test07_UpdateWithLongName()
        {
            // Create a very long name
            string longName = new string('a', 101);
            _product.Name = longName;
            _productService.UpdateProduct(_product);
        }

        [Test]
        public void Test08_UpdateWithZeroPrice()
        {
            _product.Price = 0;
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Price, Is.GreaterThan(-1));
        }

        [Test]
        public void Test09_UpdateWithLargePrice()
        {
            _product.Price = double.MaxValue;
            _productService.UpdateProduct(_product);
            Assert.That(_productService.GetProducts().First().Price, Is.EqualTo(double.MaxValue));
        }
        [Test]
        public void Test10_ConcurrentUpdates()
        {
            Task[] tasks = new Task[5];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    var updatedProduct = new Product { ID = _product.ID, Name = "UpdatedName", Price = _product.Price + 1 };
                    _productService.UpdateProduct(updatedProduct);
                });
            }

            Task.WaitAll(tasks);
        }
    }
    [TestFixture]
    public class DeleteProductTest
    {
        private ProductService _productService;
        private Product _product;

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService();
            _product = new Product { ID = 1, Name = "Product1", Price = 10.0 };
            _productService.CreateProduct(_product);
        }

        [Test]
        public void Test01_DeleteProduct_ValidId_ShouldDelete()
        {
            _productService.DeleteProduct(_product.ID);
            Assert.That(0, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test02_DeleteProduct_NonExistentId_ShouldNotDelete()
        {
            _productService.DeleteProduct(10);
            Assert.That(1, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test03_DeleteProduct_EmptyProductList_ShouldNotThrowException()
        {
            _productService.DeleteProduct(_product.ID);
            Assert.That(() => _productService.DeleteProduct(2), Throws.Nothing); // No exception for non-existent product after deletion
        }

        [Test]
        public void Test04_DeleteMultipleProducts_ShouldDeleteAll()
        {
            var product2 = new Product { ID = 2, Name = "Product2", Price = 20.0 };
            var product3 = new Product { ID = 3, Name = "Product3", Price = 30.0 };
            _productService.CreateProduct(product2);
            _productService.CreateProduct(product3);

            _productService.DeleteProduct(_product.ID);
            _productService.DeleteProduct(product2.ID);
            _productService.DeleteProduct(product3.ID);

            Assert.That(0, Is.EqualTo(_productService.GetProducts().Count));
        }

        [Test]
        public void Test05_DeleteProduct_EmptyList_ShouldNotThrowException()
        {
            Assert.That(() => _productService.DeleteProduct(1), Throws.Nothing);
        }

        [Test]
        public void Test06_DeleteProduct_AfterCreatingMultiple_ShouldDeleteCorrectOne()
        {
            var product2 = new Product { ID = 2, Name = "Product2", Price = 20.0 };
            _productService.CreateProduct(product2);

            _productService.DeleteProduct(_product.ID);

            var remainingProducts = _productService.GetProducts();
            Assert.That(remainingProducts.Count, Is.EqualTo(1));
            Assert.That(remainingProducts[0].ID, Is.EqualTo(product2.ID));
        }
        [Test]
        public void Test07_DeleteProduct_CaseSensitivity_ShouldNotDelete()
        {
            _productService.DeleteProduct(_product.ID);
            Assert.That(0, Is.EqualTo(_productService.GetProducts().Count));
        }
        [Test]
        public void Test08_DeleteProduct_WhenConcurrentAccess_ShouldNotCorruptData()
        {
            var task = Task.Run(() => _productService.DeleteProduct(_product.ID));
            _productService.DeleteProduct(_product.ID);
            task.Wait();

            Assert.That(_productService.GetProducts().Count, Is.EqualTo(0));
        }

        [Test]
        public void Test09_DeleteProduct_AfterUpdatingProduct_ShouldDeleteUpdatedProduct()
        {
            _product.Name = "Updated Product";
            _productService.UpdateProduct(_product);

            _productService.DeleteProduct(_product.ID);

            Assert.That(_productService.GetProducts().Count, Is.EqualTo(0));
        }
        [Test]
        public void Test10_DeleteProduct_ByName_NonExistentName_ShouldNotThrowException()
        {
            Assert.That(() => _productService.DeleteProduct(0), Throws.Nothing);
        }

    }
}