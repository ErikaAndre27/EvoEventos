
import LogoFondoBl from '@assets/Icons/LogoFondoBl.svg'
import LocationMain from '@assets/Icons/LocationMain.svg'
import PhoneMain from '@assets/Icons/PhoneMain.svg'
import MessageMain from '@assets/Icons/MessageMain.svg'
import './CustomFooter.css'

const CustomFooter = () => {
  return (
    <footer class="main-footer">
      <div class="footer-content">
        <div class="footer-section">
          <img src={LogoFondoBl} alt="EvoEventos" class="footer-logo" />
          <p>Somos expertos en crear experiencias inolvidables. Tu evento, nuestra pasión.</p>
        </div>

        <div id="contacto" class="footer-section">
          <h3>Contacto</h3>
          <ul class="contact-info">
            <li>
              <img src={LocationMain} alt="Ubicación" class="info-logo" />
              Bogotá, Colombia
            </li>
            <li>
              <img src={PhoneMain} alt="Teléfono" class="info-logo" />3508181891
            </li>
            <li>
              <img src={MessageMain} alt="Email" class="info-logo" />
              contacto@evoeventos.com
            </li>
          </ul>
        </div>

        <div class="footer-section">
          <h3>Enlaces Rápidos</h3>
          <ul class="footer-links">
            <li><a href="#">Inicio</a></li>
            <li><a href="#servicios-destacados">Servicios</a></li>
            <li><a href="#sobre-evoeventos">Nosotros</a></li>
            <li><a href="#contacto">Contacto</a></li>
          </ul>
        </div>
      </div>

      <div class="footer-bottom">
        <p>© 2025 EvoEventos. Todos los derechos reservados.</p>
      </div>
    </footer>
  )
}

export default CustomFooter
