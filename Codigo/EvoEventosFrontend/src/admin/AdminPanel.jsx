import { useMemo, useState } from 'react'
import { Calendar, CircleCheck, Clock3, DollarSign, Eye, Plus, Search, TriangleAlert, Trash2 } from 'lucide-react'
import Logo from '../assets/Logo.svg'
import ExitIcon from '../assets/Icons/exit.svg'
import { currency, eventsSeed, inventorySeed, tabs } from './data'
import Card from './components/ui/Card'
import Badge from './components/ui/Badge'
import Input from './components/ui/Input'
import EventDetailsModal from './components/modals/EventDetailsModal'
import AddInventoryModal from './components/modals/AddInventoryModal'
import './admin.css'

function ask(message) {
  return window.confirm(message)
}

export default function AdminPanel() {
  const [section, setSection] = useState('Eventos')
  const [events, setEvents] = useState(eventsSeed)
  const [inventory, setInventory] = useState(inventorySeed)
  const [search, setSearch] = useState('')
  const [selectedEvent, setSelectedEvent] = useState(null)
  const [openAddItem, setOpenAddItem] = useState(false)

  const eventFiltered = useMemo(
    () => events.filter((e) => `${e.title} ${e.client}`.toLowerCase().includes(search.toLowerCase())),
    [events, search],
  )

  const itemFiltered = useMemo(
    () => inventory.filter((i) => `${i.name} ${i.description}`.toLowerCase().includes(search.toLowerCase())),
    [inventory, search],
  )

  function removeItem(id, type) {
    const ok = ask('Advertencia: esta accion eliminara el registro. Deseas continuar?')
    if (!ok) return
    if (type === 'event') setEvents((p) => p.filter((x) => x.id !== id))
    else setInventory((p) => p.filter((x) => x.id !== id))
  }

  return (
    <div className="ad-root">
      <header className="ad-header">
        <div className="ad-header__left"><img src={Logo} alt="EvoEventos" /><span>Panel de Administracion</span></div>
        <button className="ad-btn" type="button" onClick={() => ask('Deseas cerrar sesion?')}><img src={ExitIcon} alt="" />Salir</button>
      </header>

      <nav className="ad-tabs">
        {tabs.map((t) => (
          <button key={t} type="button" className={section === t ? 'is-active' : ''} onClick={() => setSection(t)}>{t}</button>
        ))}
      </nav>

      <main className="ad-main">
        {(section === 'Eventos' || section === 'Inventario') && (
          <>
            <div className="ad-head">
              <div>
                <h1>{section === 'Eventos' ? 'Gestion de eventos' : 'Gestion de Inventario'}</h1>
                <p>{section === 'Eventos' ? 'Administra todos los eventos de la empresa' : 'Administra equipos, mobiliario e inflables'}</p>
              </div>
              <div className="ad-actions">
                {section === 'Eventos' ? (
                  <>
                    <button className="ad-btn ad-btn--primary" type="button" onClick={() => ask('Registrar pago para evento seleccionado?')}><Plus size={16} />Registrar Pago</button>
                    <button className="ad-btn ad-btn--primary" type="button" onClick={() => ask('Crear nuevo evento?')}><Plus size={16} />Nuevo Evento</button>
                  </>
                ) : (
                  <button className="ad-btn ad-btn--primary" type="button" onClick={() => setOpenAddItem(true)}><Plus size={16} />Agregar Item</button>
                )}
              </div>
            </div>

            <section className="ad-stats">
              <Card><small>Total</small><strong>{section === 'Eventos' ? events.length : inventory.length}</strong><Badge tone="purple"><Calendar size={12} />items</Badge></Card>
              <Card><small>Confirmados / Mantenimiento</small><strong>1</strong><Badge tone="yellow"><TriangleAlert size={12} />estado</Badge></Card>
              <Card><small>Pendientes / Disponibles</small><strong>3</strong><Badge tone="green"><CircleCheck size={12} />ok</Badge></Card>
              <Card><small>Valor total</small><strong>{currency(12000)}</strong><Badge tone="blue"><DollarSign size={12} />COP</Badge></Card>
            </section>

            <section className="ad-toolbar">
              <Input placeholder={section === 'Eventos' ? 'Buscar eventos por nombre o cliente...' : 'Buscar items por nombre o descripcion...'} value={search} onChange={(e) => setSearch(e.target.value)} />
              <button className="ad-filter"><Search size={15} />Todos los estados</button>
            </section>
          </>
        )}

        {section === 'Eventos' && (
          <div className="ad-grid">
            {eventFiltered.map((event) => (
              <Card key={event.id}>
                <div className="ad-card-head">
                  <div><h3>{event.title}</h3><p>Cliente: {event.client}</p></div>
                  <div className="ad-mini-actions">
                    <button className="ad-icon-btn" type="button" onClick={() => setSelectedEvent(event)}><Eye size={15} /></button>
                    <button className="ad-icon-btn" type="button" onClick={() => ask('Editar evento?')}><Clock3 size={15} /></button>
                    <button className="ad-icon-btn" type="button" onClick={() => removeItem(event.id, 'event')}><Trash2 size={15} /></button>
                  </div>
                </div>
                <div className="ad-tags"><Badge tone="purple">{event.kind}</Badge><Badge tone="green">{event.status}</Badge></div>
                <p className="ad-muted">{event.date} · {event.hour}</p>
                <p className="ad-muted">{event.place}</p>
                <p className="ad-muted">Asesor: {event.advisor}</p>
                <footer className="ad-card-money">
                  <div><small>Total</small><strong>{currency(event.total)}</strong></div>
                  <div><small>Anticipo</small><strong className="ok">{currency(event.advance)}</strong></div>
                  <div><small>Pendiente</small><strong className="bad">{currency(event.pending)}</strong></div>
                </footer>
              </Card>
            ))}
          </div>
        )}

        {section === 'Inventario' && (
          <div className="ad-grid ad-grid--inventory">
            {itemFiltered.map((item) => (
              <Card key={item.id}>
                <div className="ad-card-head">
                  <div><h3>{item.name}</h3><p>{item.category}</p></div>
                  <div className="ad-mini-actions">
                    <button className="ad-icon-btn" type="button" onClick={() => ask('Editar item de inventario?')}><Clock3 size={15} /></button>
                    <button className="ad-icon-btn" type="button" onClick={() => removeItem(item.id, 'item')}><Trash2 size={15} /></button>
                  </div>
                </div>
                <div className="ad-tags"><Badge tone="blue">{item.category.toLowerCase()}</Badge><Badge tone={item.status === 'mantenimiento' ? 'yellow' : 'green'}>{item.status}</Badge></div>
                <p className="ad-muted">{item.description}</p>
                <div className="ad-stock-row"><div><small>Disponibilidad</small><strong>{item.stock}/{item.total}</strong></div><div><small>Precio</small><strong>{currency(item.price)}</strong></div></div>
                <div className="ad-stock-row"><div><small>Ubicacion</small><strong>{item.location}</strong></div><div><small>Ultimo mantenimiento</small><strong>{item.updatedAt}</strong></div></div>
              </Card>
            ))}
          </div>
        )}
      </main>

      <EventDetailsModal open={Boolean(selectedEvent)} event={selectedEvent} onClose={() => setSelectedEvent(null)} />
      <AddInventoryModal open={openAddItem} onClose={() => setOpenAddItem(false)} onSubmit={(item) => {
        if (!ask('Confirmar alta del nuevo item en inventario?')) return
        setInventory((prev) => [item, ...prev])
        setOpenAddItem(false)
      }} />
    </div>
  )
}
