using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Interfaces;
using ProductManager.Models;

namespace ProductManager.Repositories
{
    internal class ProductRepository:IProductRepository
    {
        List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>();
        }
       
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProductById(int id) 
        {
            Product product = GetProductById(id);
            if(product != null)
            {
                products.Remove(product);
            }
        }

        public void UpdateProduct(Product product) {
            Product existingProduct = GetProductById(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.AvailableQuantity = product.AvailableQuantity;
            }
        }

        public Product GetProductById(int id)
        {            
            foreach (Product product in products)
            {
                if (product.ProductId == id)
                {
                    return product;
                }
            }
            return null;
        }

        public IEnumerable<Product> GetProducts()
        {
            foreach (Product product in products)
            {
                yield return product;
            }
        }
    }
}
