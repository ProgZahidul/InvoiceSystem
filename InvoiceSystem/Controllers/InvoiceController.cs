using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace InvoiceSystem.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Repository repository=new Repository();
        public ActionResult Index()
        {
            var data = repository.GetList();   
            return View(data);
        }
        [HttpGet] public ActionResult Create( ) 
        {
            InvoiceInfo info = new InvoiceInfo();
            info.Prducts.Add(new ProductInfo());
            info.Prducts.Add(new ProductInfo());
            return View(info);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceInfo info)
        {
            if(ModelState.IsValid)
            {
                repository.Save(info);
                return RedirectToActionPermanent("Index");
            }
            return View(info);
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var data= repository.Get(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(InvoiceInfo edtinvoce)
        {
            repository.Update(edtinvoce);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var data = repository.Get(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(InvoiceInfo edtinvoce)
        {
            repository.Delete(edtinvoce);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var data = repository.Get(id);
            return View(data);
        }
    }
}