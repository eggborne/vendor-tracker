using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    Order testOrder1 = new Order("3/03/2023", "12", "6", "48");
    Order testOrder2 = new Order("3/03/2023", "12", "6", "48");

    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Assert.AreEqual(typeof(Order), testOrder1.GetType());
    }

    [TestMethod]
    public void OrderConstructor_CreatesOrderWithDate_Order()
    {
      Assert.AreEqual("3/03/2023", testOrder1.Date);
    }

    [TestMethod]
    public void OrderConstructor_CreatesOrderWithBreadAmount_Order()
    {
      Assert.AreEqual("12", testOrder1.BreadAmount);
    }

    [TestMethod]    
    public void OrderConstructor_CreatesOrderWithPastryAmount_Order()
    {
      Assert.AreEqual("6", testOrder1.PastryAmount);
    }

    [TestMethod]
    public void OrderConstructor_CreatesOrderWithTotalPrice_Order()
    {
      Assert.AreEqual("48", testOrder1.TotalPrice);
    }

    [TestMethod]
    public void OrderGetAll_ReturnsList_List()
    {
      List<Order> orderList = Order.GetAll();
      Assert.AreEqual(typeof(List<Order>), orderList.GetType());
    }

    [TestMethod]
    public void OrderGetAll_ReturnsListOfOrders_List()
    {
      List<Order> orderList = Order.GetAll();
      Assert.AreEqual(orderList[0], testOrder1);
      Assert.AreEqual(orderList[1], testOrder2);
    }

    [TestMethod]
    public void OrderClearAll_ClearsListOfOrders_Void()
    {
      int orderListLengthBefore = Order.GetAll().Count;
      Order.ClearAll();
      int orderListLengthAfter = Order.GetAll().Count;
      bool nowEmpty = orderListLengthBefore == 2 && orderListLengthAfter == 0;

      Assert.AreEqual(true, nowEmpty);
    }

    [TestMethod]
    public void OrderFind_ReturnsOrderWithId_Order()
    {
      Order secondOrder = Order.GetAll()[1];
      Order retrievedOrder = Order.Find(secondOrder.Id);

      Assert.AreEqual(secondOrder, retrievedOrder);
    }
  }
}