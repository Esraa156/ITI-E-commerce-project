using bnm.Entities;
using bnm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace bnm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;

        }
        public IActionResult Home()
        {
          

            return View();
        }
        public IActionResult Index()
        {
            List<Product> p = context.products.ToList();

            return View(p);
        }
   
        public IActionResult Browse()
        {
            List<Product> myList = context.products.ToList();
            return View(myList);
        }
  


        public IActionResult Privacy()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Search(string Name)
        {
            if (Name== null)
            {

            }
            else
            {
                List<Product> listr = context.products.Where(p => p.Name.Contains(Name))
                .ToList();
                return View("Search", listr);

            }
            return View("Index");

        }
    }
}