// ==========================
// Carrito persistente con localStorage
// ==========================
(function () {
    const CART_KEY = "sitioLibrosCart";

    // Formateador de precios (en centavos → ARS)
    const fmt = n => new Intl.NumberFormat("es-AR", { style: "currency", currency: "ARS" }).format(n / 100);

    // --------------------------
    // Estado del carrito
    // --------------------------
    const state = {
        items: JSON.parse(localStorage.getItem(CART_KEY) || "[]"),

        save() {
            localStorage.setItem(CART_KEY, JSON.stringify(this.items));
        },

        clear() {
            this.items = [];
            this.save();
        },

        addItem({ id, title, price, qty }) {
            const found = this.items.find(x => x.id == id);
            if (found) found.qty += qty;
            else this.items.push({ id, title, price, qty });
            this.save();
        },

        updateQty(id, delta) {
            const item = this.items.find(x => x.id == id);
            if (!item) return;
            item.qty = Math.max(1, item.qty + delta);
            this.save();
        },

        remove(id) {
            this.items = this.items.filter(x => x.id != id);
            this.save();
        },

        get count() {
            return this.items.reduce((a, it) => a + it.qty, 0);
        },

        get subtotal() {
            return this.items.reduce((a, it) => a + it.price * it.qty, 0);
        }
    };

    // --------------------------
    // Actualiza el número del carrito (navbar)
    // --------------------------
    function syncBadge() {
        const badge = document.getElementById("cart-count");
        if (badge) badge.textContent = state.count;
    }

    // --------------------------
    // Renderiza la página /cart
    // --------------------------
    function renderCartPage() {
        const list = document.getElementById("cart-items");
        if (!list) return;

        list.innerHTML = "";
        if (state.items.length === 0) {
            list.innerHTML = `<div class="list-group-item text-muted">Tu carrito está vacío.</div>`;
        } else {
            state.items.forEach(it => {
                const li = document.createElement("div");
                li.className = "list-group-item d-flex justify-content-between align-items-center";
                li.innerHTML = `
          <div>
            <div class="fw-semibold">${it.title}</div>
            <div class="small text-muted">Precio: ${fmt(it.price)} · Cantidad: ${it.qty}</div>
          </div>
          <div class="d-flex align-items-center gap-2">
            <button class="btn btn-sm btn-outline-secondary btn-dec" data-id="${it.id}">-</button>
            <button class="btn btn-sm btn-outline-secondary btn-inc" data-id="${it.id}">+</button>
            <button class="btn btn-sm btn-outline-danger btn-rem" data-id="${it.id}">Eliminar</button>
          </div>`;
                list.appendChild(li);
            });
        }

        const subtotalEl = document.getElementById("cart-subtotal");
        const totalEl = document.getElementById("cart-total");

        if (subtotalEl) subtotalEl.textContent = fmt(state.subtotal);
        if (totalEl) totalEl.textContent = fmt(state.subtotal);

        // Eventos de botones +, -, eliminar
        list.querySelectorAll(".btn-inc").forEach(b =>
            b.addEventListener("click", e => {
                state.updateQty(e.target.dataset.id, +1);
                renderCartPage();
                syncBadge();
            })
        );

        list.querySelectorAll(".btn-dec").forEach(b =>
            b.addEventListener("click", e => {
                state.updateQty(e.target.dataset.id, -1);
                renderCartPage();
                syncBadge();
            })
        );

        list.querySelectorAll(".btn-rem").forEach(b =>
            b.addEventListener("click", e => {
                state.remove(e.target.dataset.id);
                renderCartPage();
                syncBadge();
            })
        );
    }

    // --------------------------
    // Escucha el click "Agregar al carrito"
    // --------------------------
    document.addEventListener("click", ev => {
        const btn = ev.target.closest(".add-to-cart");
        if (!btn) return;

        const id = btn.dataset.productId;
        const title = btn.dataset.title || "Libro";
        const price = parseInt(btn.dataset.price || "10000", 10);
        const qtyInput = document.querySelector(".qty-input");
        const qty = qtyInput ? parseInt(qtyInput.value || "1", 10) : 1;

        state.addItem({ id, title, price, qty });
        syncBadge();

        // Aviso simple al usuario
        const toast = document.createElement("div");
        toast.textContent = "✅ Producto agregado al carrito";
        toast.className = "position-fixed bottom-0 end-0 mb-3 me-3 p-2 bg-success text-white rounded shadow";
        document.body.appendChild(toast);
        setTimeout(() => toast.remove(), 2000);
    });

    // --------------------------
    // Al cargar cualquier página
    // --------------------------
    document.addEventListener("DOMContentLoaded", () => {
        syncBadge();
        renderCartPage();
    });
})();