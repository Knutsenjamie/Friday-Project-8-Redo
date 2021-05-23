using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using PierresOrderForm.Models;

namespace PierresOrderForm.Controllers
{
  public class VendorsController : Controller
  {

    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendors> allVendors = Vendors.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorsName, string vendorDescription)
    {
      Vendors newVendors = new Vendors(vendorsName, vendorDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendors selectedVendors = Vendors.Find(id);
      List<Orders> vendorsOrders = selectedVendors.Orders;
      model.Add("vendors", selectedVendors);
      model.Add("orders", vendorsOrders);
      return View(model);
    }

        
    [HttpPost("/vendors/{vendorsID}/orders")]
    public ActionResult Create(int vendorsId, string ordersTitle, string ordersDescription, string ordersDate, string ordersPrice)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendors selectedVendors =  Vendors.Find(vendorsId);
      Orders newOrder = new Orders(ordersTitle, ordersDescription, ordersDate, ordersPrice);
      selectedVendors.AddOrders(newOrder);
      List<Orders> vendorsOrders = selectedVendors.Orders;
      model.Add("orders", vendorsOrders);
      model.Add("vendors", selectedVendors);
      return View("Show", model);
    }

   }
}