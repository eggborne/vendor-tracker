using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    static Dictionary<string, int> testRates = new Dictionary<string, int>
    {
        { "bread", 3 }, 
        { "pastry", 2 }
    };
    Vendor testVendor1 = new Vendor("Rabo Karabekian","Rabo's description", "5035551212", "rabo@rabo.net", testRates);
    Vendor testVendor2 = new Vendor("Frank's Doughnuts","Frank's description", "5035552323", "frank@dough.nuts", testRates);

    Order testOrder1 = new Order("3/03/2023", "12", "6", 48);
    Order testOrder2 = new Order("3/03/2023", "4", "1", 14);

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Assert.AreEqual(typeof(Vendor), testVendor1.GetType());
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorWithName_Vendor()
    {
      Assert.AreEqual("Rabo Karabekian", testVendor1.Name);
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorWithDescription_Vendor()
    {
      Assert.AreEqual("Rabo's description", testVendor1.Description);
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorWithPhone_Vendor()
    {
      Assert.AreEqual("5035551212", testVendor1.Phone);
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorWithEmail_Vendor()
    {
      Assert.AreEqual("rabo@rabo.net", testVendor1.Email);
    }

    [TestMethod]
    public void VendorConstructor_CreatesVendorWithRates_Vendor()
    {
      Assert.AreEqual(3, testVendor1.Rates["bread"]);
      Assert.AreEqual(2, testVendor1.Rates["pastry"]);
    }

    [TestMethod]
    public void VendorAddOrder_AddsOrderToOrdersList_Void()
    {
      testVendor1.AddOrder(testOrder1);

      Assert.AreEqual(testOrder1, testVendor1.Orders[0]);
    }

    [TestMethod]
    public void VendorGetAll_ReturnsList_List()
    {
      List<Vendor> vendorList = Vendor.GetAll();
      Assert.AreEqual(typeof(List<Vendor>), vendorList.GetType());
    }

    [TestMethod]
    public void VendorGetAll_ReturnsListOfVendors_List()
    {
      List<Vendor> vendorList = Vendor.GetAll();
      Assert.AreEqual(vendorList[0], testVendor1);
      Assert.AreEqual(vendorList[1], testVendor2);
    }

    [TestMethod]
    public void VendorClearAll_ClearsListOfVendors_Void()
    {
      int vendorListLengthBefore = Vendor.GetAll().Count;
      Vendor.ClearAll();
      int vendorListLengthAfter = Vendor.GetAll().Count;
      bool nowEmpty = vendorListLengthBefore == 2 && vendorListLengthAfter == 0;

      Assert.AreEqual(true, nowEmpty);
    }

    [TestMethod]
    public void VendorFind_ReturnsVendorWithId_Vendor()
    {
      Vendor secondVendor = Vendor.GetAll()[1];
      Vendor retrievedVendor = Vendor.Find(secondVendor.Id);

      Assert.AreEqual(secondVendor, retrievedVendor);
    }

    [TestMethod]
    public void VendorGetTotal_ReturnsSumOfProductPrices_Int()
    {
      int breadUnitsOrdered = int.Parse(testOrder1.BreadAmount);
      int pastryUnitsOrdered = int.Parse(testOrder1.PastryAmount);
      int breadRate = testVendor1.Rates["bread"];
      int pastryRate = testVendor1.Rates["pastry"];
      int expectedTotal = (breadUnitsOrdered * breadRate) + (pastryUnitsOrdered * pastryRate);
      Dictionary<string, int> productAmounts = new Dictionary<string, int>();
      productAmounts["bread"] = breadUnitsOrdered;
      productAmounts["pastry"] = pastryUnitsOrdered;
      
      Assert.AreEqual(testVendor1.GetTotal(productAmounts), expectedTotal);
    }

    [TestMethod]
    public void VendorDeleteAllOrders_EmptiesOrdersList_Void()
    {
      testVendor1.AddOrder(testOrder1);
      testVendor1.AddOrder(testOrder2);
      bool listHadOrdersBefore = testVendor1.Orders.Count == 2;
      testVendor1.DeleteAllOrders();
      bool listIsEmptyAfter = testVendor1.Orders.Count == 0;

      Assert.AreEqual(true, (listHadOrdersBefore && listIsEmptyAfter));
    }

    [TestMethod]
    public void VendorDeleteOrder_RemovesOrderFromOrdersList_Void()
    {
      testVendor1.AddOrder(testOrder1);
      bool existsInListBefore = testVendor1.Orders.Contains(testOrder1);
      testVendor1.DeleteOrder(testOrder1.Id);
      bool goneFromListAfter = !testVendor1.Orders.Contains(testOrder1);

      Assert.AreEqual(true, (existsInListBefore && goneFromListAfter));
    }

    [TestMethod]
    public void VendorDelete_RemovesSelfFromInstancesList_Void()
    {
      bool existsInListBefore = Vendor.GetAll().Contains(testVendor1);
      testVendor1.Delete();
      bool goneFromListAfter = !Vendor.GetAll().Contains(testVendor1);

      Assert.AreEqual(true, (existsInListBefore && goneFromListAfter));
    }
  }
}