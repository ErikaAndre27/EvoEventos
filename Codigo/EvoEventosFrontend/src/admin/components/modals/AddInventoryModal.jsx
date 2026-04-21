import { useEffect, useState } from 'react'

export const INVENTORY_CATEGORIES = [
  'Inflables',
  'Mobiliario',
  'Audiovisual',
  'Iluminacion',
  'Decoracion',
  'Catering',
  'Tarimas',
  'Otro',
]

export const INVENTORY_STATUSES = [
  { value: 'bueno', label: 'Bueno' },
  { value: 'excelente', label: 'Excelente' },
  { value: 'mantenimiento', label: 'En Mantenimiento' },
  { value: 'dañado', label: 'Dañado' },
]

const empty = {
  name: '',
  category: '',
  stock: '',
  price: '',
  status: '',
  location: '',
  description: '',
}

function toForm(item) {
  if (!item) return empty
  return {
    name: item.name ?? '',
    category: item.category ?? '',
    stock: item.stock != null ? String(item.stock) : '',
    price: item.price != null ? String(item.price) : '',
    status: item.status ?? '',
    location: item.location ?? '',
    description: item.description ?? '',
  }
}

export default function AddInventoryModal({ open, onClose, onSubmit, editItem = null }) {
  const isEdit = Boolean(editItem)
  const [form, setForm] = useState(empty)

  useEffect(() => {
    setForm(isEdit ? toForm(editItem) : empty)
  }, [editItem, open])

  if (!open) return null

  const set = (k, v) => setForm((p) => ({ ...p, [k]: v }))

  const selectStyle = {
    border: '1px solid var(--ad-border)',
    borderRadius: 10,
    padding: 10,
    font: 'inherit',
    background: '#f8f8fc',
    color: form.category || form.status ? '#3c3c56' : '#9a9ab0',
  }

  function handleSubmit(e) {
    e.preventDefault()
    const stock = Number(form.stock || 0)
    onSubmit({
      ...(isEdit ? { id: editItem.id, updatedAt: editItem.updatedAt } : { id: `IT-${Date.now()}`, updatedAt: new Date().toISOString().slice(0, 10) }),
      name: form.name,
      category: form.category || 'General',
      status: form.status || 'bueno',
      stock,
      total: isEdit ? editItem.total : stock,
      price: Number(form.price || 0),
      location: form.location || 'Sin ubicacion',
      description: form.description || 'Sin descripcion',
    })
    setForm(empty)
  }

  return (
    <div className="ad-overlay" onMouseDown={onClose} role="presentation">
      <section className="ad-modal" onMouseDown={(e) => e.stopPropagation()}>
        <header className="ad-modal__header">
          <h3>{isEdit ? 'Editar Item' : 'Agregar Nuevo Item al Inventario'}</h3>
          <button className="ad-icon-btn" type="button" onClick={onClose}>×</button>
        </header>
        <p className="ad-muted">Completa la informacion del nuevo equipo o inflable</p>
        <form className="ad-form" onSubmit={handleSubmit}>

          {/* Row 1: Nombre + Categoria */}
          <div className="ad-grid-2">
            <label>
              Nombre del Item
              <input
                value={form.name}
                onChange={(e) => set('name', e.target.value)}
                required
                placeholder="Ej: Mesa redonda"
              />
            </label>
            <label>
              Categoria
              <select value={form.category} onChange={(e) => set('category', e.target.value)} style={selectStyle}>
                <option value="">Seleccionar categoria</option>
                {INVENTORY_CATEGORIES.map((c) => (
                  <option key={c} value={c}>{c}</option>
                ))}
              </select>
            </label>
          </div>

          {/* Row 2: Cantidad + Precio + Estado */}
          <div className="ad-grid-3">
            <label>
              Cantidad
              <input
                type="number"
                min="0"
                value={form.stock}
                onChange={(e) => set('stock', e.target.value)}
                placeholder="0"
              />
            </label>
            <label>
              Precio Unitario
              <input
                type="number"
                min="0"
                value={form.price}
                onChange={(e) => set('price', e.target.value)}
                placeholder="$0"
              />
            </label>
            <label>
              Estado
              <select value={form.status} onChange={(e) => set('status', e.target.value)} style={{ ...selectStyle, color: form.status ? '#3c3c56' : '#9a9ab0' }}>
                <option value="">Estado</option>
                {INVENTORY_STATUSES.map((s) => (
                  <option key={s.value} value={s.value}>{s.label}</option>
                ))}
              </select>
            </label>
          </div>

          {/* Ubicacion */}
          <label>
            Ubicacion
            <input
              value={form.location}
              onChange={(e) => set('location', e.target.value)}
              placeholder="Ej: Bodega A-1"
            />
          </label>

          {/* Descripcion */}
          <label>
            Descripcion
            <textarea
              value={form.description}
              onChange={(e) => set('description', e.target.value)}
              placeholder="Descripcion detallada del item"
            />
          </label>

          <div className="ad-actions">
            <button type="submit" className="ad-btn ad-btn--primary" style={{ flex: 1, justifyContent: 'center' }}>
              {isEdit ? 'Guardar Cambios' : 'Agregar Item'}
            </button>
            <button type="button" className="ad-btn" style={{ flex: 1, justifyContent: 'center' }} onClick={onClose}>
              Cancelar
            </button>
          </div>
        </form>
      </section>
    </div>
  )
}
