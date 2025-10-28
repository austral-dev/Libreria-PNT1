using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(int id)
    {
        return View();
    }
}