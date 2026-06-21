import React from "react";
import styles from "./CotizacionRow.module.css";

export const CotizacionRow = ({
  number,
  createdAt,
  clientName,
  clientEmail,
  eventName,
  eventDate,
  totalPrice,
  status,
  validUntil,
}) => {
  return (
    <tr>
      <td>
        <div className={styles.numbQuot}>{number}</div>
        <div className={styles.dateCell}>{createdAt}</div>
      </td>
      <td>
        <div className={styles.clientCell}>{clientName}</div>
        <div className={styles.emailCell}>{clientEmail}</div>
      </td>
      <td>
        <div className={styles.eventCell}>{eventName}</div>
        <div className={styles.dateCell}>{eventDate}</div>
      </td>
      <td>
        <div className={styles.totalCell}>{totalPrice}</div>
      </td>
      <td>
        <span
          className={`${styles.statusQuotation} ${
            status === "Enviada"
              ? styles.statusSend
              : status === "Pendiente"
                ? styles.statusPending
                : status === "Aprobada"
                  ? styles.statusApproved
                  : styles.statusRejected
          }`}
        >
          {status}
        </span>
      </td>
      <td>
        <span className={styles.deadlineCell}>{validUntil}</span>
      </td>
      <td className={styles.actionsCell}>
        <button className={styles.actionBtn}>
          <img src="/src/assets/Icons/docs.svg" />
        </button>
        <button className={styles.actionBtn}>
          <img src="/src/assets/Icons/delete.svg" />
        </button>
      </td>
    </tr>
  );
};
