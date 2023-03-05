using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Date { get; set; }
    public string BreadAmount {get; set;}
    public string PastryAmount { get; set; }
    public int TotalPrice { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };
    public Order(string date, string breadAmount, string pastryAmount, int totalPrice)
    {
      Date = date;
      BreadAmount = breadAmount;
      PastryAmount = pastryAmount;
      TotalPrice = totalPrice;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public void Delete()
    {
      _instances.Remove(this);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      Order foundInstance = null;
      foreach (var instance in _instances) {
        if (instance.Id == searchId) {
          foundInstance = instance;
        }
      }
      return foundInstance;
    }
  }
}
