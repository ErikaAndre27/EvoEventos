import { useEffect, useState } from 'react'

const empty = {
  title: '',
  client: '',
  kind: '',
  status: 'pendiente_pago',
  date: '',
  hour: '',
  place: '',
  advisor: '',
  guests: '',
  total: '',
  advance: '',
  services: '',
  note: '',
}

function toForm(event) {
  if (!event) return empty
  return {
    title: event.title ?? '',
    client: event.client ?? '',
    kind: event.kind ?? '',
    status: event.status ?? 'pendiente_pago',
    date: event.date ?? '',
    hour: event.hour ?? '',
    place: event.place ?? '',
    advisor: event.advisor ?? '',
    guests: event.guests != null ? String(event.guests) : '',
    total: event.total != null ? String(event.total) : '',
    advance: event.advance != null ? String(event.advance) : '',
    services: Array.isArray(event.services) ? event.services.join(', ') : '',
    note: event.note ?? '',
  }
}

export default function AddEventModal({ open, onClose, onSubmit, editEvent = null }) {
  const isEdit = Boolean(editEvent)
  const [form, setForm] = useState(empty)

  // Populate form when editing
  useEffect(() => {
    setForm(isEdit ? toForm(editEvent) : empty)
  }, [editEvent, open])

  if (!open) return null

  const set = (k, v) => setForm((p) => ({ ...p, [k]: v }))

  function handleSubmit(e) {
    e.preventDefault()
    const total = Number(form.total || 0)
    const advance = Number(form.advance || 0)
    onSubmit({
      ...(isEdit ? { id: editEvent.id } : { id: `EV-${Date.now()}` }),
      title: form.title,
      client: form.client,
      kind: form.kind || 'general',
      status: form.status,
      date: form.date,
      hour: form.hour,
      place: form.place,
      advisor: form.advisor,
      guests: Number(form.guests || 0),
      total,
      advance,
      pending: total - advance < 0 ? 0 : total - advance,
      services: form.services ? form.services.split(',').map((s) => s.trim()).filter(Boolean) : [],
      note: form.note || '',
    })
    setForm(empty)
  }

  const selectStyle = { border: '1px solid var(--ad-border)', borderRadius: 10, padding: 10, font: 'inherit' }

  return (
    <div className="ad-overlay" onMouseDown={onClose} role="presentation">
      <section className="ad-modal" onMouseDown={(e) => e.stopPropagation()}>
        <header className="ad-modal__header">
          <h3>{isEdit ? 'Editar Evento' : 'Nuevo Evento'}</h3>
          <button className="ad-icon-btn" type="button" onClick={onClose}>×</button>
        </header>
        <p className="ad-muted">{isEdit ? 'Modifica la informacion del evento' : 'Completa la informacion del nuevo evento'}</p>
        <form className="ad-form" onSubmit={handleSubmit}>
          <div className="ad-grid-2">
            <label>
              Nombre del Evento
              <input value={form.title} onChange={(e) => set('title', e.target.value)} required placeholder="Ej: Boda de Ana Lopez" />
            </label>
            <label>
              Cliente
              <input value={form.client} onChange={(e) => set('client', e.target.value)} required placeholder="Nombre del cliente" />
            </label>
            <label>
              Tipo de Evento
              <select value={form.kind} onChange={(e) => set('kind', e.target.value)} style={selectStyle}>
                <option value="">Seleccionar tipo</option>
                <option value="boda">Boda</option>
                <option value="corporativo">Corporativo</option>
                <option value="cumpleanos">Cumpleaños</option>
                <option value="quinceanos">Quinceaños</option>
                <option value="grado">Grado</option>
                <option value="otro">Otro</option>
              </select>
            </label>
            <label>
              Estado
              <select value={form.status} onChange={(e) => set('status', e.target.value)} style={selectStyle}>
                <option value="confirmado">Confirmado</option>
                <option value="pendiente_pago">Pendiente de Pago</option>
                <option value="cancelado">Cancelado</option>
              </select>
            </label>
            <label>
              Fecha
              <input type="date" value={form.date} onChange={(e) => set('date', e.target.value)} required />
            </label>
            <label>
              Hora
              <input type="time" value={form.hour} onChange={(e) => set('hour', e.target.value)} />
            </label>
            <label>
              Lugar
              <input value={form.place} onChange={(e) => set('place', e.target.value)} placeholder="Ej: Salon Versalles, Bogota" />
            </label>
            <label>
              Asesor
              <input value={form.advisor} onChange={(e) => set('advisor', e.target.value)} placeholder="Nombre del asesor" />
            </label>
            <label>
              N° de Invitados
              <input type="number" min="0" value={form.guests} onChange={(e) => set('guests', e.target.value)} placeholder="Ej: 150" />
            </label>
            <label>
              Valor Total (COP)
              <input type="number" min="0" value={form.total} onChange={(e) => set('total', e.target.value)} placeholder="0" />
            </label>
            <label>
              Anticipo Recibido (COP)
              <input type="number" min="0" value={form.advance} onChange={(e) => set('advance', e.target.value)} placeholder="0" />
            </label>
          </div>
          <label>
            Servicios (separados por coma)
            <input value={form.services} onChange={(e) => set('services', e.target.value)} placeholder="Ej: Decoracion, Sonido, Catering" />
          </label>
          <label>
            Notas
            <textarea value={form.note} onChange={(e) => set('note', e.target.value)} placeholder="Observaciones adicionales..." />
          </label>
          <div className="ad-actions">
            <button type="submit" className="ad-btn ad-btn--primary">{isEdit ? 'Guardar Cambios' : 'Crear Evento'}</button>
            <button type="button" className="ad-btn" onClick={onClose}>Cancelar</button>
          </div>
        </form>
      </section>
    </div>
  )
}
