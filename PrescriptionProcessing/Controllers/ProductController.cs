using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models;
using PrescriptionProcessing.Repository;

namespace PrescriptionProcessing.Controllers
{
    [Authorize(Roles = "Admin, Farmacist")]
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;
        public ProductController(ApplicationDbContext dbcontext)
        {
            _productRepository = new ProductRepository(dbcontext);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var list = _productRepository.GetAllProducts();
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("ProductDetails", model);
        }

        // GET: ProductController/Create
        [Authorize(Roles = "Farmacist")]
        public ActionResult Create()
        {
            return View("CreateProduct");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ProductModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _productRepository.InsertProduct(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProduct");
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("EditProduct", model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProductModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _productRepository.UpdateProduct(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
                
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _productRepository.GetProductById(id);
            return View("DeleteProduct", model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProduct", id);
            }
        }
    }
}
