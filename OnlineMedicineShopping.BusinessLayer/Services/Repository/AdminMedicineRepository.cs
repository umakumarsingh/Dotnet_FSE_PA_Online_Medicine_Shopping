using MongoDB.Bson;
using MongoDB.Driver;
using OnlineMedicineShopping.DataLayer;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMedicineShopping.BusinessLayer.Services.Repository
{
    public class AdminMedicineRepository : IAdminMedicineRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Medicine> _dbMCollection;
        private IMongoCollection<ApplicationUser> _dbAUCollection;
        private IMongoCollection<Category> _dbCCollection;
        private IMongoCollection<Doctor> _dbDCollection;
        private IMongoCollection<Appointment> _dbACollection;
        public AdminMedicineRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbMCollection = _mongoContext.GetCollection<Medicine>(typeof(Medicine).Name);
            _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
            _dbCCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
            _dbDCollection = _mongoContext.GetCollection<Doctor>(typeof(Doctor).Name);
            _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
        }

        public async Task<Doctor> AddnewDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null)
                {
                    throw new ArgumentNullException(typeof(Doctor).Name + "Object is Null");
                }
                _dbDCollection = _mongoContext.GetCollection<Doctor>(typeof(Doctor).Name);
                await _dbDCollection.InsertOneAsync(doctor);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return doctor;
        }

        public async Task<bool> DeleteAppointment(string appointmentId)
        {
            try
            {
                var objectId = new ObjectId(appointmentId);
                FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Eq("AppointmentId", objectId);
                var result = await _dbACollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteCategory(string Id)
        {
            try
            {
                var objectId = new ObjectId(Id);
                FilterDefinition<Category> filter = Builders<Category>.Filter.Eq("Id", objectId);
                var result = await _dbCCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteDoctor(string doctorId)
        {
            try
            {
                var objectId = new ObjectId(doctorId);
                FilterDefinition<Doctor> filter = Builders<Doctor>.Filter.Eq("DoctorId", objectId);
                var result = await _dbDCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteMedicine(string medicineId)
        {
            try
            {
                var objectId = new ObjectId(medicineId);
                FilterDefinition<Medicine> filter = Builders<Medicine>.Filter.Eq("MedicineId", objectId);
                var result = await _dbMCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            try
            {
                var list = _mongoContext.GetCollection<Appointment>("Appointment")
                .Find(Builders<Appointment>.Filter.Empty, null)
                .SortByDescending(e => e.AppointmentId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<MedicineOrder>> GetAllOrder()
        {
            try
            {
                var list = _mongoContext.GetCollection<MedicineOrder>("MedicineOrder")
                .Find(Builders<MedicineOrder>.Filter.Empty, null)
                .SortByDescending(e => e.OrderId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Doctor> GetDoctorById(string DoctorId)
        {
            try
            {
                var objectId = new ObjectId(DoctorId);
                FilterDefinition<Doctor> filter = Builders<Doctor>.Filter.Eq("DoctorId", objectId);
                _dbDCollection = _mongoContext.GetCollection<Doctor>(typeof(Doctor).Name);
                return await _dbDCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            try
            {
                var objectId = new ObjectId(userId);
                FilterDefinition<ApplicationUser> filter = Builders<ApplicationUser>.Filter.Eq("DoctorId", objectId);
                _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                return await _dbAUCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Category> NewCategory(Category category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException(typeof(Category).Name + "Object is Null");
                }
                _dbCCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
                await _dbCCollection.InsertOneAsync(category);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return category;
        }

        public async Task<Medicine> NewMedicine(Medicine medicine)
        {
            try
            {
                if (medicine == null)
                {
                    throw new ArgumentNullException(typeof(Medicine).Name + "Object is Null");
                }
                _dbMCollection = _mongoContext.GetCollection<Medicine>(typeof(Medicine).Name);
                await _dbMCollection.InsertOneAsync(medicine);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return medicine;
        }
        public async Task<Appointment> UpdateAppointment(string appointmentId, Appointment appointment)
        {
            if (appointment == null && appointmentId == null)
            {
                throw new ArgumentNullException(typeof(Appointment).Name + "Object or may be AppointmentId is Null");
            }
            var update = await _dbACollection.FindOneAndUpdateAsync(Builders<Appointment>.
                Filter.Eq("AppointmentId", appointment.AppointmentId), Builders<Appointment>.
                Update.Set("PatientName", appointment.PatientName).Set("DoctorName", appointment.DoctorName).Set("Takendate", appointment.Takendate)
                .Set("Symtoms", appointment.Symtoms).Set("Remark", appointment.Remark).Set("PatientAge", appointment.PatientAge));
            return update;
        }

        public async Task<Doctor> UpdateDoctor(string doctorId, Doctor doctor)
        {
            if (doctor == null && doctorId == null)
            {
                throw new ArgumentNullException(typeof(Doctor).Name + "Object or may DoctorId is Null");
            }
            var update = await _dbDCollection.FindOneAndUpdateAsync(Builders<Doctor>.
                Filter.Eq("DoctorId", doctor.DoctorId), Builders<Doctor>.
                Update.Set("Name", doctor.Name).Set("Specialization", doctor.Specialization).Set("Qualification", doctor.Qualification)
                .Set("PracticingFrom", doctor.PracticingFrom));
            return update;
        }

        public async Task<Medicine> UpdateMedicine(string medicineId, Medicine medicine)
        {
            if (medicine == null && medicineId == null)
            {
                throw new ArgumentNullException(typeof(Medicine).Name + "Object or may MedicineId is Null");
            }
            var update = await _dbMCollection.FindOneAndUpdateAsync(Builders<Medicine>.
                Filter.Eq("MedicineId", medicine.MedicineId), Builders<Medicine>.
                Update.Set("Name", medicine.Name).Set("Brand", medicine.Brand).Set("Price", medicine.Price)
                .Set("Stock", medicine.Stock).Set("Discount", medicine.Discount).Set("Details", medicine.Details)
                .Set("Size", medicine.Size).Set("Features", medicine.Features));
            return update;
        }

        public async Task<ApplicationUser> UpdateUser(string userId, ApplicationUser user)
        {
            if (user == null && userId == null)
            {
                throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object or may be UserId is Null");
            }
            var update = await _dbAUCollection.FindOneAndUpdateAsync(Builders<ApplicationUser>.
                Filter.Eq("UserId", user.UserId), Builders<ApplicationUser>.
                Update.Set("Name", user.Name).Set("Email", user.Email).Set("Password", user.Password)
                .Set("MobileNumber", user.MobileNumber).Set("PinCode", user.PinCode).Set("HouseNo_Building_Name", user.HouseNo_Building_Name)
                .Set("Road_area", user.Road_area).Set("City", user.City).Set("State", user.State));
            return update;
        }
    }
}
