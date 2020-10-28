using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services
{
    public class MedicineServices : IMedicineServices
    {
        /// <summary>
        /// Creating referance variable of IMedicineRepository and injecting in Constructor
        /// </summary>
        private readonly IMedicineRepository _medicineRepository;

        public MedicineServices(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        /// <summary>
        /// Get category list from Collection
        /// </summary>
        /// <returns></returns>
        public IList<Category> CategoryList()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get list of doctor from Collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Doctor> Doctor()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Take a new Appointment and add details in MongoDb Collection
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public Task<Appointment> DoctorAppointment(Appointment appointment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all doctor from mongoDb Collection
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all medicine from MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Medicine>> GetAllMedicine()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get an appointment by Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        public Task<Appointment> GetAppointmentById(string appointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Medicne by Medicine Id
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        public Task<Medicine> GetMedicineById(string medicineId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Order by OrderId
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public Task<MedicineOrder> GetOrderById(string OrderId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Login Existring User to place order
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ApplicationUser> Login(string Email, string password)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Log out user
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get medicine by Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place order and verify user and save oder detail in Db
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Task<bool> PlaceOrder(string medicineId, string UserId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
