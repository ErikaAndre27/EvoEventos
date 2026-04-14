// import './App.css'
// import NavBar from './NavBar'
import { Home } from './pages/home/Home'
import { Dashboard } from './pages/admin/dashboard'
import { Navigate, RouterProvider } from 'react-router'
// import { router } from './router/router'
// import { useState } from 'react'
import HomePage from './pages/home/HomePage'
function App() {
  // const [isLogged, setIsLogged] = useState(false)

  // const login = () => setIsLogged(true)

  // const logout = () => setIsLogged(false)

  return (
    <>
      <link rel="icon" type="image/png" sizes="32x32" href="/Codigo/Frontend/Src/Assets/Icons/favicon-32x32.png"></link>
      <HomePage />


      {/* <RouterProvider router={router({ isLogged, login, logout })} /> */}
    </>
  )
}

export default App
