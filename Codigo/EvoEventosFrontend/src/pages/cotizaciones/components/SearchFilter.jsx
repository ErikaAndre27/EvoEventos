import React from "react";
import { useState } from "react";
import styles from "./SearchFilter.module.css";
import arrowIcon from "../../../assets/Icons/arrow_drop_down.svg";

export const SearchFilter = ({
  selectedStatus,
  setSelectedStatus,
  searchText,
  setSearchText,
}) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div className={styles.searchFilterBar}>
      <div className={styles.searchWrapper}>
        <div className={styles.searchIcon}>
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
          className={styles.searchInput}
          placeholder="Buscar por cliente, número de cotización o email..."
          value={searchText}
          onChange={(e) => setSearchText(e.target.value)}
        />
      </div>

      <div className={styles.dropdownContainer}>
        <button
          className={`${styles.dropdownButton} ${
            isOpen ? styles.buttonActive : ""
          }`}
          onClick={() => setIsOpen(!isOpen)}
        >
          <span>{selectedStatus}</span>
          <span
            className={`${styles.dropdownIcon} ${
              isOpen ? styles.iconRotated : ""
            }`}
          >
            <img src={arrowIcon} alt="Abrir menú" />
          </span>
        </button>

        <div
          className={`${styles.dropdownMenu} ${
            isOpen ? styles.menuActive : ""
          }`}
        >
          <div
            className={`${styles.dropdownItem} ${
              selectedStatus === "Todos" ? styles.selected : ""
            }`}
            onClick={() => {
              setSelectedStatus("Todos");
              setIsOpen(false);
            }}
          >
            <span
              className={`${styles.statusIndicator} ${styles.todos}`}
            ></span>
            Todos los estados
          </div>
          <div
            className={`${styles.dropdownItem} ${
              selectedStatus === "Pendiente" ? styles.selected : ""
            }`}
            onClick={() => {
              setSelectedStatus("Pendiente");
              setIsOpen(false);
            }}
          >
            <span
              className={`${styles.statusIndicator} ${styles.pendientes}`}
            ></span>
            Pendientes
          </div>
          <div
            className={`${styles.dropdownItem} ${
              selectedStatus === "Enviada" ? styles.selected : ""
            }`}
            onClick={() => {
              setSelectedStatus("Enviada");
              setIsOpen(false);
            }}
          >
            <span
              className={`${styles.statusIndicator} ${styles.proceso}`}
            ></span>
            En Proceso
          </div>
          <div
            className={`${styles.dropdownItem} ${
              selectedStatus === "Aprobada" ? styles.selected : ""
            }`}
            onClick={() => {
              setSelectedStatus("Aprobada");
              setIsOpen(false);
            }}
          >
            <span
              className={`${styles.statusIndicator} ${styles.cotizadas}`}
            ></span>
            Aprobadas
          </div>
          <div
            className={`${styles.dropdownItem} ${
              selectedStatus === "Rechazada" ? styles.selected : ""
            }`}
            onClick={() => {
              setSelectedStatus("Rechazada");
              setIsOpen(false);
            }}
          >
            <span
              className={`${styles.statusIndicator} ${styles.rechazadas}`}
            ></span>
            Rechazadas
          </div>
        </div>
      </div>
    </div>
  );
};
