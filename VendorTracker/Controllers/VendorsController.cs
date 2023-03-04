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
        string vendorEmail,
        int vendorBreadRate,
        int vendorPastryRate
      )
      {
        if (vendorName == null) { vendorName = "Vandelay Industries"; }
        if (vendorDescription == null) { vendorDescription = "Import/Exporter, buys a lot in the springtime"; }
        if (vendorPhone == null) { vendorPhone = "5038675309"; }
        if (vendorEmail == null) { vendorEmail = "art@vandelay.dev"; }
        if (vendorBreadRate == 0) { vendorBreadRate = 3; }
        if (vendorPastryRate == 0) { vendorPastryRate = 2; }

        Dictionary<string, int> vendorRates = new Dictionary<string, int>();
        vendorRates["bread"] = vendorBreadRate;
        vendorRates["pastry"] = vendorPastryRate;

        Vendor newVendor = new Vendor(vendorName, vendorDescription, vendorPhone, vendorEmail, vendorRates);
        return RedirectToAction("Index");
      }
    }

}