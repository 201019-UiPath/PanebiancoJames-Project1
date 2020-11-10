using GameKingdomDB.Models;
using System.Collections.Generic;

namespace GameKingdomDB.Repos
{
    public interface IProductRepo
    {
        void AddProduct(Product product);

        Product GetProductById(int id);

        Product GetProductByName(string name);

        List<Product> GetAllProducts();

        List<Product> GetAllProductsById(int id);
    }
}