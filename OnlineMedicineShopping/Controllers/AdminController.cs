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
        /// <summary>
        /// Creating referance variable of IAdminMedicineServices interface and injecting in AdminController constructor
        /// </summary>
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
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all appointment placed by user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllAppointment")]
        public async Task<IEnumerable<Appointment>> AllAppointment()
        {
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
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
            //Do code here
            throw new NotImplementedException();
        }
    }
}
