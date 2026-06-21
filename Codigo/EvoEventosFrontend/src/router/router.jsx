import { HomePage } from "../pages/home/HomePage"
import { Dashboard } from "../pages/dashboard/Dashboard"
import { BrowserRouter, Routes, Route, Navigate } from 'react-router'
import { ProtectedRoute } from "./ProtectedRoute"
import { useAuthStore } from "../store/auth"
import { Cotizaciones } from "../pages/cotizaciones/Cotizaciones"

export const EvoEventosRouter = () => {

    const isAuth = useAuthStore(state => state.isAuth)

    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path='/home' element={<HomePage />} />

                    <Route element={<ProtectedRoute isAllowed={true} />}> //isAuth
                        <Route index element={<Navigate to="/dashboard" replace />} />
                        <Route path='/dashboard' element={<Dashboard />} />
                        <Route path='/solicitudes' element={<p>solicitudes</p>} />
                        <Route path='/clientes' element={<p>clientes</p>} />
                        <Route path='/catalogo' element={<p>catalogo</p>} />
                        <Route path='/cotizaciones' element={<Cotizaciones />} />
                        <Route path='/asesores' element={<p>asesores</p>} />
                        <Route path='/eventos' element={<p>eventos</p>} />
                        <Route path='/inventario' element={<p>inventario</p>} />
                        <Route path='/reportes' element={<p>reportes</p>} />
                        <Route path='/perfil' element={<p>mi perfil</p>} />
                    </Route>


                    {
                        /* Ejemplo de uso:
    
                        <Route path="/la ruta que use" element={el componente que use} /> */
                    }
                </Routes>
            </BrowserRouter>
        </>
    )
}
