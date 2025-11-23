using Libreria_PNT1.Data;
using Libreria_PNT1.Extensions;
using Libreria_PNT1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Libreria_PNT1.Controllers.CartController;

namespace Libreria_PNT1.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;

        public CheckoutController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Checkout => muestra formulario + resumen
        [HttpGet]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                       ?? new List<CartItem>();

            if (!cart.Any())
            {
                TempData["CheckoutMessage"] = "Tu carrito está vacío.";
                return RedirectToAction("Index", "Home");
            }

            var vm = new CheckoutViewModel
            {
                Items = cart,
                Subtotal = cart.Sum(i => i.Subtotal)
            };

            return View(vm);
        }

        // POST /Checkout => guarda cliente + pedido + items
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart")
                       ?? new List<CartItem>();

            if (!cart.Any())
            {
                TempData["CheckoutMessage"] = "Tu carrito está vacío.";
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                // Si hay errores en el formulario, vuelvo a mostrar la vista con el carrito
                model.Items = cart;
                model.Subtotal = cart.Sum(i => i.Subtotal);
                return View(model);
            }

            // 1) Crear cliente
            var cliente = new ClienteEntity
            {
                Nombre = model.Nombre,
                Email = model.Email,
                Direccion = model.Direccion,
                // Agregá más campos si tu entidad los tiene
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync(); // genera IdCliente

            // 2) Crear pedido (HistorialPedidos)
            var total = cart.Sum(i => i.Subtotal);

            var pedido = new HistorialPedidoEntity
            {
                Fecha = DateTime.Now,
                Total = total,
                IdCliente = cliente.IdCliente
            };

            _context.HistorialPedidos.Add(pedido);
            await _context.SaveChangesAsync(); // genera IdPedido

            // 3) Crear items de pedido + descontar stock
            foreach (var item in cart)
            {
                var libroEntity = await _context.Libros
                    .FirstOrDefaultAsync(l => l.IdLibro == item.IdLibro);

                if (libroEntity == null)
                    continue;

                var cantidadFinal = item.Cantidad;
                if (cantidadFinal > libroEntity.Stock)
                    cantidadFinal = libroEntity.Stock;

                libroEntity.Stock -= cantidadFinal;
                if (libroEntity.Stock <= 0)
                {
                    libroEntity.Stock = 0;
                    libroEntity.Disponible = false;
                }

                var itemPedido = new ItemPedidoEntity
                {
                    IdPedido = pedido.IdPedido,
                    IdLibro = libroEntity.IdLibro,
                    Cantidad = cantidadFinal,
                    PrecioUnitario = (decimal)libroEntity.Precio
                };

                _context.ItemsPedido.Add(itemPedido);
            }

            await _context.SaveChangesAsync();

            // 4) Vaciar carrito
            HttpContext.Session.SetObjectAsJson("Cart", new List<CartItem>());
            HttpContext.Session.SetInt32("CartCount", 0);

            // 5) Mensaje y vuelta al home
            TempData["CheckoutMessage"] = "¡Gracias por tu compra!";
            return RedirectToAction("Index", "Home");
        }
    }
}
