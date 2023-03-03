using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{ 

    public class HomeController : Controller
    { 
      [HttpGet("/")]
      public ActionResult Index()
      {     
        return View();
      
      }
    }
}