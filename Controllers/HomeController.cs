using Microsoft.AspNetCore.Mvc;

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