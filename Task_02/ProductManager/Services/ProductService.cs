using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Interfaces;
using ProductManager.Models;
using ProductManager.Repositories;

namespace ProductManager.Services
{
    internal class ProductService
    {
        IProductRepository _productRepo;
        public ProductService(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }
        public string AddProduct(Product product)
        {
            if (product.ProductId < 1)
            {
                return "Product id must be greater than 0.";
            }
            else if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return "Product name cant not be empty.";
            }
            else if (product.ProductPrice < 1)
            {

                return "Product price must be greater than 0";
            }
            else if (product.AvailableQuantity < 1)
            {
                return "Availabe quantity must be greater than 0";
            }

            _productRepo.AddProduct(product);
            return "Product added successfully.";
        }
        public string UpdateProduct(Product product)
        {
            if (product.ProductId < 1)
            {
                return "Product id must be greater than 0.";
            }
            else if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return "Product name cant not be empty.";
            }
            else if (product.ProductPrice < 1)
            {

                return "Product price must be greater than 0";
            }
            else if (product.AvailableQuantity < 0)
            {
                return "Availabe quantity can not be negative.";
            }

            _productRepo.UpdateProduct(product);
            return "Product updated successfully.";
        }

        public string DeleteProductById(int id)
        {
            if (id < 1)
            {
                return "Product id must be greater than 0.";
            }
            Product product= _productRepo.GetProductById(id);
            if (product == null)
            {
                return "Product not found.";
            }
            
            _productRepo.DeleteProductById(id);
            return "Product deleted successfully.";
        }
        public IEnumerable<Product> GetProducts()
        {
            return _productRepo.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }
    }
}
