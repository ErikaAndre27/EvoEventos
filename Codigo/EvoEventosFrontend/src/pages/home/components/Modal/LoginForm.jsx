import { loginRequest } from '../../../../api/auth'
import { useAuthStore } from '../../../../store/auth'
import React from 'react'
import styles from './Modal.module.css'
import { useNavigate } from 'react-router'

const LoginForm = () => {

  const setToken = useAuthStore(state => state.setToken)
  const setProfile = useAuthStore(state => state.setProfile)
  const navigate = useNavigate()

  const handleSubmit = async (e) => {
    e.preventDefault();
    const identifier = e.currentTarget.elements.email.value
    const contrasena = e.currentTarget.elements.contrasena.value
    console.log(identifier)
    console.log(contrasena)

    try {

      const answerLogin = await loginRequest(identifier, contrasena)
      console.log(answerLogin)
      const { token, names, surnames, email, role, lastLogin, expires } = answerLogin.data

      setToken(token)
      setProfile({ names, surnames, email, role, lastLogin, expires })
      navigate('/dashboard')

    } catch (error) {
      console.log("Error:", error.response?.data);
      console.log("Status:", error.response?.status);
    }

  }


  return (
    <>
      {/* <!-- Formulario del modal --> */}
      <form className={styles.modalForm} onSubmit={handleSubmit}>

        {/* <!-- Tipo de Usuario -->
        <div className={styles.campo}>
          <label htmlFor="tipo-usuario">Tipo de Usuario</label>
          <select id="tipo-usuario" name="tipo-usuario" defaultValue="">
            <option value="" disabled>Selecciona.</option>
            <option value="admin">Administrador</option>
            <option value="organizador">Asesor</option>
          </select>
        </div> */}

        {/* <!-- Email --> */}
        <div className={styles.campo}>
          <label htmlFor="email">Email / Identificación</label>
          <input type="text" id="email" name="email" placeholder="Ingresa tu email o número de documento" autoComplete="username" />
        </div>

        {/* <!-- Contraseña --> */}
        <div className={styles.campo}>
          <label htmlFor="contrasena">Contraseña</label>
          <div className={styles.campoPassword}>
            <input type="password" id="contrasena" name="contrasena" placeholder="Ingresa tu Contraseña"
              autoComplete="current-password" />
            <button type="button" className={styles.btnVerPassword} aria-label="Mostrar u ocultar contraseña" id="btn-ojo">
              <svg id="ojo-abierto" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="#888" strokeWidth="2">
                <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" />
                <circle cx="12" cy="12" r="3" />
              </svg>
              <svg id="ojo-cerrado" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="#888" strokeWidth="2">
                <path d="M17.94 17.94A10.07 10.07 0 0112 20c-7 0-11-8-11-8a18.45 18.45 0 015.06-5.94" />
                <path d="M9.9 4.24A9.12 9.12 0 0112 4c7 0 11 8 11 8a18.5 18.5 0 01-2.16 3.19" />
                <line x1="1" y1="1" x2="23" y2="23" />
              </svg>
            </button>
          </div>
        </div>

        <button type="submit" className={styles.btnIngresar}>Iniciar Sesión</button>

        <a href="#" className={styles.linkOlvido}>¿Olvidaste tu Contraseña?</a>

      </form>
    </>
  )
}

export default LoginForm
