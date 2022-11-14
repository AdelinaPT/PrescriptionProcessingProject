using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models.DBObjects;
using PrescriptionProcessing.Models;

namespace PrescriptionProcessing.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public ProductRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ProductRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private ProductModel MapDBObjectToModel(Product dbobject)
        {
            var model = new ProductModel();
            if (dbobject != null)
            {
                model.IdProduct = dbobject.IdProduct;
                model.ProductName = dbobject.ProductName;
                model.ActiveIngredients = dbobject.ActiveIngredients;
                model.PriceUnit = dbobject.PriceUnit;
                model.Stock = dbobject.Stock;
                model.Bbd = dbobject.Bbd;

            }
            return model;
        }

        private Product MapModelToDBObject(ProductModel model)
        {
            var dbobject = new Product();
            if (model != null)
            {
                dbobject.IdProduct = model.IdProduct;
                dbobject.ProductName = model.ProductName;
                dbobject.ActiveIngredients = model.ActiveIngredients;
                dbobject.PriceUnit = model.PriceUnit;
                dbobject.Stock = model.Stock;
                dbobject.Bbd = model.Bbd;

            }
            return dbobject;
        }

        public List<ProductModel> GetAllProducts()
        {
            var list = new List<ProductModel>();
            foreach (var dbobject in _DBContext.Products)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }

        public ProductModel GetProductById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Products.FirstOrDefault(x => x.IdProduct == id));
        }

        public void InsertProduct(ProductModel model)
        {
            model.IdProduct = Guid.NewGuid();
            _DBContext.Products.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();

        }

        public void UpdateProduct(ProductModel model)
        {
            Product dbobject = _DBContext.Products.FirstOrDefault(x => x.IdProduct == model.IdProduct);
            if (dbobject != null)
            {
                dbobject.IdProduct = model.IdProduct;
                dbobject.ProductName = model.ProductName;
                dbobject.ActiveIngredients = model.ActiveIngredients;
                dbobject.PriceUnit = model.PriceUnit;
                dbobject.Stock = model.Stock;
                dbobject.Bbd = model.Bbd;

                _DBContext.SaveChanges();
            }

        }

        public void DeleteProduct(Guid id)
        {
            var dbobject = _DBContext.Products.FirstOrDefault(x => x.IdProduct == id);
            if (dbobject != null)
            {
                _DBContext.Products.Remove(dbobject);

                _DBContext.SaveChanges();
            }
        }
    }
}
