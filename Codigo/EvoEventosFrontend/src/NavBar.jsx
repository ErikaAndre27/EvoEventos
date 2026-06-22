import './NavBar.css'
import Logo from './assets/Icons/Logo.svg'
import ExitIcon from './assets/Icons/exit.svg'
import { useState } from 'react'
import { NavLink } from 'react-router'
import { useAuthStore } from './store/auth'
import { useNavigate } from 'react-router'

const roleLabels = {
    Admin: 'Administración',
    Asesor: 'Asesor'
}

const NavBar = () => {
    const [openMenu, setOpenMenu] = useState(false);

    const logout = useAuthStore(state => state.logout)
    const navigate = useNavigate()

    const role = useAuthStore((state) => state.profile?.role)

    return (
        <>
            <header className="main-header">
                <button className="open-menu" onClick={() => setOpenMenu(true)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" stroke="currentColor" strokeWidth="2"
                        strokeLinecap="round" strokeLinejoin="round" className="icon icon-tabler icons-tabler-outline icon-tabler-menu-2">
                        <path stroke="none" d="M0 0h24v24H0z" />
                        <path d="M4 6h16M4 12h16M4 18h16" />
                    </svg>
                </button>
                <div className="header-left">
                    <div className="logo">
                        <img src={Logo} alt="EvoEventos" />
                    </div>
                    <div className="subtitle">Panel de {roleLabels[role] ?? role}</div>
                </div>

                <button className="exit-btn" onClick={() => {
                    logout()
                    navigate('/home')

                }}>
                    <span className="icon"><img src={ExitIcon} alt="Salir" /></span> <p>Salir</p>
                </button>
            </header>
            <nav id="header_principal" className={openMenu ? "menu-open" : ""}>
                <button className="close-menu" onClick={() => setOpenMenu(false)}>
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" stroke="currentColor" strokeWidth="2"
                        strokeLinecap="round" strokeLinejoin="round" className="icon icon-tabler icons-tabler-outline icon-tabler-x">
                        <path stroke="none" d="M0 0h24v24H0z" />
                        <path d="M18 6L6 18M6 6l12 12" />
                    </svg>
                </button>

                <section className="nav-links">
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to='/dashboard'>Dashboard</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/solicitudes">Solicitudes</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/catalogo">Catálogo</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/eventos">Eventos</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/">Clientes</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/cotizaciones">Cotizaciones</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/">Pagos</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/">Próximos</NavLink>
                    <NavLink className={({ isActive }) => isActive ? "active" : ""} to="/">Mi perfil</NavLink>
                </section>
            </nav>
        </>
    )
}

export default NavBar
