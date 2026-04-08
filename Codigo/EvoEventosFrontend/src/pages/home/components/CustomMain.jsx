import check2 from '@assets/Icons/check2.svg'
import clock2 from '@assets/Icons/clock2.svg'
import users3 from '@assets/Icons/users3.svg'
import starrs4 from '@assets/Icons/starrs4.svg'
import CalendarStar from '@assets/Icons/CalendarStar.svg'
import Circus3D from '@assets/Icons/circus3d.svg'
import Popcorn3D from '@assets/Icons/popcorn_3d.svg'
import Hamburger3D from '@assets/Icons/hamburger_3d.svg'
import DeliveryTruck from '@assets/Icons/delivery_truck.svg'
import Clock24h from '@assets/Icons/Clock24h.svg'
import PersonStar from '@assets/Icons/PersonStar.svg'

import ContactForm from './ContactForm'
import ProductsSection from './ProductsSection'



const CustomMain = () => {
    return (
        <main>
            {/* <!-- COTIZACIÓN SECTION --> */}
            <section id="Cotizacion" className="cotizacion-section">
                <div className="cotizacion-info">
                    <h2 className="section-title">Cotiza tu evento</h2>
                    <p className="section-description">Completa el formulario y recibe una cotización personalizada para tu
                        evento. Nuestro equipo de expertos te ayudará a crear la experiencia perfecta.</p>

                    <div className="beneficios-grid">
                        <div className="beneficio-item">
                            <img src={check2} alt="Rápido" className="beneficio-icon" />
                            <div className="beneficio-texto">
                                <h3>Cotización inmediata</h3>
                                <p>Recibe tu presupuesto en menos de 24 horas</p>
                            </div>
                        </div>
                        <div className="beneficio-item">
                            <img src={clock2} alt="Ágil" className="beneficio-icon" />
                            <div className="beneficio-texto">
                                <h3>Servicio express</h3>
                                <p>Montaje y desmontaje incluido en el precio</p>
                            </div>
                        </div>
                        <div className="beneficio-item">
                            <img src={users3} alt="Personalizado"
                                className="beneficio-icon" />
                            <div className="beneficio-texto">
                                <h3>Atención personalizada</h3>
                                <p>Un asesor dedicado para tu evento</p>
                            </div>
                        </div>
                        <div className="beneficio-item">
                            <img src={starrs4} alt="Calidad" className="beneficio-icon" />
                            <div className="beneficio-texto">
                                <h3>Garantía de calidad</h3>
                                <p>Equipos revisados y personal capacitado</p>
                            </div>
                        </div>
                    </div>

                    {/* <!-- Indicadores numéricos  --> */}
                    <div className="indicadores">
                        <div className="indicador-card">
                            <p className="indicador-valor">500+</p>
                            <p className="indicador-desc">Eventos realizados</p>
                            <img src={CalendarStar} alt="Eventos realizados"
                                className="indicador-icon" />
                        </div>
                        <div className="indicador-card">
                            <p className="indicador-valor">24h</p>
                            <p className="indicador-desc">Tiempo de respuesta</p>
                            <img src={Clock24h} alt="Tiempo de respuesta"
                                className="indicador-icon" />
                        </div>
                        <div className="indicador-card">
                            <p className="indicador-valor">95%</p>
                            <p className="indicador-desc">Clientes satisfechos</p>
                            <img src={PersonStar} alt="Eventos realizados"
                                className="indicador-icon" />
                        </div>
                    </div>
                </div>

                {/* FORMULARIO DE CONTACTO */}
                <ContactForm />

            </section>

            {/* <!-- Servicios Destacados --> */}
            <section id="servicios-destacados" className="servicios-destacados">
                <div className="servicios-container">
                    <div className="section-header">
                        <h2 className="section-title--unique">Servicios Destacados</h2>
                        <p className="section-description--unique">Ofrecemos una amplia gama de servicios para hacer de tu
                            evento una
                            experiencia inolvidable</p>
                    </div>

                    <div className="servicios-grid">
                        <div className="servicio-card">
                            <div className="servicio-icon">
                                <img src={Circus3D} alt="Juegos Inflables" />
                            </div>
                            <h3>Juegos Inflables</h3>
                            <p>Castillos, toboganes y estructuras inflables para la diversión de todos</p>
                        </div>

                        <div className="servicio-card">
                            <div className="servicio-icon">
                                <img src={Popcorn3D}
                                    alt="Máquinas de Algodón de Azúcar" />
                            </div>
                            <h3>Máquinas de comestibles</h3>
                            <p>Máquinas de palomitas, algodón de azúcar y dulces para endulzar tu evento</p>
                        </div>

                        <div className="servicio-card">
                            <div className="servicio-icon">
                                <img src={Hamburger3D} alt="Catering" />
                            </div>
                            <h3>Catering</h3>
                            <p>Servicio completo de comidas y bebidas adaptado a tu presupuesto</p>
                        </div>

                        <div className="servicio-card">
                            <div className="servicio-icon">
                                <img src={DeliveryTruck} alt="Transporte" />
                            </div>
                            <h3>Transporte</h3>
                            <p>Logística completa para el montaje y desmontaje de tu evento</p>
                        </div>
                    </div>
                </div>
            </section>

            {/* <!-- Nuestros Productos  --> */}

            <ProductsSection />
        </main>
    )
}

export default CustomMain
