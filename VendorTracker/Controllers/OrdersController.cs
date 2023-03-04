using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 
    public class OrdersController : Controller
    { 
      [HttpGet("/vendors/{id}/orders")]
      public ActionResult Index(int id)
      {     
        Vendor chosenVendor = Vendor.Find(id);
        return View(chosenVendor);
      }

      [HttpGet("/vendors/{id}/orders/new")]
      public ActionResult New(int id)
      {     
        Vendor chosenVendor = Vendor.Find(id);
        return View(chosenVendor);
      }

      [HttpPost("/vendors/{id}/orders")]
      public ActionResult Create(
        int vendorId,
        string breadAmount,
        string pastryAmount,
        string totalPrice
      )
      {
        Vendor chosenVendor = Vendor.Find(vendorId);
        Order newOrder = new Order("3/03/2023", breadAmount, pastryAmount, totalPrice, vendorId);
        chosenVendor.AddOrder(newOrder);
        return View("Index", chosenVendor);
      }
    }

}