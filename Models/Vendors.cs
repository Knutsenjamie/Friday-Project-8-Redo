using System.Collections.Generic;

namespace PierresOrderForm.Models 
{
    public class Vendors
    {
        private static List<Vendors> _instances = new() { };
        public string VendorsName { get; set; }
        public string VendorDescription { get; set; }
        public int Id { get; }
        public List<Orders> Orders { get; set; }



        public Vendors(string vendorsName, string vendorDescription)
        {
            VendorsName = vendorsName;
            VendorDescription = vendorDescription;
            _instances.Add(this);
            Id = _instances.Count;
            Orders = new List<Orders>{};
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<Vendors> GetAll()
        {
            return _instances;
        }

        public static Vendors Find(int searchId)
        {
            return _instances[searchId-1];
        }

        public void AddOrders(Orders orders)
        {
            Orders.Add(orders);
        }

    }
}