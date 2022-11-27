using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models;
using PrescriptionProcessing.Models.DBObjects;


namespace PrescriptionProcessing.Repository
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public OrderRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public OrderRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private OrderModel MapDBObjectToModel(Order dbobject)
        {
            var model = new OrderModel();
            if (dbobject != null)
            {
                model.IdOrder = dbobject.IdOrder;
                model.PrescriptionNumber = dbobject.PrescriptionNumber;
                model.PatientName = dbobject.PatientName;
                model.Details = dbobject.Details;
                model.IssuedDate = dbobject.IssuedDate;
                model.Status = dbobject.Status;
                model.PickedUpBy = dbobject.PickedUpBy;
            }
            return model;
        }

        private Order MapModelToDBObject(OrderModel model)
        {
            var dbobject = new Order();
            if (model != null)
            {
                dbobject.IdOrder = model.IdOrder;
                dbobject.PrescriptionNumber = model.PrescriptionNumber;
                dbobject.PatientName = model.PatientName;
                dbobject.Details = model.Details;
                dbobject.IssuedDate = model.IssuedDate;
                dbobject.Status = model.Status;
                dbobject.PickedUpBy = model.PickedUpBy;

            }
            return dbobject;
        }

        public List<OrderModel> GetAllOrders()
        {
            var list = new List<OrderModel>();
            foreach (var dbobject in _DBContext.Orders)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public OrderModel GetOrderById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Orders.FirstOrDefault(x => x.IdOrder == id));
        }

        public void InsertOrder(OrderModel model)
        {
            model.IdOrder = Guid.NewGuid();
            _DBContext.Orders.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdateOrder(OrderModel model)
        {
            var dbobject = _DBContext.Orders.FirstOrDefault(x => x.IdOrder == model.IdOrder);
            if (dbobject != null)
            {
                dbobject.IdOrder = model.IdOrder;
                dbobject.PrescriptionNumber = model.PrescriptionNumber;
                dbobject.PatientName = model.PatientName;
                dbobject.Details = model.Details;
                dbobject.IssuedDate = model.IssuedDate;
                dbobject.Status = model.Status;
                dbobject.PickedUpBy = model.PickedUpBy;

                _DBContext.SaveChanges();
            }

        }

        public void DeleteOrder(Guid id)
        {
            var dbobject = _DBContext.Orders.FirstOrDefault(x => x.IdOrder == id);
            if (dbobject != null)
            {
                _DBContext.Orders.Remove(dbobject);

                _DBContext.SaveChanges();
            }
        }
    }
}
