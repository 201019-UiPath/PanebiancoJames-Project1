using GameKingdomDB.Models;
using GameKingdomDB.Repos;
using System.Collections.Generic;
using System;
using Serilog;

namespace GameKingdomLib
{
    public class ProductService
    {
        private IProductRepo repo;

        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }

        public void AddProduct(Product newProduct)
        {
            repo.AddProduct(newProduct);
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return repo.GetProductByName(name);
        }

        public List<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public List<Product> GetAllProductsById(int id)
        {
            return repo.GetAllProductsById(id);
        }
    }
}