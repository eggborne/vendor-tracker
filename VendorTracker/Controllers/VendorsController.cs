using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 

    public class VendorsController : Controller
    { 
      [HttpGet("/vendors")]
      public ActionResult Index()
      {     
        List<Vendor> allVendors = Vendor.GetAll();
        return View(allVendors);
      
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
        Vendor newVendor = new Vendor(vendorName, vendorDescription, vendorBreadPerMonth, vendorPastriesPerMonth);
        return RedirectToAction("Index");
      }
    }
}