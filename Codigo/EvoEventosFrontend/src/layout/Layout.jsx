import { Navigate, Outlet } from "react-router"

const Layout = ({ isLogged }) => {

    if (!isLogged) {
        return <Navigate to={'/home'} />
    }

    return (
        <div>
            <h1>Layout</h1>
            <Outlet />
        </div>
    )
}

export default Layout
