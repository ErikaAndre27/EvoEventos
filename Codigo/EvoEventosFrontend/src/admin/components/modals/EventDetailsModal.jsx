import Badge from '../ui/Badge'
import { currency } from '../../data'

export default function EventDetailsModal({ open, event, onClose }) {
  if (!open || !event) return null

  return (
    <div className="ad-overlay" onMouseDown={onClose} role="presentation">
      <section className="ad-modal" onMouseDown={(e) => e.stopPropagation()}>
        <header className="ad-modal__header">
          <h3>Detalles del Evento</h3>
          <button className="ad-icon-btn" type="button" onClick={onClose}>
            ×
          </button>
        </header>
        <p className="ad-muted">Informacion completa del evento seleccionado</p>
        <div className="ad-grid-2">
          <div>
            <p className="ad-caption">Informacion General</p>
            <p><strong>Cliente:</strong> {event.client}</p>
            <p><strong>Asesor:</strong> {event.advisor}</p>
            <p><strong>Tipo:</strong> {event.kind}</p>
            <p><strong>Estado:</strong> <Badge tone="success">{event.status}</Badge></p>
          </div>
          <div>
            <p className="ad-caption">Fecha y Ubicacion</p>
            <p><strong>Fecha:</strong> {event.date}</p>
            <p><strong>Hora:</strong> {event.hour}</p>
            <p><strong>Ubicacion:</strong> {event.place}</p>
            <p><strong>Invitados:</strong> 120</p>
          </div>
        </div>
        <p className="ad-caption">Informacion Financiera</p>
        <div className="ad-finance">
          <div><small>Valor Total</small><strong>{currency(event.total)}</strong></div>
          <div><small>Anticipo Recibido</small><strong className="ok">{currency(event.advance)}</strong></div>
          <div><small>Saldo Pendiente</small><strong className="bad">{currency(event.pending)}</strong></div>
        </div>
        <p className="ad-caption">Servicios Incluidos</p>
        <div className="ad-tags">
          {event.services.map((s) => <Badge key={s}>{s}</Badge>)}
        </div>
        <p className="ad-caption">Notas</p>
        <div className="ad-note">{event.note}</div>
      </section>
    </div>
  )
}
