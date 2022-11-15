using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models;
using PrescriptionProcessing.Repository;

namespace PrescriptionProcessing.Controllers
{
    [Authorize(Roles = "User, Farmacist, Asistent, Admin")]
    public class OrderController : Controller
    {
        
        private OrderRepository _orderRepository;

        public OrderController(ApplicationDbContext dbContext)
        {
            _orderRepository = new OrderRepository(dbContext);
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var list = _orderRepository.GetAllOrders();
            return View(list);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _orderRepository.GetOrderById(id);
            return View("DetailsOrder", model);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View("CreateOrder");
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new OrderModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _orderRepository.InsertOrder(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrder");
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _orderRepository.GetOrderById(id);
            return View("EditOrder",model);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new OrderModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                { 
                    _orderRepository.UpdateOrder(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit",id);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _orderRepository.GetOrderById(id);
            return View("DeleteOrder",model);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _orderRepository.DeleteOrder(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",id);
            }
        }
    }
}
