import { useMemo, useState } from 'react'
import { Box, Calendar, CircleCheck, Clock3, DollarSign, Eye, Pencil, Plus, TriangleAlert, Trash2 } from 'lucide-react'
import Logo from '../assets/Logo.svg'
import ExitIcon from '../assets/Icons/exit.svg'
import { currency, eventsSeed, inventorySeed, tabs } from './data'
import Card from './components/ui/Card'
import Badge from './components/ui/Badge'
import Input from './components/ui/Input'
import EventDetailsModal from './components/modals/EventDetailsModal'
import AddInventoryModal, { INVENTORY_CATEGORIES } from './components/modals/AddInventoryModal'
import AddEventModal from './components/modals/AddEventModal'
import RegisterPaymentModal from './components/modals/RegisterPaymentModal'
import './admin.css'

const STATUS_OPTIONS = [
  { value: 'todos', label: 'Todos los estados' },
  { value: 'confirmado', label: 'Confirmado' },
  { value: 'pendiente_pago', label: 'Pendiente de Pago' },
  { value: 'cancelado', label: 'Cancelado' },
]

const STATUS_TONE = {
  confirmado: 'success',
  pendiente_pago: 'yellow',
  cancelado: 'red',
}

const STATUS_LABEL = {
  confirmado: 'Confirmada',
  pendiente_pago: 'Pendiente de Pago',
  cancelado: 'Cancelado',
}

const ITEM_STATUS_TONE = {
  bueno: 'green',
  excelente: 'success',
  mantenimiento: 'yellow',
  'dañado': 'red',
}

const ITEM_STATUS_LABEL = {
  bueno: 'bueno',
  excelente: 'excelente',
  mantenimiento: 'mantenimiento',
  'dañado': 'dañado',
}

function ask(message) {
  return window.confirm(message)
}

export default function AdminPanel() {
  const [section, setSection] = useState('Eventos')
  const [events, setEvents] = useState(eventsSeed)
  const [inventory, setInventory] = useState(inventorySeed)
  const [search, setSearch] = useState('')
  const [statusFilter, setStatusFilter] = useState('todos')
  const [categoryFilter, setCategoryFilter] = useState('todas')
  const [selectedEvent, setSelectedEvent] = useState(null)
  const [openAddItem, setOpenAddItem] = useState(false)
  const [editItem, setEditItem] = useState(null)
  const [openAddEvent, setOpenAddEvent] = useState(false)
  const [editEvent, setEditEvent] = useState(null)
  const [paymentEvent, setPaymentEvent] = useState(null)

  // ── Event stats ──────────────────────────────────────────────
  const totalEvents = events.length
  const confirmed = events.filter((e) => e.status === 'confirmado').length
  const pendingPayment = events.filter((e) => e.status === 'pendiente_pago').length
  const totalValue = events.reduce((acc, e) => acc + e.total, 0)

  // ── Filtered lists ───────────────────────────────────────────
  const eventFiltered = useMemo(() => {
    return events.filter((e) => {
      const matchSearch = `${e.title} ${e.client}`.toLowerCase().includes(search.toLowerCase())
      const matchStatus = statusFilter === 'todos' || e.status === statusFilter
      return matchSearch && matchStatus
    })
  }, [events, search, statusFilter])

  const itemFiltered = useMemo(() => {
    return inventory.filter((i) => {
      const matchSearch = `${i.name} ${i.description}`.toLowerCase().includes(search.toLowerCase())
      const matchCat = categoryFilter === 'todas' || i.category === categoryFilter
      return matchSearch && matchCat
    })
  }, [inventory, search, categoryFilter])

  // ── Handlers ─────────────────────────────────────────────────
  function removeItem(id, type) {
    const ok = ask('Advertencia: esta accion eliminara el registro. Deseas continuar?')
    if (!ok) return
    if (type === 'event') setEvents((p) => p.filter((x) => x.id !== id))
    else setInventory((p) => p.filter((x) => x.id !== id))
  }

  function handleAddEvent(event) {    if (editEvent) {
      // Update existing
      setEvents((prev) => prev.map((e) => (e.id === event.id ? event : e)))
      setEditEvent(null)
    } else {
      setEvents((prev) => [event, ...prev])
    }
    setOpenAddEvent(false)
  }

  function handleAddInventoryItem(item) {
    if (editItem) {
      setInventory((prev) => prev.map((i) => (i.id === item.id ? item : i)))
      setEditItem(null)
    } else {
      setInventory((prev) => [item, ...prev])
    }
    setOpenAddItem(false)
  }

  function handleRegisterPayment(eventId, amount) {
    setEvents((prev) =>
      prev.map((e) => {
        if (e.id !== eventId) return e
        const newAdvance = e.advance + amount
        const newPending = e.total - newAdvance
        return {
          ...e,
          advance: newAdvance,
          pending: newPending < 0 ? 0 : newPending,
          status: newPending <= 0 ? 'confirmado' : e.status,
        }
      }),
    )
    setPaymentEvent(null)
  }

  // ── Render ───────────────────────────────────────────────────
  return (
    <div className="ad-root">
      <header className="ad-header">
        <div className="ad-header__left"><img src={Logo} alt="EvoEventos" /><span>Panel de Administracion</span></div>
        <button className="ad-btn" type="button" onClick={() => ask('Deseas cerrar sesion?')}><img src={ExitIcon} alt="" />Salir</button>
      </header>

      <nav className="ad-tabs">
        {tabs.map((t) => (
          <button key={t} type="button" className={section === t ? 'is-active' : ''} onClick={() => { setSection(t); setSearch(''); setStatusFilter('todos'); setCategoryFilter('todas') }}>{t}</button>
        ))}
      </nav>

      <main className="ad-main">
        {(section === 'Eventos' || section === 'Inventario') && (
          <>
            <div className="ad-head">
              <div>
                <h1>{section === 'Eventos' ? 'Gestion de Eventos' : 'Gestion de Inventario'}</h1>
                <p>{section === 'Eventos' ? 'Administra todos los eventos de la empresa' : 'Administra equipos, mobiliario e inflables'}</p>
              </div>
              <div className="ad-actions">
                {section === 'Eventos' ? (
                  <>
                    <button className="ad-btn ad-btn--primary" type="button" onClick={() => setPaymentEvent(events[0] ?? null)}><Plus size={16} />Registrar Pago</button>
                    <button className="ad-btn ad-btn--primary" type="button" onClick={() => setOpenAddEvent(true)}><Plus size={16} />Nuevo Evento</button>
                  </>
                ) : (
                  <button className="ad-btn ad-btn--primary" type="button" onClick={() => setOpenAddItem(true)}><Plus size={16} />Agregar Item</button>
                )}
              </div>
            </div>

            {/* Stats */}
            {section === 'Eventos' ? (
              <section className="ad-stats">
                <Card>
                  <div className="ad-stat-row">
                    <div><small>Total Eventos</small><strong>{totalEvents}</strong></div>
                    <span className="ad-stat-icon ad-stat-icon--purple"><Calendar size={18} /></span>
                  </div>
                </Card>
                <Card>
                  <div className="ad-stat-row">
                    <div><small>Confirmados</small><strong>{confirmed}</strong></div>
                    <span className="ad-stat-icon ad-stat-icon--green"><CircleCheck size={18} /></span>
                  </div>
                </Card>
                <Card>
                  <div className="ad-stat-row">
                    <div><small>Pendiente de Pago</small><strong>{pendingPayment}</strong></div>
                    <span className="ad-stat-icon ad-stat-icon--yellow"><TriangleAlert size={18} /></span>
                  </div>
                </Card>
                <Card>
                  <div className="ad-stat-row">
                    <div><small>Valor Total</small><strong>{totalEvents > 0 ? currency(totalValue) : '—'}</strong></div>
                    <span className="ad-stat-icon ad-stat-icon--gray"><DollarSign size={18} /></span>
                  </div>
                </Card>
              </section>
            ) : (
              <section className="ad-stats">
                <Card><div className="ad-stat-row"><div><small>Total Items</small><strong>{inventory.length}</strong></div><span className="ad-stat-icon ad-stat-icon--purple"><Box size={18} /></span></div></Card>
                <Card><div className="ad-stat-row"><div><small>En Mantenimiento</small><strong>{inventory.filter((i) => i.status === 'mantenimiento').length}</strong></div><span className="ad-stat-icon ad-stat-icon--yellow"><TriangleAlert size={18} /></span></div></Card>
                <Card><div className="ad-stat-row"><div><small>Disponibles</small><strong>{inventory.filter((i) => i.status !== 'mantenimiento').length}</strong></div><span className="ad-stat-icon ad-stat-icon--green"><CircleCheck size={18} /></span></div></Card>
                <Card><div className="ad-stat-row"><div><small>Valor Total</small><strong>{currency(inventory.reduce((a, i) => a + i.price * i.total, 0))}</strong></div><span className="ad-stat-icon ad-stat-icon--purple"><Box size={18} /></span></div></Card>
              </section>
            )}

            <section className="ad-toolbar">
              <Input
                placeholder={section === 'Eventos' ? 'Buscar eventos por nombre o cliente...' : 'Buscar items por nombre o descripcion...'}
                value={search}
                onChange={(e) => setSearch(e.target.value)}
              />
              {section === 'Eventos' && (
                <select
                  className="ad-filter-select"
                  value={statusFilter}
                  onChange={(e) => setStatusFilter(e.target.value)}
                >
                  {STATUS_OPTIONS.map((o) => (
                    <option key={o.value} value={o.value}>{o.label}</option>
                  ))}
                </select>
              )}
              {section === 'Inventario' && (
                <select
                  className="ad-filter-select"
                  value={categoryFilter}
                  onChange={(e) => setCategoryFilter(e.target.value)}
                >
                  <option value="todas">Todas las categorias</option>
                  {INVENTORY_CATEGORIES.map((c) => (
                    <option key={c} value={c}>{c}</option>
                  ))}
                </select>
              )}
            </section>
          </>
        )}

        {section === 'Eventos' && (
          <div className="ad-grid">
            {eventFiltered.length === 0 && (
              <p className="ad-muted" style={{ gridColumn: '1/-1', textAlign: 'center', padding: '32px 0' }}>
                No se encontraron eventos.
              </p>
            )}
            {eventFiltered.map((event) => (
              <Card key={event.id}>
                <div className="ad-card-head">
                  <div><h3>{event.title}</h3><p>Cliente: {event.client}</p></div>
                  <div className="ad-mini-actions">
                    <button className="ad-icon-btn" type="button" title="Ver detalles" onClick={() => setSelectedEvent(event)}><Eye size={15} /></button>
                    <button className="ad-icon-btn" type="button" title="Registrar pago" onClick={() => setPaymentEvent(event)}><DollarSign size={15} /></button>
                    <button className="ad-icon-btn" type="button" title="Editar" onClick={() => { setEditEvent(event); setOpenAddEvent(true) }}><Pencil size={15} /></button>
                    <button className="ad-icon-btn" type="button" title="Eliminar" onClick={() => removeItem(event.id, 'event')}><Trash2 size={15} /></button>
                  </div>
                </div>
                <div className="ad-tags">
                  <Badge tone="purple">{event.kind}</Badge>
                  <Badge tone={STATUS_TONE[event.status] ?? 'neutral'}>{STATUS_LABEL[event.status] ?? event.status}</Badge>
                </div>
                <p className="ad-muted"><Calendar size={12} style={{ display: 'inline', marginRight: 4 }} />{event.date} &nbsp;<Clock3 size={12} style={{ display: 'inline', marginRight: 4 }} />{event.hour}</p>
                <p className="ad-muted">{event.place}</p>
                <p className="ad-muted"> Asesor: {event.advisor}</p>
                <footer className="ad-card-money">
                  <div><small>Valor Total</small><strong>{currency(event.total)}</strong></div>
                  <div><small>Anticipo</small><strong className="ok">{currency(event.advance)}</strong></div>
                  <div><small>Pendiente</small><strong className="bad">{currency(event.pending)}</strong></div>
                </footer>
              </Card>
            ))}
          </div>
        )}

        {section === 'Inventario' && (
          <div className="ad-grid ad-grid--inventory">
            {itemFiltered.length === 0 && (
              <p className="ad-muted" style={{ gridColumn: '1/-1', textAlign: 'center', padding: '32px 0' }}>
                No se encontraron items.
              </p>
            )}
            {itemFiltered.map((item) => (
              <Card key={item.id}>
                {/* Header: estado icon + nombre + acciones */}
                <div className="ad-card-head">
                  <div className="ad-inv-title">
                    <CircleCheck size={16} className={item.status === 'mantenimiento' ? 'inv-icon--yellow' : item.status === 'dañado' ? 'inv-icon--red' : 'inv-icon--green'} />
                    <div>
                      <h3>{item.name}</h3>
                      <p>{item.category}</p>
                    </div>
                  </div>
                  <div className="ad-mini-actions">
                    <button className="ad-icon-btn" type="button" title="Editar" onClick={() => { setEditItem(item); setOpenAddItem(true) }}><Pencil size={15} /></button>
                    <button className="ad-icon-btn ad-icon-btn--danger" type="button" title="Eliminar" onClick={() => removeItem(item.id, 'item')}><Trash2 size={15} /></button>
                  </div>
                </div>

                {/* Badge de estado */}
                <div className="ad-tags">
                  <Badge tone={ITEM_STATUS_TONE[item.status] ?? 'neutral'}>{ITEM_STATUS_LABEL[item.status] ?? item.status}</Badge>
                </div>

                {/* Descripcion */}
                <p className="ad-muted ad-inv-desc">{item.description}</p>

                {/* Disponibilidad + Precio */}
                <div className="ad-inv-row">
                  <div>
                    <small>Disponibilidad</small>
                    <strong className="ad-inv-avail">{item.stock}/{item.total}</strong>
                  </div>
                  <div>
                    <small>Precio</small>
                    <strong>${item.price}</strong>
                  </div>
                </div>

                {/* Ubicacion + Mantenimiento */}
                <div className="ad-inv-meta">
                  <div><span className="ad-inv-meta-label">Ubicacion:</span><strong>{item.location}</strong></div>
                  <div><span className="ad-inv-meta-label">Ultimo mantenimiento:</span><strong>{item.updatedAt}</strong></div>
                </div>
              </Card>
            ))}
          </div>
        )}
      </main>

      <EventDetailsModal open={Boolean(selectedEvent)} event={selectedEvent} onClose={() => setSelectedEvent(null)} />

      <AddInventoryModal
        open={openAddItem}
        onClose={() => { setOpenAddItem(false); setEditItem(null) }}
        onSubmit={handleAddInventoryItem}
        editItem={editItem}
      />

      <AddEventModal
        open={openAddEvent}
        onClose={() => { setOpenAddEvent(false); setEditEvent(null) }}
        onSubmit={handleAddEvent}
        editEvent={editEvent}
      />

      <RegisterPaymentModal
        open={Boolean(paymentEvent)}
        event={paymentEvent}
        onClose={() => setPaymentEvent(null)}
        onSubmit={handleRegisterPayment}
      />
    </div>
  )
}
