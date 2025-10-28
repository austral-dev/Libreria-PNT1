using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Details(int id) => View();
}