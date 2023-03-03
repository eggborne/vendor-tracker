using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 

    public class VendorController : Controller
    { 
      [HttpGet("/vendor")]
      public ActionResult Index()
      {     
        return View();
      
      }
    }
}