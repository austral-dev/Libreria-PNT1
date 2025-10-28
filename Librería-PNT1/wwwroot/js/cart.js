(function () {
    const fmt = n => new Intl.NumberFormat('es-AR', { style: 'currency', currency: 'ARS' }).format(n / 100);

    // Estado simple en memoria (mock hasta conectar backend)
    const state = {
        items: [], // {id, title, price, qty}
        get count() { return this.items.reduce((a, it) => a + it.qty, 0); },
        get subtotal() { return this.items.reduce((a, it) => a + it.price * it.qty, 0); }
    };

    function syncBadge() {
        const badge = document.getElementById('cart-count');
        if (badge) badge.textContent = state.count;
    }

    function renderCartPage() {
        const list = document.getElementById('cart-items');
        if (!list) return;

        list.innerHTML = '';
        if (state.items.length === 0) {
            list.innerHTML = `<div class="list-group-item text-muted">Tu carrito está vacío.</div>`;
        } else {
            state.items.forEach(it => {
                const li = document.createElement('div');
                li.className = 'list-group-item d-flex justify-content-between align-items-center';
                li.innerHTML = `
          <div>
            <div class="fw-semibold">${it.title}</div>
            <div class="small text-muted">Precio: ${fmt(it.price)} · Cantidad: ${it.qty}</div>
          </div>
          <div class="d-flex align-items-center gap-2">
            <button class="btn btn-sm btn-outline-secondary btn-dec" data-id="${it.id}">-</button>
            <button class="btn btn-sm btn-outline-secondary btn-inc" data-id="${it.id}">+</button>
            <button class="btn btn-sm btn-outline-danger btn-rem" data-id="${it.id}">Eliminar</button>
          </div>
        `;
                list.appendChild(li);
            });
        }
        const subtotalEl = document.getElementById('cart-subtotal');
        const totalEl = document.getElementById('cart-total');
        if (subtotalEl) subtotalEl.textContent = fmt(state.subtotal);
        if (totalEl) totalEl.textContent = fmt(state.subtotal);

        list.querySelectorAll('.btn-inc').forEach(b => b.addEventListener('click', e => { changeQty(e.target.dataset.id, +1); }));
        list.querySelectorAll('.btn-dec').forEach(b => b.addEventListener('click', e => { changeQty(e.target.dataset.id, -1); }));
        list.querySelectorAll('.btn-rem').forEach(b => b.addEventListener('click', e => { removeItem(e.target.dataset.id); }));
    }

    function changeQty(id, delta) {
        const item = state.items.find(x => x.id == id);
        if (!item) return;
        item.qty = Math.max(1, item.qty + delta);
        syncBadge();
        renderCartPage();
    }
    function removeItem(id) {
        state.items = state.items.filter(x => x.id != id);
        syncBadge();
        renderCartPage();
    }

    // Mock "API"
    function mockAddToCart({ id, title, price, qty }) {
        const found = state.items.find(x => x.id == id);
        if (found) found.qty += qty;
        else state.items.push({ id, title, price, qty });
        syncBadge();
    }

    // Hook "Agregar"
    document.addEventListener('click', (ev) => {
        const btn = ev.target.closest('.add-to-cart');
        if (!btn) return;
        const id = btn.dataset.productId;
        const title = btn.dataset.title || 'Libro';
        const price = parseInt(btn.dataset.price || '10000', 10); // centavos
        const qtyInput = document.querySelector('.qty-input');
        const qty = qtyInput ? parseInt(qtyInput.value || '1', 10) : 1;

        // Luego reemplazar por fetch('/cart/add', {...}) cuando esté el backend
        mockAddToCart({ id, title, price, qty });
    });

    document.addEventListener('DOMContentLoaded', () => {
        syncBadge();
        renderCartPage();
    });
})();