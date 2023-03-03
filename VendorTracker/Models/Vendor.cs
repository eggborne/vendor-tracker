using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name {get; set;}
    public string Description { get; set; }
    public string BreadPerMonth { get; set; }
    public string PastriesPerMonth { get; set; }
    public int Id { get; }
    private static List<Order> _orders = new List<Order> { };
    private static List<Vendor> _instances = new List<Vendor> { };

    public Vendor(string name, string description, string breadPerMonth, string pastriesPerMonth)
    {
      Name = name;
      Description = description;
      BreadPerMonth = breadPerMonth;
      PastriesPerMonth = pastriesPerMonth;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
