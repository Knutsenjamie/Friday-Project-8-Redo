using Microsoft.AspNetCore.Mvc;
using PierresOrderForm.Models;

namespace PierresOrderForm.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
  }
}