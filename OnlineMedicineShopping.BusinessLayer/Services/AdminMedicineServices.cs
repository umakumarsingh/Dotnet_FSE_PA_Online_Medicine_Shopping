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
        /// <summary>
        /// Creating referance variable of IAdminMedicineRepository and injecting in Constructor
        /// </summary>
        private readonly IAdminMedicineRepository _aMRepository;

        public AdminMedicineServices(IAdminMedicineRepository adminMedicineRepository)
        {
            _aMRepository = adminMedicineRepository;
        }
        /// <summary>
        /// Add new Doctor in MongoDb Collection
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public async Task<Doctor> AddnewDoctor(Doctor doctor)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing appointment by Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAppointment(string appointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Category by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCategory(string Id)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Doctor by Id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDoctor(string doctorId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Medicine by Id
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteMedicine(string medicineId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all appointment
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all order
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MedicineOrder>> GetAllOrder()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// get order by order Id
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        public async Task<Doctor> GetDoctorById(string DoctorId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get auser by user by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<ApplicationUser> GetUserById(string userId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Category in MongoDb Collection
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> NewCategory(Category category)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new Medicine in MongoDb Collectoin
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public async Task<Medicine> NewMedicine(Medicine medicine)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Appointment by appointment Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task<Appointment> UpdateAppointment(string appointmentId, Appointment appointment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Doctor by Doctor Id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public async Task<Doctor> UpdateDoctor(string doctorId, Doctor doctor)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Medicne by medicine Id
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public async Task<Medicine> UpdateMedicine(string medicineId, Medicine medicine)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing user by user Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> UpdateUser(string userId, ApplicationUser user)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
