using App.Models;

namespace App.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            Add(new ProductModel
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description 1",
                Price = 100,
                Quantity = 10,
                Image = "Image 1",
                Category = "Category 1"
            });
            Add(new ProductModel
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2",
                Price = 200,
                Quantity = 20,
                Image = "Image 2",
                Category = "Category 2"
            });
            Add(new ProductModel
            {
                Id = 3,
                Name = "Product 3",
                Description = "Description 3",
                Price = 300,
                Quantity = 30,
                Image = "Image 3",
                Category = "Category 3"
            });
            Add(new ProductModel
            {
                Id = 4,
                Name = "Product 4",
                Description = "Description 4",
                Price = 400,
                Quantity = 40,
                Image = "Image 4",
                Category = "Category 4"
            });
            Add(new ProductModel
            {
                Id = 5,
                Name = "Product 5",
                Description = "Description 5",
                Price = 500,
                Quantity = 50,
                Image = "Image 5",
                Category = "Category 5"
            });
        }
    }
}