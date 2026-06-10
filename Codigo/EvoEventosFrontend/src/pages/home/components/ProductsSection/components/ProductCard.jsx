import styles from '../ProductsSection.module.css'

const ProductCard = ({title = '', description = '', category = '', image = ''}) => {
  return (
    <div className={styles.productoCard}>
      <span className={styles.productoBadge}>{category}</span>
      <img src={image} alt={`${title}_image`}
        className={styles.productoImagen} />
      <div className={styles.productoInfo}>
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  )
}

export default ProductCard