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
    public class BoundaryTest
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
        public BoundaryTest()
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
        static BoundaryTest()
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
        /// Testfor_ValidateUserId is used to test register user is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateUserId()
        {
            //Arrange
            bool res = false;
            //Act
            medicineservice.Setup(repo => repo.RegisterUser(_user)).ReturnsAsync(_user);
            var result = await _medicineServices.RegisterUser(_user);

            if (result.UserId.Length.ToString() == _user.UserId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateUserId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_ValidateOrderId is used to test Place order is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateOrderId()
        {
            //Arrange
            bool res = false;
            //Act
            medicineservice.Setup(repo => repo.PlaceOrder(_medicine.MedicineId, _user.UserId)).ReturnsAsync(true);
            var result = await _medicineServices.PlaceOrder(_medicine.MedicineId, _user.UserId);

            if (result == true)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateOrderId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_ValidateAppointmentId is used to test Take Appointment by user is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_DoctorAppointmentId()
        {
            //Arrange
            bool res = false;
            //Act
            medicineservice.Setup(repo => repo.DoctorAppointment(_appointment)).ReturnsAsync(_appointment);
            var result = await _medicineServices.DoctorAppointment(_appointment);

            if (result.AppointmentId.Length.ToString() == _appointment.AppointmentId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_Valid_DoctorAppointmentId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_ValidateDoctorId is used to test Take Add new doctor is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_DoctorId()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.AddnewDoctor(_doctor)).ReturnsAsync(_doctor);
            var result = await _adminMServices.AddnewDoctor(_doctor);

            if (result.DoctorId.Length.ToString() == _doctor.DoctorId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_Valid_DoctorId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_Validate MedicineId is used to test Add new Medicine is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_NewMedicineId()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.NewMedicine(_medicine)).ReturnsAsync(_medicine);
            var result = await _adminMServices.NewMedicine(_medicine);

            if (result.MedicineId.Length.ToString() == _medicine.MedicineId.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_Valid_NewMedicineId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Testfor_Validate CategoryId is used to test Add new Category is valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Valid_NewCategoryId()
        {
            //Arrange
            bool res = false;
            //Act
            adminservice.Setup(repo => repo.NewCategory(_category)).ReturnsAsync(_category);
            var result = await _adminMServices.NewCategory(_category);

            if (result.Id.Length.ToString() == _category.Id.Length.ToString())
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_Validate_Valid_NewCategoryId=" + res + "\n");
            return res;
        }
    }
}
