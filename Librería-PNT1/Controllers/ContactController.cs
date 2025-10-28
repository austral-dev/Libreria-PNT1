using Microsoft.AspNetCore.Mvc;

public class ContactController : Controller
{
    public IActionResult Index() => View();
    [HttpPost] public IActionResult Send() => RedirectToAction("Index");
}
