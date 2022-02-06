using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.ServiceLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        BlazingContext db;
        public CategoryRepository()
        {
            this.db = new BlazingContext();
        }

        

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetByid(int id)
        {
            var byId = db.Categories.Where(e => e.CId == id).FirstOrDefault();
            return byId;
        }
        
        public Category UpdateCategory(int id, Category category)
        {
            var eds = db.Categories.Where(e => e.CId == id).FirstOrDefault();
            eds.CategoryName = category.CategoryName;
            db.SaveChanges();
            return eds;
        }
        public Category DeleteCategory(int id)
        {
            var del = db.Categories.Where(e => e.CId == id).FirstOrDefault();
            db.Categories.Remove(del);
            db.SaveChanges();
            return del;
        }

        public Category InsertCategory(Category ct)
        {
            var insert=db.Categories.Add(ct);
            db.SaveChanges();
            return insert;
        }
    }
}
