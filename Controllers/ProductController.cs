using bnm.Entities;
using bnm.Models;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace bnm.Controllers;
using bnm.Views.ViewModel;
using System.Security.Claims;

[Authorize(Roles="Seller,Buyer")]
public class ProductController : Controller

{
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    private readonly ApplicationDbContext context;
    public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        this.context = context;
        _webHostEnvironment = webHostEnvironment;

    }
    [Authorize(Roles ="Seller")]
    public IActionResult Index()
    {
        List<Product> p = context.products.Where(s=>s.sId== User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();

        return View(p);

    }
    [Authorize(Roles = "Seller")]

    public IActionResult Save()
    {

        productmodel p = new productmodel();
        return View("Save",p);


    }

    [Authorize(Roles = "Seller")]
    [HttpPost]

    public IActionResult Save(productmodel p)
    {
        Product pp = new Product();
        if(p != null)
        {
            pp.Price = p.Price;
            pp.Description= p.Description;
            pp.Name = p.Name;
            pp.sId= User.FindFirst(ClaimTypes.NameIdentifier).Value;
            pp.Quantity=p.Quantity;
            if (p.ImageFile != null)
            {
                var unfile = ImageSaver.SaveImage(p.ImageFile, _webHostEnvironment);
                if (unfile.Result != null)
                {
                    pp.ImageUrl= unfile.Result;
                    context.products.Add(pp);
                    context.SaveChanges();
                  
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Image", "Invalid format. Allowed formats : png, jpg,jpeg.");
                }
            }

           
        }
        return View("Save", p);
    }
    [Authorize(Roles = "Seller")]

    public IActionResult Edit(int Id)
    {
        Product pp= context.products.Find(Id);
        return View("Edit",pp);

    }
    [Authorize(Roles = "Seller")]

    [HttpPost]
    public IActionResult SaveAfterEdit(int Id, Product p)
    {
        Product pp = context.products.Find(Id);
        pp.Price = p.Price;
        pp.Quantity = p.Quantity;
        pp.Name= p.Name;
        pp.ImageUrl= p.ImageUrl;
        pp.Description= p.Description;
   

        context.SaveChanges();
        return RedirectToAction("Index");

    }


   
    [Authorize(Roles = "Seller")]
    public IActionResult Delete(int id)
    {
        try
        {
            Product product = context.products.Find(id);
            context.products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index");
        }
    }


        public IActionResult Search(string n)
    {
        List<Product> list = context.products.Where(p => p.Name.Contains(n))
        .ToList();
        return View("Search",list);
    }

   

}
