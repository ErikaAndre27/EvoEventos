import React from 'react'

export const StatCard = ({title, value, indicator, iconSrc, iconBg}) => {
  return (
      <div className="card">
        <p className="card-title">{title}</p>
        <div className="card-content">
          <div className="numbers">
            <h2>{value}</h2>
            <span className="indicator">{indicator}</span>
          </div>
          <div className="icon-container" style={{backgroundColor: iconBg}}>
            <img src={iconSrc} className="svg-iconmessage" />
          </div>
        </div>
      </div>
  )
}
