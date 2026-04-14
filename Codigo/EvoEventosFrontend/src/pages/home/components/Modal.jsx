import './Modal.css'

const Modal = ({ closeModal = () => { }, isOpen = false }) => {
  return (
    <>
      {/* <div className="overlay activo" id="overlay" onClick={closeModal}></div>
      <div className="modal activo" id="modal" role="dialog" aria-modal="true" aria-labelledby="titulo-modal"> */}


      <div className={`overlay ${isOpen ? "activo" : ""}`} id="overlay" onClick={closeModal}></div>
      <div className={`modal ${isOpen ? "activo" : ""}`} id="modal" role="dialog" aria-modal="true" aria-labelledby="titulo-modal">

        <button className="btn-cerrar" onClick={closeModal} aria-label="Cerrar modal">&#x2715;</button>

        <div className="modal-encabezado">

          <h2 className="titulo" id="titulo-modal">Acceso Personal</h2>
          <p className="subtitulo" id="subtitulo-modal">EvoEventos</p>
        </div>

        {/* <!-- Formulario del modal --> */}
        <form className="modal-form" onsubmit="return false;">

          {/* <!-- Tipo de Usuario --> */}
          <div className="campo">
            <label for="tipo-usuario">Tipo de Usuario</label>
            <select id="tipo-usuario" name="tipo-usuario">
              <option value="" disabled selected>Selecciona…</option>
              <option value="admin">Administrador</option>
              <option value="organizador">Asesor</option>
            </select>
          </div>

          {/* <!-- Email --> */}
          <div className="campo">
            <label for="email">Email / Identificación</label>
            <input type="text" id="email" name="email" placeholder="Ingresa tu nombre Usuario" autocomplete="username" />
          </div>

          {/* <!-- Contraseña --> */}
          <div className="campo">
            <label for="contrasena">Contraseña</label>
            <div className="campo-password">
              <input type="password" id="contrasena" name="contrasena" placeholder="Ingresa tu Contraseña"
                autocomplete="current-password" />
              {/* <!-- Botón para mostrar/ocultar contraseña --> */}
              <button type="button" className="btn-ver-password" onclick="togglePassword()"
                aria-label="Mostrar u ocultar contraseña" id="btn-ojo">
                {/* <!-- Ícono de ojo abierto --> */}
                <svg id="ojo-abierto" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="#888" stroke-width="2">
                  <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z" />
                  <circle cx="12" cy="12" r="3" />
                </svg>
                {/* <!-- Ícono  ojocerrado, oculto por defecto --> */}
                <svg id="ojo-cerrado" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="#888" stroke-width="2"
                >
                  <path d="M17.94 17.94A10.07 10.07 0 0112 20c-7 0-11-8-11-8a18.45 18.45 0 015.06-5.94" />
                  <path d="M9.9 4.24A9.12 9.12 0 0112 4c7 0 11 8 11 8a18.5 18.5 0 01-2.16 3.19" />
                  <line x1="1" y1="1" x2="23" y2="23" />
                </svg>
              </button>
            </div>
          </div>

          <button type="submit" className="btn-ingresar">Iniciar Sesión</button>

          <a href="#" className="link-olvido">¿Olvidaste tu Contraseña?</a>

        </form>

      </div>
    </>
  )
}

export default Modal
