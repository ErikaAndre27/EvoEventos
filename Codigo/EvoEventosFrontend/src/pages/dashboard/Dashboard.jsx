import NavBar from "../../NavBar"
import { useAuthStore } from "../../store/auth"
import styles from "./Dashboard.module.css"

export const Dashboard = ({ logout }) => {

    const role = useAuthStore((state) => state.profile?.role)
    const nameAsesor = useAuthStore((state) => state.profile?.names)

    return (
        <>
            <section className={styles.dashboard}>
                <h1>{role == 'Admin' ? 'Panel de Administración' : `Hola ${nameAsesor}`}</h1>
                <p className={styles.subtitle}>{role == 'Admin' ? 'Gestiona tu negocio de eventos de manera completa y eficiente' : 'Gestiona tus eventos, cotizaciones y pagos de manera eficiente'}</p>

                <section className={styles.cards}>
                    <div className={styles.card}>
                        <p className={styles.cardTitle}>Total asesores</p>
                        <div className={styles.cardContent}>
                            <div className={styles.numbers}>
                                <h2>8</h2>
                                <span className={styles.indicator}>+1 este mes</span>
                            </div>
                            <div className={styles.icon}>👤</div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <p className={styles.cardTitle}>Eventos este mes</p>
                        <div className={styles.cardContent}>
                            <div className={styles.numbers}>
                                <h2>24</h2>
                                <span className={styles.indicator}>+8 vs mes anterior</span>
                            </div>
                            <div className={styles.icon}>📅</div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <p className={styles.cardTitle}>Items inventario</p>
                        <div className={styles.cardContent}>
                            <div className={styles.numbers}>
                                <h2>340</h2>
                                <span className={styles.indicator}>12 en mantenimiento</span>
                            </div>
                            <div className={styles.icon}>📦</div>
                        </div>
                    </div>

                    <div className={styles.card}>
                        <p className={styles.cardTitle}>Ingresos mes</p>
                        <div className={styles.cardContent}>
                            <div className={styles.numbers}>
                                <h2>$125,430</h2>
                                <span className={styles.indicator}>+22% vs mes anterior</span>
                            </div>
                            <div className={styles.icon}>💰</div>
                        </div>
                    </div>
                </section>

                <section className={styles.bottom}>
                    <div className={styles.activity}>
                        <h3>Actividad Reciente</h3>
                        <button className={styles.viewAll}>Ver Todo</button>

                        <ul>
                            <li>
                                <strong>Nuevo evento registrado</strong>
                                <span>Boda de María González - $12.000</span>
                                <small>Carlos Ruiz • Hace 15 min</small>
                            </li>
                            <li>
                                <strong>Pago recibido</strong>
                                <span>Evento corporativo TechCorp - $8.500</span>
                                <small>Ana Martínez • Hace 1 hora</small>
                            </li>
                            <li>
                                <strong>Item agregado al inventario</strong>
                                <span>Castillo inflable grande - 2 unidades</span>
                                <small>Sistema • Hace 2 horas</small>
                            </li>
                            <li>
                                <strong>Nuevo cliente registrado</strong>
                                <span>Empresa Celebrations Inc.</span>
                                <small>Luis Fernández • Hace 3 horas</small>
                            </li>
                        </ul>
                    </div>

                    <div className={styles.topAsesores}>
                        <h3>Top asesores del mes</h3>
                        <ul>
                            <li><span>1. Carlos Ruíz</span> <span>$45.200 ⭐4.9</span></li>
                            <li><span>2. Ana Martínez</span> <span>$38.500 ⭐4.8</span></li>
                            <li><span>3. Luis Fernández</span> <span>$29.300 ⭐4.7</span></li>
                            <li><span>4. María Rodríguez</span> <span>$22.100 ⭐4.6</span></li>
                        </ul>
                    </div>
                </section>
            </section>
        </>
    )
}

