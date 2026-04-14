import MessageCash from '@assets/Icons/MessageCash.svg'
import './ContactForm.css'


const ContactForm = () => {
  return (
    <div className="cotizacion-form-container">
      <form className="cotizacion-form" action="/" method="post">
        <div className="form-header">

          <div className="form-title">
            <div className="icon-wrapper">
              <img src={MessageCash} className="quotation-icon" />
            </div>

            <h3 className="form-heading">
              Solicita Tu Cotización
            </h3>
          </div>

          <p className="form-subtitle">
            Información básica para personalizar tu propuesta
          </p>
        </div>

        <div className="form-body">

          <div className="form-group full">
            <label className="form-label">Nombre completo</label>
            <input type="text" placeholder="Tu nombre completo" />
          </div>

          <div className="form-group">
            <label className="form-label">Correo electrónico</label>
            <input type="email" placeholder="tu@email.com" />
          </div>

          <div className="form-group">
            <label className="form-label">Número de contacto</label>
            <input type="tel" placeholder="3011234567" />
          </div>

          <div className="form-group">
            <label className="form-label">Fecha del evento</label>
            <input type="date" />
          </div>

          <div className="form-group">
            <label className="form-label">Asistentes</label>
            <input type="number" placeholder="# personas" />
          </div>

          <div className="form-group full">
            <label className="form-label">Tipo de Evento</label>
            <select id="tipoEvento" name="tipoEvento" required>
              <option value="" disabled selected>Seleccione una opción</option>
              <option value="familiar">Familiar</option>
              <option value="empresarial">Empresarial</option>
              <option value="boda">Boda</option>
              <option value="grados">Grados</option>
              <option value="otro">Otro</option>
            </select>
          </div>

          <div className="form-group full">
            <label className="form-label">Servicios requeridos</label>


            <div className="checkbox-list">
              <label className="checkbox-card">
                <input type="checkbox" name="servicios" value="juegos" />
                <span>Juegos inflables</span>
              </label>

              <label className="checkbox-card">
                <input type="checkbox" name="servicios" value="maquinas" />
                <span>Máquina de alimentos</span>
              </label>

              <label className="checkbox-card">
                <input type="checkbox" name="servicios" value="atracciones" />
                <span>Atracciones mecánicas</span>
              </label>

              <label className="checkbox-card">
                <input type="checkbox" name="servicios" value="inflables" />
                <span>Inflables</span>
              </label>

              <label className="checkbox-card">
                <input type="checkbox" name="servicios" value="otros" />
                <span>Otros servicios</span>
              </label>

              <button type="submit" className="btn-submit">Obtener Cotización Gratuita</button>
            </div>

          </div>

        </div>


      </form>
    </div>
  )
}

export default ContactForm
