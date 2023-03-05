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
      string pastryAmount
    )
    {
      if (breadAmount == null) { breadAmount = "12"; }
      if (pastryAmount == null) { pastryAmount = "6"; }
      Vendor chosenVendor = Vendor.Find(vendorId);
      Dictionary<string, int> productAmounts = new Dictionary<string, int>();
      productAmounts["bread"] = int.Parse(breadAmount);
      productAmounts["pastry"] = int.Parse(pastryAmount);
      int totalPrice = chosenVendor.GetTotal(productAmounts);
      DateTime localDate = DateTime.Now;
      string dateString = localDate.ToString("MMMM dd, yyyy h:mm:ss tt");
      Order newOrder = new Order(dateString, breadAmount, pastryAmount, totalPrice);
      chosenVendor.AddOrder(newOrder);
      return View("Index", chosenVendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/delete")]
    public ActionResult DeleteAll(int vendorId)
    {
      Vendor chosenVendor = Vendor.Find(vendorId);
      chosenVendor.DeleteAllOrders();
      return View("Index", chosenVendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}/delete")]
    public ActionResult Destroy(int vendorId, int orderId)
    {
      Vendor chosenVendor = Vendor.Find(vendorId);
      chosenVendor.DeleteOrder(orderId);
      return View("Index", chosenVendor);
    }

    [HttpGet("/vendors/{vendorId}/orders/{orderId}/edit")]
    public ActionResult Edit(int vendorId, int orderId)
    {
      Order chosenOrder = Order.Find(orderId);
      return View(chosenOrder);
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}/edit")]
    public ActionResult Edit(
      int vendorId,
      int orderId,
      string breadAmount,
      string pastryAmount
    )
    {
      Order chosenOrder = Order.Find(orderId);
      Vendor orderVendor = Vendor.Find(vendorId);
      chosenOrder.BreadAmount = breadAmount;
      chosenOrder.PastryAmount = pastryAmount;
      Dictionary<string, int> productAmounts = new Dictionary<string, int>();
      productAmounts["bread"] = int.Parse(breadAmount);
      productAmounts["pastry"] = int.Parse(pastryAmount);
      int totalPrice = orderVendor.GetTotal(productAmounts);
      chosenOrder.TotalPrice = totalPrice;
      return View("Index", orderVendor);
    }
  }
}