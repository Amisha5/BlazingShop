using Blazingshop.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingShop.ServiceContract
{
    public interface IAppointment
    {
        List<Product> GetProducts();

        Product GetProductById(int id);
        List<Appointment> AppointmentList();

        Appointment DeleteAppointment(int id);

        Appointment UpdateAppointment(int id, Appointment app);
        List<Appointment> GetYourAppointments(string id);
    }
}
