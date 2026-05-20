
import LogoFondoBl from '@assets/Icons/LogoFondoBl.svg'
import LocationMain from '@assets/Icons/LocationMain.svg'
import PhoneMain from '@assets/Icons/PhoneMain.svg'
import MessageMain from '@assets/Icons/MessageMain.svg'
import styles from './CustomFooter.module.css'

const CustomFooter = () => {
  return (
    <footer className={styles.mainFooter}>
      <div className={styles.footerContent}>
        <div className={styles.footerSection}>
          <img src={LogoFondoBl} alt="EvoEventos" className={styles.footerLogo} />
          <p>Somos expertos en crear experiencias inolvidables. Tu evento, nuestra pasión.</p>
        </div>

        <div id="contacto" className={styles.footerSection}>
          <h3>Contacto</h3>
          <ul className={styles.contactInfo}>
            <li>
              <img src={LocationMain} alt="Ubicación" className={styles.infoLogo} />
              Bogotá, Colombia
            </li>
            <li>
              <img src={PhoneMain} alt="Teléfono" className={styles.infoLogo} />3508181891
            </li>
            <li>
              <img src={MessageMain} alt="Email" className={styles.infoLogo} />
              contacto@evoeventos.com
            </li>
          </ul>
        </div>

        <div className={styles.footerSection}>
          <h3>Enlaces Rápidos</h3>
          <ul className={styles.footerLinks}>
            <li><a href="#">Inicio</a></li>
            <li><a href="#servicios-destacados">Servicios</a></li>
            <li><a href="#sobre-evoeventos">Nosotros</a></li>
            <li><a href="#contacto">Contacto</a></li>
          </ul>
        </div>
      </div>

      <div className={styles.footerBottom}>
        <p>© 2025 EvoEventos. Todos los derechos reservados.</p>
      </div>
    </footer>
  )
}

export default CustomFooter
