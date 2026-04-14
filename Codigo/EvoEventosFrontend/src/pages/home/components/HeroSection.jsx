import whatsapp from '../../../assets/Icons/whatsapp.svg'
import './HeroSection.css'

const HeroSection = () => {
    return (
        <section class="hero-section">
            <div class="hero-content">
                <h1 class="hero-title">Todo Lo que Tu Evento Necesita, En Un Solo Lugar</h1>
                <p class="hero-subtitle">Cotiza en minutos equipos, comidas y juegos inflables para tu evento</p>
                <div class="hero-buttons">
                    <a href="#cotizar" class="btn-primary">Cotiza tu evento</a>
                    <a href="https://wa.me/+573134602232" class="btn-secondary">
                        <img src={whatsapp} alt="WhatsApp" class="btn-whatsapp" />
                        Contáctanos
                    </a>
                </div>
            </div>
        </section>
    )
}

export default HeroSection
