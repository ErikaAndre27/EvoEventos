import CastilloInflable from '@assets/Images/CastilloInflable.jpg'
import MaquinaCotton from '@assets/Images/MaquinaCotton.jpg'
import Catering from '@assets/Images/Catering.jpg'
import EquipoSonido from '@assets/Images/EquipoSonido.jpg'
import Carpas from '@assets/Images/Carpas.jpg'
import Mobiliario from '@assets/Images/Mobiliario.jpg'

import styles from './ProductsSection.module.css'



const ProductsSection = () => {
  return (
    <section id="products-section" className={styles.productosSection}>
      <div className={styles.sectionHeader}>
        <h2 className={styles.sectionTitle}>Nuestros Productos</h2>
        <p className={styles.sectionDescriptionUnique}>Descubre nuestra amplia gama de productos y servicios para hacer
          de tu
          evento algo extraordinario</p>
      </div>

      <div className={styles.productosGrid}>
        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Juegos</span>
          <img src={CastilloInflable} alt="Castillos Inflables"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Castillos Inflables</h3>
            <p>Castillos inflables seguros y divertidos para todas las edades</p>
          </div>
        </div>

        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Confitería</span>
          <img src={MaquinaCotton} alt="Máquinas de Algodón"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Máquinas de Algodón</h3>
            <p>Máquinas profesionales de algodón de azúcar y palomitas</p>
          </div>
        </div>

        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Alimentación</span>
          <img src={Catering} alt="Servicio de Catering"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Servicio de Catering</h3>
            <p>Buffets completos y menús personalizados para tu evento</p>
          </div>
        </div>

        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Audio/Video</span>
          <img src={EquipoSonido} alt="Equipo de Sonido"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Equipo de Sonido</h3>
            <p>Sistemas de sonido profesional y equipo de DJ</p>
          </div>
        </div>

        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Ambientación</span>
          <img src={Carpas} alt="Carpas y Decoración"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Carpas y Decoración</h3>
            <p>Carpas elegantes y decoración temática personalizada</p>
          </div>
        </div>

        <div className={styles.productoCard}>
          <span className={styles.productoBadge}>Muebles</span>
          <img src={Mobiliario} alt="Mobiliario"
            className={styles.productoImagen} />
          <div className={styles.productoInfo}>
            <h3>Mobiliario</h3>
            <p>Mesas, sillas y mobiliario elegante para cualquier ocasión</p>
          </div>
        </div>
      </div>


    </section>
  )
}

export default ProductsSection
