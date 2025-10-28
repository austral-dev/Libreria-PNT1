using Microsoft.AspNetCore.Mvc;

public class CartController : Controller
{
    public IActionResult Index() => View();

    [HttpPost] public IActionResult Add([FromBody] object req) => Json(new { ok = true });
    [HttpPost] public IActionResult Update([FromBody] object req) => Json(new { ok = true });
    [HttpPost] public IActionResult Remove([FromBody] object req) => Json(new { ok = true });
}
