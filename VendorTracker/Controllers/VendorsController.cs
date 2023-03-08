using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VendorTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace VendorTracker.Controllers
{ 

  public class VendorsController : Controller
  { 
    private readonly VendorTrackerContext _db;

    public VendorsController(VendorTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Vendor> model = _db.Vendors
                          .Include(vendor => vendor.Orders)
                          .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Vendor vendor)
    {
      _db.Vendors.Add(vendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      return View(thisVendor);
    }

    [HttpPost]
    public ActionResult Edit(Vendor vendor)
    {
      _db.Vendors.Update(vendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Vendor thisVendor = _db.Vendors.FirstOrDefault(vendor => vendor.VendorId == id);
      _db.Vendors.Remove(thisVendor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}