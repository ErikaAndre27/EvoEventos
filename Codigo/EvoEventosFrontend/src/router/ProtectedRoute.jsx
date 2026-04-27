import { Navigate, Outlet } from "react-router"
import NavBar from "../NavBar"

export const ProtectedRoute = ({ isAllowed, children }) => {

  if (!isAllowed) return <Navigate to='/home' />
  return (
    <>
      <NavBar />
      {
        children ? { children } : <Outlet />
      }
    </>
  )

}

