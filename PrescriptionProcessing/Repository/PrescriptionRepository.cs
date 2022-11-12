using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models.DBObjects;
using PrescriptionProcessing.Models;

namespace PrescriptionProcessing.Repository
{
    public class PrescriptionRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public PrescriptionRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public PrescriptionRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private PrescriptionModel MapDBObjectToModel(Prescription dbobject)
        {
            var model = new PrescriptionModel();
            if (dbobject != null)
            {
                model.IdPrescription = dbobject.IdPrescription;
                model.IdEmployee = dbobject.IdEmployee;
                model.IdOrder = dbobject.IdOrder;
                model.Details = dbobject.Details;
                model.Status = dbobject.Status;

            }
            return model;
        }

        private Prescription MapModelToDBObject(PrescriptionModel model)
        {
            var dbobject = new Prescription();
            if (model != null)
            {
                dbobject.IdPrescription = model.IdPrescription;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.IdOrder = model.IdOrder;
                dbobject.Details = model.Details;
                dbobject.Status = model.Status;

            }
            return dbobject;
        }

        public List<PrescriptionModel> GetAllPrescriptions()
        {
            var list = new List<PrescriptionModel>();
            foreach (var dbobject in _DBContext.Prescriptions)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public PrescriptionModel GetPrescriptionById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Prescriptions.FirstOrDefault(x => x.IdPrescription == id));
        }

        public void InsertPrescription(PrescriptionModel model)
        {
            model.IdPrescription = Guid.NewGuid();
            _DBContext.Prescriptions.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdatePrescription(PrescriptionModel model)
        {
            var dbobject = _DBContext.Prescriptions.FirstOrDefault(x => x.IdPrescription == model.IdPrescription);
            if (dbobject != null)
            {
                dbobject.IdPrescription = model.IdPrescription;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.IdOrder = model.IdOrder;
                dbobject.Details = model.Details;
                dbobject.Status = model.Status;

                _DBContext.SaveChanges();
            }

        }

        public void DeletePrescription(Guid id)
        {
            var dbobject = _DBContext.Prescriptions.FirstOrDefault(x => x.IdPrescription == id);
            if (dbobject != null)
            {
                _DBContext.Prescriptions.Remove(dbobject);

                _DBContext.SaveChanges();
            }
        }
    }
}
