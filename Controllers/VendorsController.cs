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
      model.Add("Vendor", selectedVendors);
      model.Add("Order", vendorsOrders);
      return View(model);
    }
   }
}