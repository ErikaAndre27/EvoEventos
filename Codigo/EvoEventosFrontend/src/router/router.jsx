import { createBrowserRouter } from "react-router"
import { Home } from "../pages/home/Home"
import Layout from "../layout/Layout"
import { Dashboard } from "../pages/admin/dashboard"

export const router = ({ isLogged, login, logout }) => createBrowserRouter([
    {
        path: '/',
        element: <Layout isLogged={isLogged} />,
        errorElement: <h1>404 Not Found</h1>,
        children: [
            {
                path: '',
                element: <Dashboard logout={logout} />
            }
        ]
    },
    {
        path: '/home',
        element: <Home login={login} isLogged={isLogged} />
    }
])