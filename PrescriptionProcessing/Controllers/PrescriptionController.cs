using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrescriptionProcessing.Data;
using PrescriptionProcessing.Models;
using PrescriptionProcessing.Repository;

namespace PrescriptionProcessing.Controllers
{
    public class PrescriptionController : Controller
    {
        private PrescriptionRepository _prescriptionRepository;
        public PrescriptionController(ApplicationDbContext dbcontext)
        {
            _prescriptionRepository = new PrescriptionRepository(dbcontext);
        }
        // GET: PrescriptionController
        public ActionResult Index()
        {
            var list = _prescriptionRepository.GetAllPrescriptions();
            return View(list);
        }

        // GET: PrescriptionController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _prescriptionRepository.GetPrescriptionById(id);
            return View("PrescriptionDetails", model);
        }

        // GET: PrescriptionController/Create
        public ActionResult Create()
        {
            return View("CreatePrescription");
        }

        // POST: PrescriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new PrescriptionModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _prescriptionRepository.InsertPrescription(model);
                }
                return RedirectToAction("Index");
            }
            catch(Exception error)
            {
                return View("CreatePrescription");
            }
        }

        // GET: PrescriptionController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _prescriptionRepository.GetPrescriptionById(id);
            return View("EditPrescription",model);
        }

        // POST: PrescriptionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new PrescriptionModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _prescriptionRepository.UpdatePrescription(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Edit",id);
            }
        }

        // GET: PrescriptionController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _prescriptionRepository.GetPrescriptionById(id);
            return View("DeletePrescription",model);
        }

        // POST: PrescriptionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _prescriptionRepository.DeletePrescription(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",id);
            }
        }
    }
}
