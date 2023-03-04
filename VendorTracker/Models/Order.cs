using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Date { get; set; }
    public string BreadAmount {get; set;}
    public string PastryAmount { get; set; }
    public string TotalPrice { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };
    public Order(string date, string breadAmount, string pastryAmount)
    {
      Date = date;
      BreadAmount = breadAmount;
      PastryAmount = pastryAmount;

      TotalPrice = "12";

      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
