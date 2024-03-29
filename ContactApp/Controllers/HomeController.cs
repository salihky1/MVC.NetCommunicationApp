using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactApp.Models;
using ContactApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public IActionResult Index()
    {
        var contacts = _context.Contacts.Include(c => c.Category).OrderBy(c => c.LastName).ToList();
        return View(contacts);
    }

 
}

