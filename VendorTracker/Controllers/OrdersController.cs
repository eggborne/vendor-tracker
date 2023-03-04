using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 
    public class OrdersController : Controller
    { 
      [HttpGet("/vendors/{id}/orders")]
      public ActionResult Index()
      {     
        List<Order> allOrders = Order.GetAll();
        return View(allOrders);
      
      }
    }

}