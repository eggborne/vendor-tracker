using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
      public int OrderId { get; set; }
      public string Date { get; set; }
      public int BreadAmount { get; set; }
      public int PastryAmount { get; set; }
      public int TotalPrice { get; set; }
      public Vendor Vendor { get; set; }
  }
}
