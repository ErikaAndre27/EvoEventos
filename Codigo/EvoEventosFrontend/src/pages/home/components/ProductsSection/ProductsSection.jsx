import CastilloInflable from '@assets/Images/CastilloInflable.jpg'
import MaquinaCotton from '@assets/Images/MaquinaCotton.jpg'
import Catering from '@assets/Images/Catering.jpg'
import EquipoSonido from '@assets/Images/EquipoSonido.jpg'
import Carpas from '@assets/Images/Carpas.jpg'
import Mobiliario from '@assets/Images/Mobiliario.jpg'

import styles from './ProductsSection.module.css'
import ProductCard from './components/ProductCard'

const PRODUCTS = [
  {
    title: 'Castillos Inflables',
    description: 'Castillos inflables seguros y divertidos para todas las edades',
    image: CastilloInflable,
    category: 'Juegos'
  },
  {
    title: 'Máquinas de Algodón',
    description: 'Máquinas profesionales de algodón de azúcar y palomitas',
    image: MaquinaCotton,
    category: 'Confitería'
  },
  {
    title: 'Servicio de Catering',
    description: 'Buffets completos y menús personalizados para tu evento',
    image: Catering,
    category: 'Alimentación'
  },
  {
    title: 'Equipo de Sonido',
    description: 'Sistemas de sonido profesional y equipo de DJ',
    image: EquipoSonido,
    category: 'Audio/Video'
  },
  {
    title: 'Carpas y Decoración',
    description: 'Carpas elegantes y decoración temática personalizada',
    image: Carpas,
    category: 'Ambientación'
  },
  {
    title: 'Mobiliario',
    description: 'Mesas, sillas y mobiliario elegante para cualquier ocasión',
    image: Mobiliario,
    category: 'Muebles'
  }
]

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
        {PRODUCTS.map((product, index) => (
          <ProductCard
            key={index}
            title={product.title}
            description={product.description}
            category={product.category}
            image={product.image}
          />
        ))}
      </div>


    </section>
  )
}

export default ProductsSection
