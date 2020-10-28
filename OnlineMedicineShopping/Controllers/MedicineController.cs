using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.ViewModels;
using OnlineMedicineShopping.Entities;

namespace OnlineMedicineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IMedicineServices interface and injecting in MedicineController constructor
        /// </summary>
        private readonly IMedicineServices _medicineServices;
        public MedicineController(IMedicineServices medicine)
        {
            _medicineServices = medicine;
        }
        /// <summary>
        /// Get all medicine for buyer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Medicine>> AllMedicine()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Medicine by Id and show medicine details
        /// </summary>
        /// <param name="medicineId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MedicineById/{MedicineId}")]
        public async Task<IActionResult> MedicineById(string medicineId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get or find medicine by Medicine Name
        /// </summary>
        /// <param name="medicineName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MedicineByName/{Name}")]
        public async Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Place order for Registred user
        /// </summary>
        /// <param name="MedicineId"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Placeorder/{MedicineId}/{email}/{password}")]
        public async Task<IActionResult> Placeorder(string medicineId, string email, string password)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Order for user by Order Id
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("OrderById/{OrderId}")]
        public async Task<IActionResult> OrderById(string OrderId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add/Register new user to portal
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> AddNewUser([FromBody] UserViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book a doctor appointment for F2F Appointment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Appointment")]
        public async Task<IActionResult> BookAppointment([FromBody] AppointmentViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Appointment by id and show to user
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AppointmentById/{AppointmentId}")]
        public async Task<IActionResult> AppointmentById(string AppointmentId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get List of All doctor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoctorList")]
        public async Task<IEnumerable<Doctor>> AllDoctor()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get list of Medicine category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Categorylist")]
        public IActionResult GetCategoryList()
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
