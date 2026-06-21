import { CotizacionRow } from "./components/CotizacionRow";
import { StatCard } from "./components/StatCard";
import { useState } from "react";
import { SearchFilter } from "./components/SearchFilter";
import styles from "./Cotizaciones.module.css"
import "./Cotizaciones.css";

const cotizaciones = [
  {
    number: "COT-2024-001",
    createdAt: "15 de enero de 2024",
    clientName: "Erika Andrea",
    clientEmail: "scrummaster@sena.com",
    eventName: "Cumpleaños Infantil",
    eventDate: "14 de febrero de 2024 • 50 personas",
    totalPrice: "$ 327.250",
    status: "Enviada",
    validUntil: "31 de enero de 2024",
  },
  {
    number: "COT-2024-002",
    createdAt: "31 de febrero de 2024",
    clientName: "Fabio Andres",
    clientEmail: "topotopo@gmail.com",
    eventName: "Evento Empresarial",
    eventDate: "8 de diciembre de 2025 • 50 personas",
    totalPrice: "$ 3.192.000",
    status: "Aprobada",
    validUntil: "4 de abril de 2024",
  },
  {
    number: "COT-2024-003",
    createdAt: "31 de febrero de 2024",
    clientName: "Jhanpool Parra",
    clientEmail: "jParra@outlook.com",
    eventName: "Despedida de Soltero",
    eventDate: "10 de junio de 2026 • 500 personas",
    totalPrice: "$ 120.192.500",
    status: "Pendiente",
    validUntil: "10 de mayo de 2024",
  },
  {
    number: "COT-2024-004",
    createdAt: "13 de Marzo de 2024",
    clientName: "Daniel Hernández",
    clientEmail: "DaniH@yahoo.com",
    eventName: "Matrimonio",
    eventDate: "30 de septiembre de 2025 • 1000 personas",
    totalPrice: "$ 520.896.000",
    status: "Rechazada",
    validUntil: "14 de julio de 2024",
  },
];

const statsCards = [
  {
    title: "Total",
    value: 5,
    indicator: "+1 este mes",
    iconSrc: "/src/assets/Icons/docs.svg",
    iconBg: "#FAF5FF",
  },
  {
    title: "Borradores",
    value: 1,
    indicator: "+8 vs mes anterior",
    iconSrc: "/src/assets/Icons/edit.svg",
    iconBg: "rgba(166, 170, 164, 0.38)",
  },
  {
    title: "Enviadas",
    value: 3,
    indicator: "12 en mantenimiento",
    iconSrc: "/src/assets/Icons/send.svg",
    iconBg: "rgba(219, 234, 254)",
  },
  {
    title: "Aprobadas",
    value: 1,
    indicator: "+22% vs mes anterior",
    iconSrc: "/src/assets/Icons/checkapprove.svg",
    iconBg: "rgba(214, 235, 214)",
  },
];

export const Cotizaciones = () => {
  //UseState

  const [selectedStatus, setSelectedStatus] = useState("Todos");
  const [searchText, setSearchText] = useState("");

  const cotizacionesFiltradas = cotizaciones.filter((cotizacion) => {
    return (
      (selectedStatus === "Todos" || cotizacion.status === selectedStatus) &&
      (cotizacion.clientName.toLowerCase().includes(searchText.toLowerCase()) ||
        cotizacion.clientEmail.toLowerCase().includes(searchText.toLowerCase()) ||
        cotizacion.number.toLowerCase().includes(searchText.toLowerCase()))
    );
  });

  return (
    <main className="dashboard">
      <div className={styles.pageHeader}>
        <div className={styles.titleSection}>
          <h1 className={styles.titleHeading}>Gestión de Cotizaciones</h1>
          <p className={styles.subtitle}>
            Crea y administra cotizaciones para Clientes
          </p>
        </div>
        <button
          className={styles.btnNuevaCotizacion}
          data-modal-target="modal-cotizacion"
        >
          <span>+</span> Nueva Cotización
        </button>
      </div>

      <section className={styles.cards}>
        {statsCards.map((card) => (
          <StatCard
            key={card.title}
            title={card.title}
            value={card.value}
            indicator={card.indicator}
            iconSrc={card.iconSrc}
            iconBg={card.iconBg}
          />
        ))}
      </section>

      <SearchFilter
        selectedStatus={selectedStatus}
        setSelectedStatus={setSelectedStatus}
        searchText={searchText}
        setSearchText={setSearchText}
      />

      <div className={styles.requestsContainer}>
        <h3 className={styles.requestsTitle}>Cotizaciones Creadas</h3>
        <table className={styles.requestsTable}>
          <thead>
            <tr>
              <th>Número</th>
              <th>Cliente</th>
              <th>Evento</th>
              <th>Total</th>
              <th>Estado</th>
              <th>Válida Hasta</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {cotizacionesFiltradas.map((cotizacion) => (
              <CotizacionRow
                key={cotizacion.number}
                number={cotizacion.number}
                createdAt={cotizacion.createdAt}
                clientName={cotizacion.clientName}
                clientEmail={cotizacion.clientEmail}
                eventName={cotizacion.eventName}
                eventDate={cotizacion.eventDate}
                totalPrice={cotizacion.totalPrice}
                status={cotizacion.status}
                validUntil={cotizacion.validUntil}
              />
            ))}
          </tbody>
        </table>
      </div>
    </main>
  );
};
