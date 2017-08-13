using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCContactListv2.Models;
using MVCContactListv2.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCContactListv2.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            var list = DataManager.ListPeople();
            return View(list);
        }

        

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Contact";

            return View();
        }

        [HttpPost]
        public IActionResult Create(PeopleCreateVM peopleCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Create Contact";
                return View(peopleCreateVM);
            }

            DataManager.AddPerson(peopleCreateVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Contact";
            var contact = DataManager.GetContactById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(int id, PeopleEditVM newPeopleEditVM)
        {
            // Todo: kanske behöver ändras för VM
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Edit Contact";
                return View(newPeopleEditVM);
            }

            DataManager.EditContact(id, newPeopleEditVM);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int id) {
            DataManager.RemoveContactById(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
