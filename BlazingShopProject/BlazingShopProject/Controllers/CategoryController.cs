using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using BlazingShop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlazingShopProject.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository repo;
        BlazingContext db;
        public CategoryController()
        {
            repo = new CategoryRepository();
            db = new BlazingContext();
        }
        // GET: Category
        public ActionResult GetCategories()
        {
            var allCategory = repo.GetAllCategories();
            return View(allCategory);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            //db.Categories.Add(category);
            //db.SaveChanges();
            var ins = repo.InsertCategory(category);
            return RedirectToAction("GetCategories");
        }
        public ActionResult Edit(int id)
        {
          
            var ed = repo.GetByid(id);
            return View(ed);
        }
        [HttpPost]
        public ActionResult Edit(int id,Category cate)
        {
           
            var editValue = repo.UpdateCategory(id, cate);
            return RedirectToAction("GetCategories");
        }
        
        public ActionResult Delete(int id)
        {
            
            var delCategory = repo.DeleteCategory(id);
            return RedirectToAction("GetCategories");
        }

    }
}