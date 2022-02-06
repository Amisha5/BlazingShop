using Blazingshop.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.ServiceContract
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);
        Product InsertProduct(Product product);
        Product UpdateProduct(int id, Product product);
        Product DeleteProduct(int id);
    }
}
