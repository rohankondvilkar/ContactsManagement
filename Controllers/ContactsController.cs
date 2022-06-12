using ContactsManagement.Models;
using ContactsManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagement.Controllers
{
    public class ContactsController : Controller
    {

        // GET: ContactsController
        public ActionResult Index()
        {
            ContactsRepository contactsRepository = new ContactsRepository();
            ModelState.Clear();
            return View(contactsRepository.GetAllContacts());
        }

        // GET: ContactsController/Details/5
        public ActionResult Details(int id)
        {
            ContactsRepository contactsRepository = new ContactsRepository();
            ModelState.Clear();
            return View(contactsRepository.GetContactById(id));
        }

        // GET: ContactsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contacts contacts)
        {
            try
            {
                if (ModelState.IsValid) {
                    ContactsRepository contactsRepository = new ContactsRepository();
                    if (contactsRepository.InsertContact(contacts)) {
                        ViewBag.Message = "Contact added successfully";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Edit/5
        public ActionResult Edit(int id)
        {
            ContactsRepository contactsRepository = new ContactsRepository();

            return View(contactsRepository.GetContactById(id));
        }

        // POST: ContactsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contacts contacts)
        {
            try
            {
                ContactsRepository contactsRepository = new ContactsRepository();
                if (contactsRepository.UpdateContactById(contacts)) {
                    ViewBag.Message = "Contact updated successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactsController/Delete/5
        public ActionResult Delete(int id)
        {
            ContactsRepository contactsRepository = new ContactsRepository();
            return View(contactsRepository.GetContactById(id));
        }

        // POST: ContactsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ContactsRepository contactsRepository = new ContactsRepository();
                if (contactsRepository.DeleteContactById(id)) {
                    ViewBag.Message = "Contact deleted successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
