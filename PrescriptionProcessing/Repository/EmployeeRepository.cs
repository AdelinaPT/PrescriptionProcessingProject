using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models;
using PrescriptionProcessing.Models.DBObjects;

namespace PrescriptionProcessing.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public EmployeeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public EmployeeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private EmployeeModel MapDBObjectToModel(Employee dbobject)
        {
            var model = new EmployeeModel();
            if (dbobject != null)
            {
                model.IdEmployee = dbobject.IdEmployee;
                model.Name = dbobject.Name;
                model.Position = dbobject.Position;
                model.DateStarted = dbobject.DateStarted;
                model.EndDate = dbobject.EndDate;
                model.JobDescription = dbobject.JobDescription;

            }
            return model;
        }

        private Employee MapModelToDBObject(EmployeeModel model)
        {
            var dbobject = new Employee();
            if (model != null)
            {
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.Name = model.Name;
                dbobject.Position = model.Position;
                dbobject.DateStarted = model.DateStarted;
                dbobject.EndDate = model.EndDate;
                dbobject.JobDescription = model.JobDescription;
            }
            return dbobject;
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            var list = new List<EmployeeModel>();
            foreach (var dbobject in _DBContext.Employees)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Employees.FirstOrDefault(x => x.IdEmployee == id));
        }

        public void InsertEmployee(EmployeeModel model)
        {
            model.IdEmployee = Guid.NewGuid();
            _DBContext.Employees.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdateEmployee(EmployeeModel model)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.IdEmployee == model.IdEmployee);
            if (dbobject != null)
            {
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.Name = model.Name;
                dbobject.Position = model.Position;
                dbobject.DateStarted = model.DateStarted;
                dbobject.EndDate = model.EndDate;
                dbobject.JobDescription = model.JobDescription;

                _DBContext.SaveChanges();
            }

        }

        public void DeleteEmployee(Guid id)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.IdEmployee == id);
            if (dbobject != null)
            {
                _DBContext.Employees.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
