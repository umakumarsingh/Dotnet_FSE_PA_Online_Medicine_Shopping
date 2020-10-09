using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services
{
    public class AdminMedicineServices : IAdminMedicineServices
    {
        private readonly IAdminMedicineRepository _aMRepository;

        public AdminMedicineServices(IAdminMedicineRepository adminMedicineRepository)
        {
            _aMRepository = adminMedicineRepository;
        }
        public async Task<Doctor> AddnewDoctor(Doctor doctor)
        {
            var newDoctor = await _aMRepository.AddnewDoctor(doctor);
            return newDoctor;
        }

        public async Task<bool> DeleteAppointment(string appointmentId)
        {
            var result = await _aMRepository.DeleteAppointment(appointmentId);
            return result;
        }

        public async Task<bool> DeleteCategory(string Id)
        {
            var category = await _aMRepository.DeleteCategory(Id);
            return category;
        }

        public async Task<bool> DeleteDoctor(string doctorId)
        {
            var result = await _aMRepository.DeleteDoctor(doctorId);
            return result;
        }

        public async Task<bool> DeleteMedicine(string medicineId)
        {
            var result = await _aMRepository.DeleteMedicine(medicineId);
            return result;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            var appointment = await _aMRepository.GetAllAppointment();
            return appointment;
        }

        public async Task<IEnumerable<MedicineOrder>> GetAllOrder()
        {
            var order = await _aMRepository.GetAllOrder();
            return order;
        }

        public async Task<Doctor> GetDoctorById(string DoctorId)
        {
            var doctor = await _aMRepository.GetDoctorById(DoctorId);
            return doctor;
        }

        public Task<ApplicationUser> GetUserById(string userId)
        {
            var user = _aMRepository.GetUserById(userId);
            return user;
        }

        public async Task<Category> NewCategory(Category category)
        {
            var newCategory = await _aMRepository.NewCategory(category);
            return newCategory;
        }

        public async Task<Medicine> NewMedicine(Medicine medicine)
        {
            var newMedicine = await _aMRepository.NewMedicine(medicine);
            return newMedicine;
        }
        public async Task<Appointment> UpdateAppointment(string appointmentId, Appointment appointment)
        {
            var update = await _aMRepository.UpdateAppointment(appointmentId, appointment);
            return update;
        }

        public async Task<Doctor> UpdateDoctor(string doctorId, Doctor doctor)
        {
            var update = await _aMRepository.UpdateDoctor(doctorId, doctor);
            return update;
        }

        public async Task<Medicine> UpdateMedicine(string medicineId, Medicine medicine)
        {
            var update = await _aMRepository.UpdateMedicine(medicineId, medicine);
            return update;
        }

        public async Task<ApplicationUser> UpdateUser(string userId, ApplicationUser user)
        {
            var update = await _aMRepository.UpdateUser(userId, user);
            return update;
        }
    }
}
