import CastilloInflable from '@assets/Images/CastilloInflable.jpg'
import MaquinaCotton from '@assets/Images/MaquinaCotton.jpg'
import Catering from '@assets/Images/Catering.jpg'
import EquipoSonido from '@assets/Images/EquipoSonido.jpg'
import Carpas from '@assets/Images/Carpas.jpg'
import Mobiliario from '@assets/Images/Mobiliario.jpg'

import './ProductsSection.css'




const ProductsSection = () => {
  return (
    <section className="productos-section">
      <div className="section-header">
        <h2 className="section-title">Nuestros Productos</h2>
        <p className="section-description--unique">Descubre nuestra amplia gama de productos y servicios para hacer
          de tu
          evento algo extraordinario</p>
      </div>

      <div className="productos-grid">
        <div className="producto-card">
          <span className="producto-badge">Juegos</span>
          <img src={CastilloInflable} alt="Castillos Inflables"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Castillos Inflables</h3>
            <p>Castillos inflables seguros y divertidos para todas las edades</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>

        <div className="producto-card">
          <span className="producto-badge">Confitería</span>
          <img src={MaquinaCotton} alt="Máquinas de Algodón"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Máquinas de Algodón</h3>
            <p>Máquinas profesionales de algodón de azúcar y palomitas</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>

        <div className="producto-card">
          <span className="producto-badge">Alimentación</span>
          <img src={Catering} alt="Servicio de Catering"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Servicio de Catering</h3>
            <p>Buffets completos y menús personalizados para tu evento</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>

        <div className="producto-card">
          <span className="producto-badge">Audio/Video</span>
          <img src={EquipoSonido} alt="Equipo de Sonido"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Equipo de Sonido</h3>
            <p>Sistemas de sonido profesional y equipo de DJ</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>

        <div className="producto-card">
          <span className="producto-badge">Ambientación</span>
          <img src={Carpas} alt="Carpas y Decoración"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Carpas y Decoración</h3>
            <p>Carpas elegantes y decoración temática personalizada</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>

        <div className="producto-card">
          <span className="producto-badge">Muebles</span>
          <img src={Mobiliario} alt="Mobiliario"
            className="producto-imagen" />
          <div className="producto-info">
            <h3>Mobiliario</h3>
            <p>Mesas, sillas y mobiliario elegante para cualquier ocasión</p>
            <button className="btn-producto">Ver Detalles</button>
          </div>
        </div>
      </div>

      <div className="ver-inventario">
        <button className="btn-inventario">Ver Todo el Inventario</button>
      </div>
    </section>
  )
}

export default ProductsSection
