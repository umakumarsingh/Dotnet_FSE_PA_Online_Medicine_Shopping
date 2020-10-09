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
    public class AdminController : ControllerBase
    {
        private readonly IAdminMedicineServices _AMServices;
        private readonly IMedicineServices _MServices;
        public AdminController(IAdminMedicineServices adminMedicineServices, IMedicineServices MServices)
        {
            _AMServices = adminMedicineServices;
            _MServices = MServices;
        }
        /// <summary>
        /// Get all order that place by user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<MedicineOrder>> AllOrder()
        {
            return await _AMServices.GetAllOrder();
        }
        /// <summary>
        /// Get all appointment placed by user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllAppointment")]
        public async Task<IEnumerable<Appointment>> AllAppointment()
        {
            return await _AMServices.GetAllAppointment();
        }
        /// <summary>
        /// Add new doctor for appointment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddNewDoctor([FromBody] DoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Doctor newdoctor = new Doctor
            {
                Name = model.Name,
                Specialization = model.Specialization,
                Qualification = model.Qualification,
                PracticingFrom = model.PracticingFrom
            };
            await _AMServices.AddnewDoctor(newdoctor);
            return Ok("New Doctor Addeed...");
        }
        /// <summary>
        /// Update existing Docctor using doctor Id
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatedoctor/{string doctorId}")]
        public async Task<IActionResult> Updatedoctor(string doctorId, [FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getdoctor = _AMServices.GetDoctorById(doctorId);
            if (getdoctor == null)
            {
                return NotFound();
            }
            await _AMServices.UpdateDoctor(doctorId, doctor);
            return Ok("Doctor Updated...");
        }
        /// <summary>
        /// Remove doctor by doctor Id
        /// </summary>
        /// <param name="DoctorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removedoctor/{DoctorId}")]
        public async Task<IActionResult> RemoveDoctor(string DoctorId)
        {
            if (DoctorId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _AMServices.DeleteDoctor(DoctorId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Doctor Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Update existing user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updateuser/{string userId}")]
        public async Task<IActionResult> Updateuser(string userId, [FromBody] ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getuser = _AMServices.GetUserById(userId);
            if (getuser == null)
            {
                return NotFound();
            }
            await _AMServices.UpdateUser(userId, user);
            return Ok("User Updated...");
        }
        /// <summary>
        /// Add new Mdicne to Db Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddMedicine")]
        public async Task<IActionResult> AddNewMedicine([FromBody] MedicineViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Medicine newMedicine = new Medicine
            {
                Name = model.Name,
                Brand = model.Brand,
                Price = model.Price,
                Stock = model.Stock,
                Discount = model.Discount,
                Details = model.Details,
                Size = model.Size,
                Features = model.Features,
                CatId = model.CatId
            };
            await _AMServices.NewMedicine(newMedicine);
            return Ok("New Medicine Addeed...");
        }
        /// <summary>
        /// Update existring medicine by Medicine Id
        /// </summary>
        /// <param name="medicineId"></param>
        /// <param name="medicine"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updatemedicine/{string MedicineId}")]
        public async Task<IActionResult> UpdatMedicine(string medicineId, [FromBody] Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getmedicine = _MServices.GetMedicineById(medicineId);
            if (getmedicine == null)
            {
                return NotFound();
            }
            await _AMServices.UpdateMedicine(medicineId, medicine);
            return Ok("Medicine Updated...");
        }
        /// <summary>
        /// Delete Medicine by Id
        /// </summary>
        /// <param name="MedicineId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removemedicine/{MedicineId}")]
        public async Task<IActionResult> RemoveMedicine(string MedicineId)
        {
            if (MedicineId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _AMServices.DeleteDoctor(MedicineId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Medicine Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Add new Category to Db Collection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category newcategory = new Category
            {
                CatId = model.CatId,
                Title = model.Title,
                Url = model.Url,
                OpenInNewWindow = model.OpenInNewWindow
            };
            await _AMServices.NewCategory(newcategory);
            return Ok("New Category Addeed...");
        }
        /// <summary>
        /// Remove Appintment by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Removecategory/{Id}")]
        public async Task<IActionResult> RemoveCategory(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _AMServices.DeleteCategory(Id);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Category Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Update Existing appointment by Id
        /// </summary>
        /// <param name="AppointmentId"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Updateappointment/{string AppointmentId}")]
        public async Task<IActionResult> UpdatAppointment(string AppointmentId, [FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var getappoint = _MServices.GetAppointmentById(AppointmentId);
            if (getappoint == null)
            {
                return NotFound();
            }
            await _AMServices.UpdateAppointment(AppointmentId, appointment);
            return Ok("Appointment Updated...");
        }
        /// <summary>
        /// Remove Appointment by Id from Db Collection
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoveAppointment/{AppointmentId}")]
        public async Task<IActionResult> RemoveAppointment(string appointmentId)
        {
            if (appointmentId == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _AMServices.DeleteAppointment(appointmentId);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok("Appointment Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
