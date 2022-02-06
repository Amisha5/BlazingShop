using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using BlazingShop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlazingShopProject.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        IAppointment repo;
        BlazingContext db;

        public AppointmentController()
        {
            repo = new AppointmentRepository();
            db = new BlazingContext();
        }
       
        public ActionResult GetProduct()
        {
            var getVal=repo.GetProducts();
            return View(getVal);
        }
        [Authorize]
        public ActionResult GetProductById(int id)
        {
            var byId = repo.GetProductById(id);
            return View(byId);
        }
        public ActionResult BookAppointment(int id)
        {
            ViewBag.UserId = User.Identity.Name;


            return View();
        }
        [HttpPost]
        public ActionResult BookAppointment(int id, Appointment app)
        {
            //ViewBag.UserId = User.Identity.Name;
            //string appId = ViewBag.UserId;
            //app.ApplicationUserId = ViewBag.UserId;
            app.ProductId = id;
            db.Appointments.Add(app);
            db.SaveChanges();
            return View("Success");
        }
        public ActionResult AppointmentList()
        {
            var aList = repo.AppointmentList();
            return View(aList);
        }

        public ActionResult DeleteAppointments(int id)
        {
            var appDel = repo.DeleteAppointment(id);
            return RedirectToAction("AppointmentList");
        }
        public ActionResult EditAppointment(int id)
        {
            var getId = db.Appointments.Where(e => e.AId == id).Include(e => e.Product).FirstOrDefault();
            return View(getId);
        }
        [HttpPost]
        public ActionResult EditAppointment(int id,Appointment appointment)
        {
            var appEdit = repo.UpdateAppointment(id, appointment);
            return RedirectToAction("AppointmentList");
        }
        public ActionResult GetYourAppointment()
        {
            ViewBag.Aid = User.Identity.Name;
            string Aid = ViewBag.Aid;
            var yourApplist = repo.GetYourAppointments(Aid);
            return View(yourApplist);
        }
    }
}