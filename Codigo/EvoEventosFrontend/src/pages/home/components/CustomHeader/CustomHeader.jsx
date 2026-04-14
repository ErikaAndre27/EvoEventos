import Logo from '@assets/Icons/Logo.svg'
import login from '@assets/Icons/login.svg'
import styles from './CustomHeader.module.css'

const CustomHeader = ({ openModal = () => { } }) => {

    return (
        <header className={styles.mainHeader}>
            <div>
                <div className={styles.headerLeft}>
                    <div className={styles.logo}>
                        <a>
                            <img className={styles.logoImg} src={Logo} alt="EvoEventos" />
                        </a>
                    </div>

                    <nav className={styles.mainNav}>
                        <a href="index.html" className={styles.active}>Inicio</a>
                        <a href="#servicios">Servicios</a>
                        <a href="#sobre-nosotros">Sobre nosotros</a>
                        <a href="#contacto">Contacto</a>
                    </nav>
                </div>


                <div className={styles.headerRight}>
                    <button className={styles.btnEmpleados} onClick={openModal}>
                        <img src={login} className={styles.btnIcon} />
                        <span>Ingreso empleados</span>
                    </button>
                </div>


                <a href="https://wa.me/+573134602232" className={styles.btnCotizarHeader} target="_blank">Cotiza ahora</a>
            </div>
        </header >
    )
}

export default CustomHeader
