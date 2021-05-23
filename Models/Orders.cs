using System.Collections.Generic;

namespace PierresOrderForm.Models 
{
    public class Orders
    {
        public string OrdersTitle { get; set; }
        public string OrdersDescription { get; set; }
        public string OrdersDate { get; set; }
        public int Id { get; }
        public string OrdersPrice  { get; set; }
        private static List<Orders> _instances = new() { };

        public Orders(string ordersTitle, string ordersDescription, string ordersDate, string ordersPrice)
        {
            OrdersTitle = ordersTitle;
            OrdersDescription = ordersDescription;
            OrdersDate = ordersDate; 
            OrdersPrice = ordersPrice;
            _instances.Add(this);
            Id = _instances.Count;
        }
        public static List<Orders> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }
        
        public static Orders Find(int searchId)
        {
            return _instances[searchId-1];
        }
    }
}