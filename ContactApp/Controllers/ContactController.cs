using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactApp.Controllers
{

    public class ContactController : Controller
    {



        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Action = "Add";
            return View("AddEdit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Action = "Edit";
            return View("AddEdit", contact);
        }

        [HttpPost]
        public IActionResult AddEdit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    contact.DateAdded = DateTime.Now;
                    _context.Contacts.Add(contact);
                }
                else
                {
                    _context.Contacts.Update(contact);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Include(contact => contact.Category).FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
    }
}

