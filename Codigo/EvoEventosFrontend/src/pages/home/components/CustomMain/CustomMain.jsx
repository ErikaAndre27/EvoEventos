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

import ContactForm from '../ContactForm/ContactForm'
import ProductsSection from '../ProductsSection/ProductsSection'

import styles from './CustomMain.module.css'


const CustomMain = () => {
    return (
        <main>
            {/* <!-- COTIZACIÓN SECTION --> */}
            <section id="quotation-section" className={styles.cotizacionSection}>
                <div className={styles.cotizacionInfo}>
                    <h2 className={styles.sectionTitle}>Cotiza tu evento</h2>
                    <p className={styles.sectionDescription}>Completa el formulario y recibe una cotización personalizada para tu
                        evento. Nuestro equipo de expertos te ayudará a crear la experiencia perfecta.</p>

                    <div className={styles.beneficiosGrid}>
                        <div className={styles.beneficioItem}>
                            <img src={check2} alt="Rápido" className={styles.beneficioIcon} />
                            <div className={styles.beneficioTexto}>
                                <h3>Cotización inmediata</h3>
                                <p>Recibe tu presupuesto en menos de 24 horas</p>
                            </div>
                        </div>
                        <div className={styles.beneficioItem}>
                            <img src={clock2} alt="Ágil" className={styles.beneficioIcon} />
                            <div className={styles.beneficioTexto}>
                                <h3>Servicio express</h3>
                                <p>Montaje y desmontaje incluido en el precio</p>
                            </div>
                        </div>
                        <div className={styles.beneficioItem}>
                            <img src={users3} alt="Personalizado"
                                className={styles.beneficioIcon} />
                            <div className={styles.beneficioTexto}>
                                <h3>Atención personalizada</h3>
                                <p>Un asesor dedicado para tu evento</p>
                            </div>
                        </div>
                        <div className={styles.beneficioItem}>
                            <img src={starrs4} alt="Calidad" className={styles.beneficioIcon} />
                            <div className={styles.beneficioTexto}>
                                <h3>Garantía de calidad</h3>
                                <p>Equipos revisados y personal capacitado</p>
                            </div>
                        </div>
                    </div>

                    {/* <!-- Indicadores numéricos  --> */}
                    <div className={styles.indicadores}>
                        <div className={styles.indicadorCard}>
                            <p className={styles.indicadorValor}>500+</p>
                            <p className={styles.indicadorDesc}>Eventos realizados</p>
                            <img src={CalendarStar} alt="Eventos realizados" />
                        </div>
                        <div className={styles.indicadorCard}>
                            <p className={styles.indicadorValor}>24h</p>
                            <p className={styles.indicadorDesc}>Tiempo de respuesta</p>
                            <img src={Clock24h} alt="Tiempo de respuesta" />
                        </div>
                        <div className={styles.indicadorCard}>
                            <p className={styles.indicadorValor}>95%</p>
                            <p className={styles.indicadorDesc}>Clientes satisfechos</p>
                            <img src={PersonStar} alt="Eventos realizados" />
                        </div>
                    </div>
                </div>

                {/* FORMULARIO DE CONTACTO */}
                <ContactForm />

            </section>

            {/* <!-- Servicios Destacados --> */}
            <section id="servicios-destacados" className={styles.serviciosDestacados}>
                <div className={styles.serviciosContainer}>
                    <div className={styles.sectionHeader}>
                        <h2 className={styles.sectionTitleUnique}>Servicios Destacados</h2>
                        <p className={styles.sectionDescriptionUnique}>Ofrecemos una amplia gama de servicios para hacer de tu
                            evento una
                            experiencia inolvidable</p>
                    </div>

                    <div className={styles.serviciosGrid}>
                        <div className={styles.servicioCard}>
                            <div className={styles.servicioIcon}>
                                <img src={Circus3D} alt="Juegos Inflables" />
                            </div>
                            <h3>Juegos Inflables</h3>
                            <p>Castillos, toboganes y estructuras inflables para la diversión de todos</p>
                        </div>

                        <div className={styles.servicioCard}>
                            <div className={styles.servicioIcon}>
                                <img src={Popcorn3D}
                                    alt="Máquinas de Algodón de Azúcar" />
                            </div>
                            <h3>Máquinas de comestibles</h3>
                            <p>Máquinas de palomitas, algodón de azúcar y dulces para endulzar tu evento</p>
                        </div>

                        <div className={styles.servicioCard}>
                            <div className={styles.servicioIcon}>
                                <img src={Hamburger3D} alt="Catering" />
                            </div>
                            <h3>Catering</h3>
                            <p>Servicio completo de comidas y bebidas adaptado a tu presupuesto</p>
                        </div>

                        <div className={styles.servicioCard}>
                            <div className={styles.servicioIcon}>
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
