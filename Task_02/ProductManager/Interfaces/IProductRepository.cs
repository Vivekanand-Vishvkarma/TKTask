using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManager.Models;

namespace ProductManager.Interfaces
{
    internal interface IProductRepository
    {
        void AddProduct(Product product);
        void DeleteProductById(int id);
        void UpdateProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
    }
}
