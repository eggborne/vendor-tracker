using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public int VendorId { get; set; }
    public string Name {get; set;}
    public string Description { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int BreadRate {get; set;}
    public int PastryRate { get; set; }
    public List<Order> Orders { get; set; }
  }
}