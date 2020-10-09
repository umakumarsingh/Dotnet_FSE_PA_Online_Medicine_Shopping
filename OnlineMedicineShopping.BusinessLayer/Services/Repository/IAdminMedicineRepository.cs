using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services.Repository
{
    public interface IAdminMedicineRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointment();
        Task<IEnumerable<MedicineOrder>> GetAllOrder();
        Task<Doctor> AddnewDoctor(Doctor doctor);
        Task<Doctor> GetDoctorById(string DoctorId);
        Task<Doctor> UpdateDoctor(string doctorId, Doctor doctor);
        Task<bool> DeleteDoctor(string doctorId);
        Task<ApplicationUser> UpdateUser(string userId, ApplicationUser user);
        Task<ApplicationUser> GetUserById(string userId);
        Task<Medicine> NewMedicine(Medicine medicine);
        Task<Medicine> UpdateMedicine( string medicineId, Medicine medicine);
        Task<bool> DeleteMedicine(string medicineId);
        Task<Category> NewCategory(Category category);
        Task<bool> DeleteCategory(string Id);
        Task<Appointment> UpdateAppointment(string appointmentId, Appointment appointment);
        Task<bool> DeleteAppointment(string appointmentId);
    }
}
