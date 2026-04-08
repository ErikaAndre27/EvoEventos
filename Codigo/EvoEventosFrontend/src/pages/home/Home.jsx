import { Navigate } from "react-router"


export const Home = ({ login, isLogged }) => {
    if (isLogged)
        return <Navigate to={'/'} />

    return (

        <>
            <h1>Home</h1>
            <button onClick={login}>Inciar sesión</button>
        </>

    )
}