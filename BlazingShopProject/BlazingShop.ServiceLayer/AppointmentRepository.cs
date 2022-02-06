using Blazingshop.DomainModel.Models;
using BlazingShop.DataLayer;
using BlazingShop.ServiceContract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.ServiceLayer
{
    public class AppointmentRepository : IAppointment
    {
        BlazingContext db;
        public AppointmentRepository()
        {
            this.db = new BlazingContext();
        }

        public List<Appointment> AppointmentList()
        {
            var appList = db.Appointments.ToList();
            return appList;
        }

        public Appointment DeleteAppointment(int id)
        {
            var delApp = db.Appointments.Where(e => e.AId == id).FirstOrDefault();
            db.Appointments.Remove(delApp);
            db.SaveChanges();
            return delApp;
        }

        public Product GetProductById(int id)
        {
            var listbyId = db.Products.Where(e=>e.PId==id).Include(c=>c.Category).FirstOrDefault();
            return listbyId;
        }

        public List<Product> GetProducts()
        {
            var list=db.Products.ToList();
            return list;
        }

        public List<Appointment> GetYourAppointments(string Aid)
        {
            var bookAp = db.Appointments.Where(e => e.ApplicationUserId== Aid).ToList();
            return bookAp;
        }

        public Appointment UpdateAppointment(int id, Appointment app)
        {
            var updList = db.Appointments.Where(e => e.AId == id).FirstOrDefault();
            app.IsConfirmed = true;
            updList.IsConfirmed = app.IsConfirmed;
            db.SaveChanges();
            return updList;
        }
    }
}
