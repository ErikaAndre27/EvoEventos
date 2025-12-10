/* ============================================
   GESTOR DE MODALES Y FUNCIONES GLOBALES
   ============================================ */

// ========== CARGAR MODAL AUTOMÁTICAMENTE ==========
document.addEventListener('DOMContentLoaded', function() {
  // Crear contenedor para el modal si no existe
  if (!document.getElementById('modal-container')) {
    const container = document.createElement('div');
    container.id = 'modal-container';
    document.body.appendChild(container);
  }

  // Cargar el modal de login
  fetch('../components/modal-login.html')
    .then(response => {
      if (!response.ok) throw new Error('No se pudo cargar el modal de login');
      return response.text();
    })
    .then(html => {
      document.getElementById('modal-container').innerHTML = html;
    })
    .catch(error => {
      console.error('Error cargando modal de login:', error);
    });

  // Cargar el modal de empty state
  fetch('../components/modal-empty-state.html')
    .then(response => {
      if (!response.ok) throw new Error('No se pudo cargar el modal empty state');
      return response.text();
    })
    .then(html => {
      const div = document.createElement('div');
      div.innerHTML = html;
      document.body.appendChild(div.firstElementChild);
    })
    .catch(error => {
      console.error('Error cargando modal empty state:', error);
    });
});

// ========== FUNCIONES DEL MODAL ==========

// Abrir modal
function openModal() {
  const modal = document.getElementById('modalLogin');
  if (modal) {
    modal.classList.add('active');
    document.body.style.overflow = 'hidden'; // Prevenir scroll
  }
}

// Cerrar modal
function closeModal() {
  const modal = document.getElementById('modalLogin');
  if (modal) {
    modal.classList.remove('active');
    document.body.style.overflow = ''; // Restaurar scroll
  }
}

// Cerrar al hacer clic fuera del modal
function closeModalOnOutsideClick(event) {
  if (event.target.id === 'modalLogin') {
    closeModal();
  }
}

// Toggle mostrar/ocultar contraseña
function togglePassword() {
  const passwordInput = document.getElementById('passwordInput');
  const eyeIcon = document.getElementById('eyeIcon');
  
  if (passwordInput && eyeIcon) {
    if (passwordInput.type === 'password') {
      passwordInput.type = 'text';
      eyeIcon.innerHTML = '<path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"></path><line x1="1" y1="1" x2="23" y2="23"></line>';
    } else {
      passwordInput.type = 'password';
      eyeIcon.innerHTML = '<path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle>';
    }
  }
}

// Manejo del submit del login
function handleLoginSubmit(event) {
  event.preventDefault();
  
  // Obtener valores del formulario
  const tipoUsuario = document.getElementById('tipoUsuario').value;
  const usuario = document.getElementById('usuario').value;
  const password = document.getElementById('passwordInput').value;
  
  // Aquí iría tu lógica de autenticación
  console.log('Login:', { tipoUsuario, usuario, password });
  
  // Ejemplo: redireccionar según tipo de usuario
  if (tipoUsuario === 'admin') {
    window.location.href = 'PanelAdministrador.html';
  } else if (tipoUsuario === 'asesor') {
    window.location.href = 'GestionAsesores.html';
  } else if (tipoUsuario === 'cliente') {
    window.location.href = 'ClienteDashboard.html';
  }
  
  closeModal();
}

// Manejo de "olvidaste contraseña"
function handleForgotPassword(event) {
  event.preventDefault();
  alert('Aquí iría el flujo de recuperación de contraseña');
  // O puedes abrir otro modal, redirigir, etc.
}

// Cerrar modal con tecla ESC
document.addEventListener('keydown', function(event) {
  if (event.key === 'Escape') {
    closeModal();
  }
});

// ========== OTRAS FUNCIONES GLOBALES ==========

// Manejo de navegación activa (si lo necesitas)
document.addEventListener('DOMContentLoaded', function() {
  const links = document.querySelectorAll('nav a');
  links.forEach(link => {
    link.addEventListener('click', function(e) {
      // Remover active de todos
      document.querySelectorAll('nav a.active').forEach(a => {
        a.classList.remove('active');
      });
      // Agregar active al clickeado
      this.classList.add('active');
    });
  });
});
