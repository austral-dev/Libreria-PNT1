using Libreria_PNT1.Data;
using Libreria_PNT1.Extensions;
using Libreria_PNT1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Libreria_PNT1.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // ----------------- Modelo interno del carrito -----------------
        public class CartItem
        {
            public int IdLibro { get; set; }
            public string Titulo { get; set; } = string.Empty;
            public string Autor { get; set; } = string.Empty;
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal => PrecioUnitario * Cantidad;
        }

        // Helpers de sesión
        private List<CartItem> GetCart()
        {
            return HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                   ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            HttpContext.Session.SetInt32("CartCount", cart.Sum(i => i.Cantidad));
        }

        // ----------------- Acciones -----------------

        // GET /Cart
        public IActionResult Index()
        {
            var cart = GetCart();
            var subtotal = cart.Sum(i => i.Subtotal);
            ViewBag.Subtotal = subtotal;

            return View(cart);
        }

        // POST /Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, int cantidad)
        {
            if (cantidad <= 0) cantidad = 1;

            // Buscar libro en BD
            var libroEntity = await _context.Libros
                                            .FirstOrDefaultAsync(l => l.IdLibro == id);

            if (libroEntity == null || !libroEntity.Disponible)
            {
                TempData["CheckoutMessage"] = "El libro no está disponible.";
                return RedirectToAction("Index", "Products");
            }

            var cart = GetCart();

            var existing = cart.FirstOrDefault(i => i.IdLibro == id);
            if (existing == null)
            {
                cart.Add(new CartItem
                {
                    IdLibro = libroEntity.IdLibro,
                    Titulo = libroEntity.Titulo,
                    Autor = libroEntity.Autor,
                    PrecioUnitario = (decimal)libroEntity.Precio,
                    Cantidad = cantidad
                });
            }
            else
            {
                existing.Cantidad += cantidad;
            }

            SaveCart(cart);

            return RedirectToAction("Index");
        }

        // POST /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(i => i.IdLibro == id);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }
    }
}
