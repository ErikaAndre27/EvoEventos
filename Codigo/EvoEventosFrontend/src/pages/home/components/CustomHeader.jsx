import Logo from '@assets/Icons/Logo.svg'
import login from '@assets/Icons/login.svg'
import './CustomHeader.css'

const CustomHeader = ({ openModal = () => { } }) => {

    return (
        <header class="main-header">
            <div>
                <div className="header-left">
                    <div className="logo">
                        <a >
                            <img className='logo-img' src={Logo} Alt={'EvoEventos'} />
                        </a>
                    </div>

                    <nav className="main-nav">
                        <a href="index.html" className="active">Inicio</a>
                        <a href="#servicios">Servicios</a>
                        <a href="#sobre-nosotros">Sobre nosotros</a>
                        <a href="#contacto">Contacto</a>
                    </nav>
                </div>


                <div className="header-right">
                    <button className="btn-empleados" onClick={openModal}>
                        <img src={login} className="btn-icon" />
                        <span>Ingreso empleados</span>
                    </button>
                </div>


                <a href="https://wa.me/+573134602232" className="btn-cotizar-header" target="_blank">Cotiza ahora</a>
            </div>
        </header >
    )
}

export default CustomHeader
