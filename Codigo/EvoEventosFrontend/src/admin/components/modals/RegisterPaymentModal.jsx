import { useState } from 'react'
import { currency } from '../../data'

const empty = {
  amount: '',
  method: 'efectivo',
  reference: '',
  note: '',
}

export default function RegisterPaymentModal({ open, event, onClose, onSubmit }) {
  const [form, setForm] = useState(empty)

  if (!open || !event) return null

  const set = (k, v) => setForm((p) => ({ ...p, [k]: v }))

  function handleSubmit(e) {
    e.preventDefault()
    const amount = Number(form.amount || 0)
    if (amount <= 0) return
    onSubmit(event.id, amount, { method: form.method, reference: form.reference, note: form.note })
    setForm(empty)
  }

  return (
    <div className="ad-overlay" onMouseDown={onClose} role="presentation">
      <section className="ad-modal" onMouseDown={(e) => e.stopPropagation()}>
        <header className="ad-modal__header">
          <h3>Registrar Pago</h3>
          <button className="ad-icon-btn" type="button" onClick={onClose}>×</button>
        </header>
        <p className="ad-muted">Registra un pago para el evento seleccionado</p>

        <div className="ad-finance" style={{ marginBottom: 14 }}>
          <div><small>Evento</small><strong style={{ fontSize: '0.9rem' }}>{event.title}</strong></div>
          <div><small>Saldo Pendiente</small><strong className="bad">{currency(event.pending)}</strong></div>
          <div><small>Total Evento</small><strong>{currency(event.total)}</strong></div>
        </div>

        <form className="ad-form" onSubmit={handleSubmit}>
          <div className="ad-grid-2">
            <label>
              Monto del Pago (COP)
              <input
                type="number"
                min="1"
                max={event.pending}
                value={form.amount}
                onChange={(e) => set('amount', e.target.value)}
                required
                placeholder="0"
              />
            </label>
            <label>
              Metodo de Pago
              <select value={form.method} onChange={(e) => set('method', e.target.value)} style={{ border: '1px solid var(--ad-border)', borderRadius: 10, padding: 10, font: 'inherit' }}>
                <option value="efectivo">Efectivo</option>
                <option value="transferencia">Transferencia</option>
                <option value="tarjeta">Tarjeta</option>
                <option value="nequi">Nequi / Daviplata</option>
                <option value="cheque">Cheque</option>
              </select>
            </label>
          </div>
          <label>
            Referencia / Comprobante
            <input value={form.reference} onChange={(e) => set('reference', e.target.value)} placeholder="Numero de transaccion o referencia" />
          </label>
          <label>
            Notas
            <textarea value={form.note} onChange={(e) => set('note', e.target.value)} placeholder="Observaciones del pago..." />
          </label>
          <div className="ad-actions">
            <button type="submit" className="ad-btn ad-btn--primary">Registrar Pago</button>
            <button type="button" className="ad-btn" onClick={onClose}>Cancelar</button>
          </div>
        </form>
      </section>
    </div>
  )
}
