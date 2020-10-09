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
        private readonly IMedicineRepository _medicineRepository;

        public MedicineServices(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }
        public IList<Category> CategoryList()
        {
            var catlist = _medicineRepository.CategoryList();
            return catlist;
        }

        public IEnumerable<Doctor> Doctor()
        {
            var doctor = _medicineRepository.Doctor();
            return doctor;
        }

        public Task<Appointment> DoctorAppointment(Appointment appointment)
        {
            var appoint = _medicineRepository.DoctorAppointment(appointment);
            return appoint;
        }

        public Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var alldoctor = _medicineRepository.GetAllDoctor();
            return alldoctor;
        }

        public Task<IEnumerable<Medicine>> GetAllMedicine()
        {
            var medicine = _medicineRepository.GetAllMedicine();
            return medicine;
        }

        public Task<Appointment> GetAppointmentById(string appointmentId)
        {
            var appoint = _medicineRepository.GetAppointmentById(appointmentId);
            return appoint;
        }

        public Task<Medicine> GetMedicineById(string medicineId)
        {
            var medicine = _medicineRepository.GetMedicineById(medicineId);
            return medicine;
        }

        public Task<MedicineOrder> GetOrderById(string OrderId)
        {
            var order = _medicineRepository.GetOrderById(OrderId);
            return order;
        }

        public Task<ApplicationUser> Login(string Email, string password)
        {
            var user = _medicineRepository.Login(Email, password);
            return user;
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            var medicine = _medicineRepository.MedicineByName(name);
            return medicine;
        }

        public Task<bool> PlaceOrder(string medicineId, string UserId)
        {
            var order = _medicineRepository.PlaceOrder(medicineId, UserId);
            return order;
        }
        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            var newUser = await _medicineRepository.RegisterUser(user);
            return newUser;
        }
    }
}
