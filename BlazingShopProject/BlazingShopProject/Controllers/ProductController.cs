using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using BlazingShop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BlazingShopProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IProductRepository repo;
        BlazingContext db;
        public ProductController()
        {
            repo = new ProductRepository();
            db = new BlazingContext();
        }

        public ActionResult GetAllProduct()
        {
            var allProduct=repo.GetAllProducts();
            return View(allProduct);
        }
        public ActionResult DeleteProducts(int id)
        {
            var delete = repo.DeleteProduct(id);
            return RedirectToAction("GetAllProduct");
        }
        public ActionResult EditProduct(int id)
        {
            
            //ViewBag.Name = User.Identity.Name;
            ViewBag.Cat = db.Categories.ToList();
            var edits = repo.GetProductById(id);
            return View(edits);
        }
        [HttpPost]
        public ActionResult EditProduct(int id,Product product, HttpPostedFileBase file)
        {
            ViewBag.Cat = db.Categories.ToList();
            if (file != null)
            {
                product.files = new byte[file.ContentLength];

                file.InputStream.Read(product.files, 0, file.ContentLength);
                var edit = repo.UpdateProduct(id, product);
            }
            return RedirectToAction("GetAllProduct"); ;
        }
        public ActionResult Insert()
        {
            ViewBag.Cat = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Product p, HttpPostedFileBase file)
        {

            if (file != null)
            {
                p.files = new byte[file.ContentLength];
                file.InputStream.Read(p.files, 0, file.ContentLength);
                var insert = db.Products.Add(p);
                db.SaveChanges();
            }
           
            return RedirectToAction("GetAllProduct"); 
            
        }
    }
}