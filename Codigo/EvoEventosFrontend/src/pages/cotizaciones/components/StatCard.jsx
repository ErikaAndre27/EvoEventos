import React from 'react'
import styles from './StatCard.module.css'

export const StatCard = ({title, value, indicator, iconSrc, iconBg}) => {
  return (
      <div className={styles.card}>
        <p className={styles.cardTitle}>{title}</p>
        <div className={styles.cardContent}>
          <div className={styles.numbers}>
            <h2>{value}</h2>
            <span className={styles.indicator}>{indicator}</span>
          </div>
          <div className={styles.iconContainer} style={{backgroundColor: iconBg}}>
            <img src={iconSrc} className="svg-iconmessage" />
          </div>
        </div>
      </div>
  )
}
