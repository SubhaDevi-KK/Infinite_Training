using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_1.Models;
using Assignment_1.Repository;

namespace Assignment_1.Controllers
{
    public class ContactController : Controller
    {
        IContactRepository<Contact> _Contactrepo = null;

        public ContactController()
        {
            _Contactrepo = new ContactRepository<Contact>();
        }

        // 1. GET: Contact
        public ActionResult Index()
        {
            var contact = _Contactrepo.GetAll();
            return View(contact);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact c)
        {
            if (ModelState.IsValid)
            {
                _Contactrepo.Insert(c);
                _Contactrepo.Save();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Edit(int id)
        {
            var contact = _Contactrepo.GetByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact c)
        {
            if (ModelState.IsValid)
            {
                _Contactrepo.Update(c);
                _Contactrepo.Save();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Details(int id)
        {
            var contact = _Contactrepo.GetByID(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            var contact = _Contactrepo.GetByID(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _Contactrepo.Delete(id);
            _Contactrepo.Save();
            return RedirectToAction("Index");
        }

    }
}