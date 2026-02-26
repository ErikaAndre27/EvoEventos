class DataCard extends HTMLElement {
  constructor() {
    super();
    this.attachShadow({ mode: 'open' })
  }
  connectedCallback() {
    const indicators = {
      default: 'indicator',
      gris: 'indicator-gris',
      positive: 'indicator-positive'
    }
    this.shadowRoot.innerHTML =
      `
        <style>
        .card {
  display: flex;
  flex-direction: column;
  transition: all 0.2s ease;
  background-color: #fff;
  border: 1px solid var(--color-borde);
  border-radius: 12px;
  padding: 24px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
  justify-content: space-between;
  height: fit-content;
  justify-content: flex-start;
  gap: 8px;
}

.card:hover {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
}

.card-content {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  width: 100%;
}

.numbers {
  display: flex;
  flex-direction: column;
  gap: 4px;
}

.numbers h2 {
  font-size: 32px;
  font-weight: 600;
  color: #333;
  margin: 0;
  line-height: 1;
}

.indicator {
  font-size: 12px;
  color: #00a650;
  font-weight: 500;
}

.card .icon {
  font-size: 24px;
}

.icon-container {
    width: 48px;
    height: 48px;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.indicator.positive {
  color: var(--color-exito);
}

.indicator-gris {
  font-size: 12px;
  color: #6A7282;
  font-weight: 500;
}
  .icon-container {
  grid-row: 1 / 3;
  align-self: center;
  width: 38px;
  height: 38px;
}
  .card-title {
  font-size: 14px;
  color: #6A7282;
  grid-column: 2;
  grid-row: 2;
  margin: 0;
  text-align: left;
  display: block;     
  width: 100%;  
  font-weight: 400;
  
}

        </style>
        <div class="card">
            <p class="card-title">${this.getAttribute('title') || ''}</p>
            <div class="card-content">
              <div class="numbers">
                <h2>${this.getAttribute('quantity') || 0}</h2>
                <span class="${indicators[this.getAttribute('indicator_variant')|| 'default']}">${this.getAttribute('indicator')}</span>
              </div>
              <div class="icon-container" style="background-color: #FAF5FF;">
                <img src="${this.getAttribute('src') || ''}" alt="${this.getAttribute('alt') || ''}"></div> 
            </div>
          </div>`;
  }
}

customElements.define('data-card', DataCard);