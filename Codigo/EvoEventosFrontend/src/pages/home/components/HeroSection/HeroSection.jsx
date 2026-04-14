import whatsapp from '@assets/Icons/whatsapp.svg'
import styles from './HeroSection.module.css'

const HeroSection = () => {
    return (
        <section className={styles.heroSection}>
            <div className={styles.heroContent}>
                <h1 className={styles.heroTitle}>Todo Lo que Tu Evento Necesita, En Un Solo Lugar</h1>
                <p className={styles.heroSubtitle}>Cotiza en minutos equipos, comidas y juegos inflables para tu evento</p>
                <div className={styles.heroButtons}>
                    <a href="#cotizar" className={styles.btnPrimary}>Cotiza tu evento</a>
                    <a href="https://wa.me/+573134602232" className={styles.btnSecondary}>
                        <img src={whatsapp} alt="WhatsApp" className={styles.btnWhatsapp} />
                        Contáctanos
                    </a>
                </div>
            </div>
        </section>
    )
}

export default HeroSection
