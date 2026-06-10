import MessageCash from '@assets/Icons/MessageCash.svg'
import styles from './ContactForm.module.css'


const ContactForm = () => {
  return (
    <div className={styles.cotizacionFormContainer}>
      <form className={styles.cotizacionForm} action="/" method="post">
        <div className={styles.formHeader}>

          <div className={styles.formTitle}>
            <div className={styles.iconWrapper}>
              <img src={MessageCash} alt="Mensaje" />
            </div>

            <h3 className={styles.formHeading}>
              Solicita Tu Cotización
            </h3>
          </div>

          <p className={styles.formSubtitle}>
            Información básica para personalizar tu propuesta
          </p>
        </div>

        <div className={styles.formBody}>

          <div className={`${styles.formGroup} ${styles.full}`}>
            <label className={styles.formLabel}>Nombre completo</label>
            <input type="text" placeholder="Tu nombre completo" required />
          </div>

          <div className={styles.formGroup}>
            <label className={styles.formLabel}>Correo electrónico</label>
            <input type="email" placeholder="tu@email.com" required />
          </div>

          <div className={styles.formGroup}>
            <label className={styles.formLabel}>Número de contacto</label>
            <input type="tel" placeholder="3011234567" required />
          </div>

          <div className={styles.formGroup}>
            <label className={styles.formLabel}>Fecha del evento</label>
            <input type="date" min={new Date().toISOString().split('T')[0]} required />
          </div>

          <div className={styles.formGroup}>
            <label className={styles.formLabel}>Asistentes</label>
            <input min="1" type="number" placeholder="# personas" required />
          </div>

          <div className={`${styles.formGroup} ${styles.full}`}>
            <label className={styles.formLabel}>Tipo de Evento</label>
            <select id="tipoEvento" name="tipoEvento" required defaultValue="">
              <option value="" disabled>Seleccione una opción</option>
              <option value="familiar">Familiar</option>
              <option value="empresarial">Empresarial</option>
              <option value="boda">Boda</option>
              <option value="grados">Grados</option>
              <option value="otro">Otro</option>
            </select>
          </div>

          <div className={`${styles.formGroup} ${styles.full}`}>
            <label className={styles.formLabel}>Servicios requeridos</label>

            <div className={styles.checkboxList}>
              <label className={styles.checkboxCard}>
                <input type="checkbox" name="servicios" value="juegos" />
                <span>Juegos inflables</span>
              </label>

              <label className={styles.checkboxCard}>
                <input type="checkbox" name="servicios" value="maquinas" />
                <span>Máquina de alimentos</span>
              </label>

              <label className={styles.checkboxCard}>
                <input type="checkbox" name="servicios" value="atracciones" />
                <span>Atracciones mecánicas</span>
              </label>

              <label className={styles.checkboxCard}>
                <input type="checkbox" name="servicios" value="inflables" />
                <span>Inflables</span>
              </label>

              <label className={styles.checkboxCard}>
                <input type="checkbox" name="servicios" value="otros" />
                <span>Otros servicios</span>
              </label>

              <button type="submit" className={styles.btnSubmit}>Obtener Cotización Gratuita</button>
            </div>

          </div>

        </div>

      </form>
    </div>
  )
}

export default ContactForm
