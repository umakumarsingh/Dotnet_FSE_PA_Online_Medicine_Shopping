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
    public class MedicineRepository : IMedicineRepository
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
        private IMongoCollection<MedicineOrder> _dbMOCollection;
        private IMongoCollection<Appointment> _dbACollection;
        public MedicineRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbMCollection = _mongoContext.GetCollection<Medicine>(typeof(Medicine).Name);
            _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
            _dbCCollection = _mongoContext.GetCollection<Category>(typeof(Category).Name);
            _dbDCollection = _mongoContext.GetCollection<Doctor>(typeof(Doctor).Name);
            _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
        }
        public IList<Category> CategoryList()
        {
            try
            {
                var list = _mongoContext.GetCollection<Category>("Category")
                .Find(Builders<Category>.Filter.Empty, null)
                .SortByDescending(e => e.Title);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public IEnumerable<Doctor> Doctor()
        {
            try
            {
                var list = _mongoContext.GetCollection<Doctor>("Doctor")
                .Find(Builders<Doctor>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Appointment> DoctorAppointment(Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    throw new ArgumentNullException(typeof(Appointment).Name + "Object is Null");
                }
                _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
                await _dbACollection.InsertOneAsync(appointment);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return appointment;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            try
            {
                var list = _mongoContext.GetCollection<Doctor>("Doctor")
                .Find(Builders<Doctor>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicine()
        {
            try
            {
                var list = _mongoContext.GetCollection<Medicine>("Medicine")
                .Find(Builders<Medicine>.Filter.Empty, null)
                .SortByDescending(e => e.Name);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Appointment> GetAppointmentById(string appointmentId)
        {
            try
            {
                var objectId = new ObjectId(appointmentId);
                FilterDefinition<Appointment> filter = Builders<Appointment>.Filter.Eq("AppointmentId", objectId);
                _dbACollection = _mongoContext.GetCollection<Appointment>(typeof(Appointment).Name);
                return await _dbACollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Medicine> GetMedicineById(string medicineId)
        {
            try
            {
                var objectId = new ObjectId(medicineId);
                FilterDefinition<Medicine> filter = Builders<Medicine>.Filter.Eq("MedicineId", objectId);
                _dbMCollection = _mongoContext.GetCollection<Medicine>(typeof(Medicine).Name);
                return await _dbMCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Medicine>> MedicineByName(string name)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Medicine>();
                var findName = filterBuilder.Eq(s => s.Name, name);
                var findBrand = filterBuilder.Eq(s => s.Brand, name.ToString());
                _dbMCollection = _mongoContext.GetCollection<Medicine> (typeof(Medicine).Name);
                var result = await _dbMCollection.FindAsync(findName | findBrand).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<MedicineOrder> GetOrderById(string OrderId)
        {
            try
            {
                var objectId = new ObjectId(OrderId);
                FilterDefinition<MedicineOrder> filter = Builders<MedicineOrder>.Filter.Eq("OrderId", objectId);
                _dbMOCollection = _mongoContext.GetCollection<MedicineOrder>(typeof(MedicineOrder).Name);
                return await _dbMOCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> PlaceOrder(string medicineId, string UserId)
        {
            try
            {
                var res = false;
                var objectId = new ObjectId(medicineId);
                FilterDefinition<Medicine> filter = Builders<Medicine>.Filter.Eq("MedicineId", objectId);
                _dbMCollection = _mongoContext.GetCollection<Medicine>(typeof(Medicine).Name);
                var medicine = await _dbMCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
                if (medicine != null)
                {
                    var order = new MedicineOrder()
                    {
                        MedicineId = medicine.MedicineId,
                        UserId = UserId
                    };
                    _dbMOCollection = _mongoContext.GetCollection<MedicineOrder>(typeof(MedicineOrder).Name);
                    await _dbMOCollection.InsertOneAsync(order);
                }
                res = true;
                return res;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Add new user to Db Collection
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> RegisterUser(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(typeof(ApplicationUser).Name + "Object is Null");
                }
                _dbAUCollection = _mongoContext.GetCollection<ApplicationUser>(typeof(ApplicationUser).Name);
                await _dbAUCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return user;
        }
        /// <summary>
        /// Verify User using this method
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> Login(string Email, string password)
        {
            try
            {
                var email = Builders<ApplicationUser>.Filter.Eq("Email", Email);
                var pass = Builders<ApplicationUser>.Filter.Eq("Password", password);
                var filterCriteria = Builders<ApplicationUser>.Filter.And(email, pass);
                var userFind = await _dbAUCollection.FindAsync(filterCriteria);
                return userFind.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Logout function
        /// </summary>
        /// <returns></returns>
        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
