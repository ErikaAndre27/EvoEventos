document.addEventListener('DOMContentLoaded', () => {
    // 1. Manejo del menú móvil
    const closeMenuButton = document.querySelector('.close-menu');
    const menuToggleButton = document.querySelector('.open-menu');
    
    menuToggleButton?.addEventListener('click', () => {
        document.querySelector('nav').classList.add('menu-open');
    });

    closeMenuButton?.addEventListener('click', () => {
        document.querySelector('nav').classList.remove('menu-open');
    });

    // 2. Active automático mejorado
    const currentPath = window.location.pathname;
    const currentPage = currentPath.split('/').pop() || '';
    
    console.log('Página actual detectada:', currentPage);
    
    const navLinks = document.querySelectorAll('nav a');
    
    navLinks.forEach(link => {
        link.classList.remove('active');
        
        const linkHref = link.getAttribute('href');
        const linkText = link.textContent.trim().toLowerCase();
        
        console.log('Enlace:', linkText, 'href:', linkHref);
        
        // 1. Comparación por nombre de archivo
        if (linkHref && currentPage && linkHref.includes(currentPage)) {
            console.log('Coincidencia por nombre de archivo:', linkText);
            link.classList.add('active');
        }
        
        // 2. Lógica especial para Dashboard
        if (currentPage === '' || 
            currentPage.includes('PanelAdministrador') || 
            currentPage.includes('Dashboard') ||
            currentPage.includes('index')) {
            if (linkText === 'dashboard') {
                console.log('Dashboard detectado como activo');
                link.classList.add('active');
            }
        }
    });
    
    // 3. Cerrar menú al hacer clic en cualquier enlace (solo móvil)
    navLinks.forEach(link => {
        link.addEventListener('click', () => {
            if (window.innerWidth <= 720) {
                document.querySelector('nav').classList.remove('menu-open');
            }
        });
    });
});