using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models.DBObjects;
using PrescriptionProcessing.Models;

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
                model.IssuedBy = dbobject.IssuedBy;
                model.Details = dbobject.Details;

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
                dbobject.IssuedBy = model.IssuedBy;
                dbobject.Details = model.Details;

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
                dbobject.IssuedBy = model.IssuedBy;
                dbobject.Details = model.Details;

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
