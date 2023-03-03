using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 

    public class VendorsController : Controller
    { 
      [HttpGet("/vendors")]
      public ActionResult Index()
      {     
        return View();
      
      }

      [HttpGet("/vendors/new")]
      public ActionResult New()
      {     
        return View();
      
      }

      [HttpPost("/vendors")]
      public ActionResult Create(
        string vendorName,
        string vendorDescription,
        string vendorBreadPerMonth,
        string vendorPastriesPerMonth
      )
      {
        
        return RedirectToAction("Index");
      }
    }
}