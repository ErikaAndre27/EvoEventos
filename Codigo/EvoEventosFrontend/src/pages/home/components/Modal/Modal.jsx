import LoginForm from './LoginForm'
import styles from './Modal.module.css'

const Modal = ({ closeModal = () => { }, isOpen = false }) => {
  return (
    <>
      <div className={`${styles.overlay} ${isOpen ? styles.activo : ''}`} id="overlay" onClick={closeModal}></div>
      <div className={`${styles.modal} ${isOpen ? styles.activo : ''}`} id="modal" role="dialog" aria-modal="true" aria-labelledby="titulo-modal">

        <button className={styles.btnCerrar} onClick={closeModal} aria-label="Cerrar modal">&#x2715;</button>

        <div className={styles.modalEncabezado}>

          <h2 className={styles.titulo} id="titulo-modal">Acceso Personal</h2>
          <p className={styles.subtitulo} id="subtitulo-modal">EvoEventos</p>
        </div>

        <LoginForm />

      </div>
    </>
  )
}

export default Modal
