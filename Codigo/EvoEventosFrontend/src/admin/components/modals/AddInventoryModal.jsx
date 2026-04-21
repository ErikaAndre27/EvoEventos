import { useState } from 'react'

const empty = {
  name: '',
  category: '',
  stock: '',
  price: '',
  status: '',
  location: '',
  description: '',
}

export default function AddInventoryModal({ open, onClose, onSubmit }) {
  const [form, setForm] = useState(empty)

  if (!open) return null

  const set = (k, v) => setForm((p) => ({ ...p, [k]: v }))

  function handleSubmit(e) {
    e.preventDefault()
    onSubmit({
      id: `IT-${Date.now()}`,
      name: form.name,
      category: form.category || 'General',
      status: form.status || 'bueno',
      stock: Number(form.stock || 0),
      total: Number(form.stock || 0),
      price: Number(form.price || 0),
      location: form.location || 'Sin ubicacion',
      updatedAt: new Date().toISOString().slice(0, 10),
      description: form.description || 'Sin descripcion',
    })
    setForm(empty)
  }

  return (
    <div className="ad-overlay" onMouseDown={onClose} role="presentation">
      <section className="ad-modal" onMouseDown={(e) => e.stopPropagation()}>
        <header className="ad-modal__header">
          <h3>Agregar Nuevo Item al Inventario</h3>
          <button className="ad-icon-btn" type="button" onClick={onClose}>×</button>
        </header>
        <p className="ad-muted">Completa la informacion del nuevo equipo o inflable</p>
        <form className="ad-form" onSubmit={handleSubmit}>
          <div className="ad-grid-2">
            <label>Nombre del Item<input value={form.name} onChange={(e) => set('name', e.target.value)} required /></label>
            <label>Categoria<input value={form.category} onChange={(e) => set('category', e.target.value)} placeholder="Seleccionar categoria" /></label>
            <label>Cantidad<input type="number" min="0" value={form.stock} onChange={(e) => set('stock', e.target.value)} /></label>
            <label>Precio Unitario<input type="number" min="0" value={form.price} onChange={(e) => set('price', e.target.value)} /></label>
            <label>Estado<input value={form.status} onChange={(e) => set('status', e.target.value)} placeholder="Estado" /></label>
            <label>Ubicacion<input value={form.location} onChange={(e) => set('location', e.target.value)} placeholder="Ej: Bodega A-1" /></label>
          </div>
          <label>Descripcion<textarea value={form.description} onChange={(e) => set('description', e.target.value)} /></label>
          <div className="ad-actions">
            <button type="submit" className="ad-btn ad-btn--primary">Agregar Item</button>
            <button type="button" className="ad-btn" onClick={onClose}>Cancelar</button>
          </div>
        </form>
      </section>
    </div>
  )
}
