
export const Dashboard = ({ logout }) => {
    return (
        <div>
            <h1>Soy el dashboard en Admin</h1>
            <button onClick={logout}>Cerrar sesión</button>
        </div>
    )
}

