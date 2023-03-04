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
        Vendor newVendor = new Vendor(vendorName, vendorDescription, vendorPhone, vendorEmail);
        return RedirectToAction("Index");
      }

      // [HttpGet("/vendors/{id}/orders")]
      // public ActionResult Show(int id)
      // {
      //   Vendor chosenVendor = Vendor.Find(id);
      //   return View(chosenVendor);
      // }
    }

}