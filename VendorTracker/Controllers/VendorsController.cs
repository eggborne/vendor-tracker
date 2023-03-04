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
        string vendorPhone,
        string vendorEmail
      )
      {
        if (vendorName == null) { vendorName = "Vandelay Industries"; }
        if (vendorDescription == null) { vendorDescription = "Import/Exporter, buys a lot in the springtime"; }
        if (vendorPhone == null) { vendorPhone = "5038675309"; }
        if (vendorEmail == null) { vendorEmail = "art@vandelay.dev"; }
        
        Vendor newVendor = new Vendor(vendorName, vendorDescription, vendorPhone, vendorEmail);
        return RedirectToAction("Index");
      }
    }

}