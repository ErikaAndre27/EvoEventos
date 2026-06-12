import React from "react";
import { useState } from "react";
import arrowIcon from "../../../assets/Icons/arrow_drop_down.svg"

export const SearchFilter = ({
  selectedStatus,
  setSelectedStatus,
  searchText,
  setSearchText,
}) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className="search-filter-bar">
      <div className="search-wrapper">
        <div className="search-icon">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            width="18"
            height="18"
            viewBox="0 0 24 24"
            fill="none"
            stroke="currentColor"
            strokeWidth="2"
            strokeLinecap="round"
            strokeLinejoin="round"
          >
            <circle cx="11" cy="11" r="8"></circle>
            <line x1="21" y1="21" x2="16.65" y2="16.65"></line>
          </svg>
        </div>
        <input
          type="text"
          className="search-input"
          placeholder="Buscar por cliente, número de cotización o email..."
          value={searchText}
          onChange={(e) => setSearchText(e.target.value)}
        />
      </div>

      <div className="dropdown-container">
        <button className={`dropdown-button ${isOpen ? "active" : ""}`} onClick={() => setIsOpen(!isOpen)}>
          <span>{selectedStatus}</span>
          <span className="dropdown-icon">
            <img src={arrowIcon} />
          </span>
        </button>

        <div className={`dropdown-menu ${isOpen ? "active" : ""}`}>
          <div
            className="dropdown-item selected"
            onClick={() => {
              setSelectedStatus("Todos");
              setIsOpen(false);
            }}
          >
            <span className="status-indicator todos"></span>
            Todos los estados
          </div>
          <div
            className="dropdown-item"
            onClick={() => {
              setSelectedStatus("Pendiente");
              setIsOpen(false);
            }}
          >
            <span className="status-indicator pendientes"></span>
            Pendientes
          </div>
          <div
            className="dropdown-item"
            onClick={() => {
              setSelectedStatus("Enviada");
              setIsOpen(false);
            }}
          >
            <span className="status-indicator proceso"></span>
            En Proceso
          </div>
          <div
            className="dropdown-item"
            onClick={() => {
              setSelectedStatus("Aprobada");
              setIsOpen(false);
            }}
          >
            <span className="status-indicator cotizadas"></span>
            Cotizadas
          </div>
          <div
            className="dropdown-item"
            onClick={() => {
              setSelectedStatus("Rechazada");
              setIsOpen(false);
            }}
          >
            <span className="status-indicator rechazadas"></span>
            Rechazadas
          </div>
        </div>
      </div>
    </div>
  );
};
