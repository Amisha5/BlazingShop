using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlazingShop.ServiceLayer
{
    public class ProductRepository : IProductRepository
    {
        BlazingContext db;
        public ProductRepository()
        {
            this.db = new BlazingContext();
        }

        public Product DeleteProduct(int id)
        {
            var del = db.Products.Where(e => e.PId == id).FirstOrDefault();
            db.Products.Remove(del);
            db.SaveChanges();
            return del;
        }

        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var byId = db.Products.Where(e => e.PId == id).FirstOrDefault();
            return byId;
        }

        public Product InsertProduct(Product product)
        {
            
            var insert = db.Products.Add(product);
            db.SaveChanges();
            return insert;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var edit = db.Products.Where(e => e.PId == id).FirstOrDefault();
            //var currentImage = Path.Combine(Directory.GetCurrentDirectory(), @"D:\ADM21DF003\BlazingShopProject\BlazingShopProject\Images\", edit.Image);
            edit.ProductName = product.ProductName;
            edit.Price = product.Price;
            edit.ShadeColor = product.ShadeColor;
            edit.CategoryId = product.CategoryId;
            edit.files = product.files;
            db.SaveChanges();
            return edit;
        }
    }
}
