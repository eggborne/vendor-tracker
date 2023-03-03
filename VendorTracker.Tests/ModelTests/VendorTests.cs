using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using VendorTracker.Models;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    // public void Dispose()
    // {
    //   Item.ClearAll();
    // }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      PuzzleString newVendor = new Vendor();
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

  }
}