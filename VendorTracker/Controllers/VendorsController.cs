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
    }
}