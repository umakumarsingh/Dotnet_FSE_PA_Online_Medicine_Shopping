using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services.Repository
{
    public interface IMedicineRepository
    {
        //List of method to perform all related operation
        Task<IEnumerable<Medicine>> GetAllMedicine();
        Task<ApplicationUser> RegisterUser(ApplicationUser user);
        Task<Medicine> GetMedicineById(string medicineId);
        Task<IEnumerable<Medicine>> MedicineByName(string name);
        Task<bool> PlaceOrder(string medicineId, string UserId);
        Task<MedicineOrder> GetOrderById(string OrderId);
        Task<Appointment> DoctorAppointment(Appointment appointment);
        Task<Appointment> GetAppointmentById(string appointmentId);
        Task<ApplicationUser> Login(string Email, string password);
        Task<bool> Logout();
        Task<IEnumerable<Doctor>> GetAllDoctor();
        IEnumerable<Doctor> Doctor();
        IList<Category> CategoryList();
    }
}
