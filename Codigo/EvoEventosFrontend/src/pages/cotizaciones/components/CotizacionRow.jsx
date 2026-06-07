import React from 'react'

export const CotizacionRow = ({number, createdAt, clientName, clientEmail, eventName, eventDate, totalPrice, status, validUntil}) => {
  return (
    <tr>
            <td>
              <div className="numb-quot">{number}</div>
              <div className="date-cell">{createdAt}</div>
            </td>
            <td>
              <div className="client-cell">{clientName}</div>
              <div className="email-cell">{clientEmail}</div>
            </td>
            <td>
              <div className="event-cell">{eventName}</div>
              <div className="date-cell">{eventDate}</div>
            </td>
            <td>
              <div className="total-cell">{totalPrice}</div>
            </td>
            <td>
              <span className ={`status-quotation ${status === "Enviada" ? "status-send" : status === "Pendiente" ? "status-pending" : status === "Aprobada" ? "status-approved" : "status-rejected"}`}>{status}</span>
            </td>
            <td>
              <span className status ="deadline-cell">{validUntil}</span>

            </td>
            <td className="actions-cell">
              <button className="action-btn"><img src="/src/assets/Icons/docs.svg"/></button>
              <button className="action-btn"><img src="/src/assets/Icons/delete.svg"/></button>
            </td>
          </tr>
  )
}
