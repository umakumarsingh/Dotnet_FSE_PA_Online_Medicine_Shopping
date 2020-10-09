using Moq;
using OnlineMedicineShopping.BusinessLayer.Interfaces;
using OnlineMedicineShopping.BusinessLayer.Services;
using OnlineMedicineShopping.BusinessLayer.Services.Repository;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineMedicineShopping.Test.TestCases
{
    public class FuctionalTests
    {
        /// <summary>
        /// Creating Referance Variable and Mocking repository class
        /// </summary>
        private readonly IAdminMedicineServices _adminMServices;
        private readonly IMedicineServices _medicineServices;
        public readonly Mock<IAdminMedicineRepository> adminservice = new Mock<IAdminMedicineRepository>();
        public readonly Mock<IMedicineRepository> medicineservice = new Mock<IMedicineRepository>();
        private ApplicationUser _user;
        private Medicine _medicine;
        private Category _category;
        private Appointment _appointment;
        private Doctor _doctor;
        private MedicineOrder _medicineOrder;
        public FuctionalTests()
        {
            _medicineServices = new MedicineServices(medicineservice.Object);
            _adminMServices = new AdminMedicineServices(adminservice.Object);
            _user = new ApplicationUser()
            {
                UserId = "5f8054f4914569df2b9e7d8e",
                Name = "Uma Kumar",
                Email = "umakumarsingh@gmail.com",
                Password = "12345",
                MobileNumber = 9865253568,
                PinCode = 820003,
                HouseNo_Building_Name = "9/11",
                Road_area = "Road_area",
                City = "Gaya",
                State = "Bihar"
            };
            _category = new Category()
            {
                Id = "5f0ff60a7b7be11c4c3c19e1",
                CatId = 1,
                Url = "~/Home",
                OpenInNewWindow = false
            };
            _medicine = new Medicine()
            {
                MedicineId = "5f802874c043a417142b7cc1",
                Name = "Medicine-1",
                Brand = "Brand-One",
                Price = 123,
                Stock = 10,
                Discount = 10,
                Details = "Medicine Details",
                Size = "100Mg",
                Features = "Medicine Feature for Medicine-1",
                CatId = 1
            };
            _appointment = new Appointment()
            {
                AppointmentId = "5f805687914569df2b9e7d90",
                PatientName = "Uma",
                DoctorName = "R Kumar",
                Takendate = DateTime.Now,
                Symtoms = "Fever",
                PatientAge = 30,
                Remark = "Patient Remark"
            };
            _doctor = new Doctor()
            {
                DoctorId = "5f802b2ec043a417142b7cc3",
                Name = "R.R",
                Specialization = "MBBS - ENT",
                Qualification = "MBBS",
                PracticingFrom = DateTime.Now
            };
            _medicineOrder = new MedicineOrder()
            {
                OrderId = "5f805550914569df2b9e7d8f",
                MedicineId = "",
                UserId = ""
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static FuctionalTests()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Using the test method try to test all appointment is getting or not, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllAppointment()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.GetAllAppointment());
            var result = await _adminMServices.GetAllAppointment();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetAllProduct=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test all Order is getting or not, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_GetAllOrder()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.GetAllOrder());
            var result = await _adminMServices.GetAllOrder();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_GetAllOrder=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add new Doctor is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidAddDoctor()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.AddnewDoctor(_doctor)).ReturnsAsync(_doctor);
            var result = await _adminMServices.AddnewDoctor(_doctor);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_ValidAddDoctor=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to get a Doctor by Doctor Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetDoctorById()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.GetDoctorById(_doctor.DoctorId)).ReturnsAsync(_doctor);
            var result = await _adminMServices.GetDoctorById(_doctor.DoctorId);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetDoctorById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Doctor by Doctor Id and Doctor Collection
        /// if get updated then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateDoctor()
        {
            //Arrange
            bool res = false;
            var _doctorUpdate = new Doctor()
            {
                DoctorId = "5f802b2ec043a417142b7cc3",
                Name = "R.R",
                Specialization = "MBBS - ENT",
                Qualification = "MBBS",
                PracticingFrom = DateTime.Now
            };
            //Act
            adminservice.Setup(repo => repo.UpdateDoctor(_doctorUpdate.DoctorId, _doctorUpdate)).ReturnsAsync(_doctorUpdate);
            var result = await _adminMServices.UpdateDoctor(_doctorUpdate.DoctorId, _doctorUpdate);
            if (result == _doctorUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateDoctor=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete a Doctor by Doctor Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteDoctor()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.DeleteDoctor(_doctor.DoctorId)).ReturnsAsync(true);
            var resultDelete = await _adminMServices.DeleteDoctor(_doctor.DoctorId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteDoctor=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing User by User Id and ApplicationUser Collection
        /// if get updated then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateUser()
        {
            //Arrange
            bool res = false;
            var _userUpdate = new ApplicationUser()
            {
                UserId = "5f8054f4914569df2b9e7d8e",
                Name = "Uma Kumar",
                Email = "umakumarsingh@gmail.com",
                Password = "12345",
                MobileNumber = 9865253568,
                PinCode = 820003,
                HouseNo_Building_Name = "9/11",
                Road_area = "Road_area",
                City = "Gaya",
                State = "Bihar"
            };
            //Act
            adminservice.Setup(repo => repo.UpdateUser(_userUpdate.UserId, _userUpdate)).ReturnsAsync(_userUpdate);
            var result = await _adminMServices.UpdateUser(_userUpdate.UserId, _userUpdate);
            if (result == _userUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateUser=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to get a User by User Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetUserById()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.GetUserById(_user.UserId)).ReturnsAsync(_user);
            var result = await _adminMServices.GetUserById(_user.UserId);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetUserById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add new Medicine is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidAdd_NewMedicine()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.NewMedicine(_medicine)).ReturnsAsync(_medicine);
            var result = await _adminMServices.NewMedicine(_medicine);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_ValidAdd_NewMedicine=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Medicine by Medicine Id and Medicine Collection
        /// if get updated then Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateMedicine()
        {
            //Arrange
            bool res = false;
            var _medicineUpdate = new Medicine()
            {
                MedicineId = "5f802874c043a417142b7cc1",
                Name = "Medicine-1",
                Brand = "Brand-One",
                Price = 123,
                Stock = 10,
                Discount = 10,
                Details = "Medicine Details",
                Size = "100Mg",
                Features = "Medicine Feature for Medicine-1",
                CatId = 1
            };
            //Act
            adminservice.Setup(repo => repo.UpdateMedicine(_medicineUpdate.MedicineId, _medicineUpdate)).ReturnsAsync(_medicineUpdate);
            var result = await _adminMServices.UpdateMedicine(_medicineUpdate.MedicineId, _medicineUpdate);
            if (result == _medicineUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateMedicine=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete a Medicine by Medicine Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteMedicine()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.DeleteMedicine(_medicine.MedicineId)).ReturnsAsync(true);
            var resultDelete = await _adminMServices.DeleteMedicine(_medicine.MedicineId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteMedicine=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to test Add new Category is getting added, if added then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ValidAdd_NewCategory()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.NewCategory(_category)).ReturnsAsync(_category);
            var result = await _adminMServices.NewCategory(_category);
            if (result != null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_ValidAdd_NewCategory=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete a Category by Category Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteCategory()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.DeleteCategory(_category.Id)).ReturnsAsync(true);
            var resultDelete = await _adminMServices.DeleteCategory(_category.Id);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteCategory=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Appointment by AppointmentId and Appointment Collection
        /// if get updated then Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateAppointment()
        {
            //Arrange
            bool res = false;
            var _appointmentUpdate = new Appointment()
            {
                AppointmentId = "5f805687914569df2b9e7d90",
                PatientName = "Uma",
                DoctorName = "R Kumar",
                Takendate = DateTime.Now,
                Symtoms = "Fever",
                PatientAge = 30,
                Remark = "Patient Remark"
            };
            //Act
            adminservice.Setup(repo => repo.UpdateAppointment(_appointmentUpdate.AppointmentId, _appointmentUpdate)).ReturnsAsync(_appointmentUpdate);
            var result = await _adminMServices.UpdateAppointment(_appointmentUpdate.AppointmentId, _appointmentUpdate);
            if (result == _appointmentUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateAppointment=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete a Appointment by Appointment Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteAppointment()
        {
            //Arrange
            var res = false;
            //Action
            adminservice.Setup(repos => repos.DeleteAppointment(_appointment.AppointmentId)).ReturnsAsync(true);
            var resultDelete = await _adminMServices.DeleteAppointment(_appointment.AppointmentId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteAppointment=" + res + "\n");
            return res;
        }
    }
}
