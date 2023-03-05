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
    public Dictionary<string, int> Rates { get; set; }
    public int Id { get; }
    public List<Order> Orders = new List<Order> { };
    private static List<Vendor> _instances = new List<Vendor> { };

    public Vendor(string name, string description, string phone, string email, Dictionary<string, int> rates)
    {
      Name = name;
      Description = description;
      Phone = phone;
      Email = email;
      Rates = rates;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }

    public int GetTotal(Dictionary<string, int> productAmounts) {
      int total = 0;
      foreach (var productEntry in productAmounts) {
        total += productEntry.Value * this.Rates[productEntry.Key];
      }
      return total;
    }

    public void DeleteOrder(int orderId) {
      Order doomedOrder = Order.Find(orderId);
      this.Orders.Remove(doomedOrder);
    }
    public void DeleteAllOrders() {
      this.Orders.Clear();
    }

    public static List<Vendor> GetAll()
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

    public static Vendor Find(int searchId)
    {
      Vendor foundInstance = null;
      foreach (var instance in _instances) {
        if (instance.Id == searchId) {
          foundInstance = instance;
        }
      }
      return foundInstance;
    }
  }
}
