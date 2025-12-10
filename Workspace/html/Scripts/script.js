
class DashboardApp {
    constructor() {
        this.initDropdowns();
        this.initSearch();
        this.initFilters();
    }

    // Dropdowns
    initDropdowns() {
        document.querySelectorAll('.dropdown-button').forEach(button => {
            button.addEventListener('click', (e) => {
                e.stopPropagation();
                const dropdown = button.nextElementSibling;
                const isActive = dropdown.classList.contains('active');
                
                // Cerrar todos
                document.querySelectorAll('.dropdown-menu').forEach(menu => {
                    menu.classList.remove('active');
                });
                document.querySelectorAll('.dropdown-button').forEach(btn => {
                    btn.classList.remove('active');
                });
                
                // Abrir este si estaba cerrado
                if (!isActive) {
                    dropdown.classList.add('active');
                    button.classList.add('active');
                }
            });
        });

        // Seleccionar opción
        document.querySelectorAll('.dropdown-item').forEach(item => {
            item.addEventListener('click', (e) => {
                const dropdown = item.closest('.dropdown-menu');
                const button = dropdown.previousElementSibling;
                const text = item.textContent.trim();
                
                // Actualizar botón
                button.querySelector('span:first-child').textContent = text;
                
                // Actualizar selección
                dropdown.querySelectorAll('.dropdown-item').forEach(i => {
                    i.classList.remove('selected');
                });
                item.classList.add('selected');
                
                // Cerrar dropdown
                dropdown.classList.remove('active');
                button.classList.remove('active');
                
                // Filtrar tabla (ejemplo)
                this.filterTableByStatus(text);
            });
        });

        // Cerrar al hacer clic fuera
        document.addEventListener('click', () => {
            document.querySelectorAll('.dropdown-menu').forEach(menu => {
                menu.classList.remove('active');
            });
            document.querySelectorAll('.dropdown-button').forEach(button => {
                button.classList.remove('active');
            });
        });
    }

    // Búsqueda
    initSearch() {
        const searchInput = document.querySelector('.search-wrapper input');
        if (searchInput) {
            searchInput.addEventListener('input', (e) => {
                this.searchTable(e.target.value);
            });
        }
    }

    // Filtros
    initFilters() {
        console.log('Filtros inicializados');
    }

    // Filtrar tabla por estado
    filterTableByStatus(status) {
        const rows = document.querySelectorAll('.requests-table tbody tr');
        rows.forEach(row => {
            const rowStatus = row.querySelector('.status-badge').textContent.trim();
            const shouldShow = status === 'Todos los estados' || 
                              rowStatus.includes(status);
            row.style.display = shouldShow ? '' : 'none';
        });
    }

    // Buscar en tabla
    searchTable(query) {
        const rows = document.querySelectorAll('.requests-table tbody tr');
        const lowerQuery = query.toLowerCase();
        
        rows.forEach(row => {
            const text = row.textContent.toLowerCase();
            row.style.display = text.includes(lowerQuery) ? '' : 'none';
        });
    }
}

// Inicializar cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    new DashboardApp();
});

