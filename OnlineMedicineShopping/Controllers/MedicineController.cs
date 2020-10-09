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
            return await _medicineServices.GetAllMedicine();
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getmedicine = await _medicineServices.GetMedicineById(medicineId);
            if (getmedicine == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllMedicine", new { OrderId = getmedicine.MedicineId }, getmedicine);
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
            return await _medicineServices.MedicineByName(name);
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _medicineServices.Login(email, password);
            if (result != null)
            {
                await _medicineServices.PlaceOrder(medicineId, result.UserId);
            }
            return Ok("Order Placed...");
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getorder = await _medicineServices.GetOrderById(OrderId);
            if (getorder == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllOrder", new { OrderId = getorder.OrderId }, getorder);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser newuser = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                MobileNumber = model.MobileNumber,
                PinCode = model.PinCode,
                HouseNo_Building_Name = model.HouseNo_Building_Name,
                Road_area = model.Road_area,
                City = model.City,
                State = model.State
            };
            await _medicineServices.RegisterUser(newuser);
            return Ok("User Addeed...");
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Appointment newuser = new Appointment
            {
                PatientName = model.PatientName,
                DoctorName = model.DoctorName,
                Takendate = model.Takendate,
                Symtoms = model.Symtoms,
                Remark = model.Remark,
                PatientAge = model.PatientAge
            };
            await _medicineServices.DoctorAppointment(newuser);
            return Ok("Appointment Addeed...");
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getappointment = await _medicineServices.GetAppointmentById(AppointmentId);
            if (getappointment == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllMedicine", new { AppointmentId = getappointment.AppointmentId }, getappointment);
        }
        /// <summary>
        /// Get List of All doctor
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DoctorList")]
        public async Task<IEnumerable<Doctor>> AllDoctor()
        {
            return await _medicineServices.GetAllDoctor();
        }
        /// <summary>
        /// Get list of Medicine category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Categorylist")]
        public IActionResult GetCategoryList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getcategory = _medicineServices.CategoryList();
            if (getcategory == null)
            {
                return NotFound();
            }
            return CreatedAtAction("AllMedicine", getcategory);
        }
    }
}
