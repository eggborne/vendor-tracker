using System.Collections.Generic;
using System;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name {get; set;}
    public string Description { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Id { get; }
    public List<Order> Orders = new List<Order> { };
    private static List<Vendor> _instances = new List<Vendor> { };

    public Vendor(string name, string description, string phone, string email)
    {
      Name = name;
      Description = description;
      Phone = phone;
      Email = email;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
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
