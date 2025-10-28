using Microsoft.AspNetCore.Mvc;

public class CheckoutController : Controller
{
    public IActionResult Index() => View();
    [HttpPost] public IActionResult Confirm() => RedirectToAction("Index", "Home");
}
