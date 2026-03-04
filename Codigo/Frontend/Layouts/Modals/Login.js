
// ── Referencia a los elementos del HTML ──
// Guardamos los elementos en variables para
// no tener que buscarlos cada vez.
var modal = document.getElementById('modal');
var overlay = document.getElementById('overlay');


/* ── abrirModal() ────────────────────────
   Abre el modal añadiendo la clase "activo"
   al modal y al overlay.
   También añade "modal-abierto" al body
   para activar el blur de fondo.
────────────────────────────────────────── */
function abrirModal() {
  modal.classList.add('activo');
  overlay.classList.add('activo');
  document.body.classList.add('modal-abierto');
}


/* ── cerrarModal() ───────────────────────
   Cierra el modal quitando las clases "activo".
   Se llama al hacer clic en el overlay o en
   el botón de cerrar (X).
────────────────────────────────────────── */
function cerrarModal() {
  modal.classList.remove('activo');
  overlay.classList.remove('activo');
  document.body.classList.remove('modal-abierto');
}


/* ── togglePassword() ────────────────────
   Alterna entre mostrar y ocultar la contraseña.
   Cambia el tipo del input entre "password" y "text".
   También intercambia los íconos del ojo.
────────────────────────────────────────── */
function togglePassword() {
  var inputPassword = document.getElementById('contrasena');
  var ojoAbierto = document.getElementById('ojo-abierto');
  var ojoCerrado = document.getElementById('ojo-cerrado');

  // Si el input está en modo "password", cambiarlo a "text" (visible)
  if (inputPassword.type === 'password') {
    inputPassword.type = 'text';
    ojoAbierto.style.display = 'none';
    ojoCerrado.style.display = 'block';
  } else {
    // Si ya está en "text", volver a ocultarlo
    inputPassword.type = 'password';
    ojoAbierto.style.display = 'block';
    ojoCerrado.style.display = 'none';
  }
}


/* ── Cerrar con tecla Escape ─────────────
   Si el usuario presiona Escape y el modal
   está abierto, lo cerramos.
────────────────────────────────────────── */
document.addEventListener('keydown', function (evento) {
  if (evento.key === 'Escape' && modal.classList.contains('activo')) {
    cerrarModal();
  }
});
// === PASO 1: Capturar el formulario ===

// Busca el formulario en el HTML (tiene la clase "modal-form")
var formulario = document.querySelector('.modal-form');

// Le dice al formulario: "cuando alguien haga clic en Iniciar Sesión, ejecuta esta función"
formulario.addEventListener('submit', function (evento) {

  var email = document.getElementById('email').value;
  var contrasena = document.getElementById('contrasena').value;

  if (email === '' || contrasena === '') {           // Si alguno de los campos está vacío, muestra una alerta o error en el navegador
    alert('Por favor, complete todos los campos.');
    evento.preventDefault();
    return false; // Evita el envío del formulario
  }

  $.ajax({
    url: 'https://localhost:7208/api/Auth/Login', // agregar el controldador y el método
    type: 'POST',
    contentType: 'application/json; charset=utf-8',
    data: JSON.stringify({ Identifier: email, Password: contrasena }), //poner los campos que espera recibir el controlador, tienen que llamarse igual al modelo, esto prácticamente es un json
    success: function (resp) {
      localStorage.setItem('token', resp.token);
      console.log("Respuesta: " , parseJwt(resp.token));
    }, 
    error: function (xhr) {
      alert('Error al guardar');
    }
  });
});

function parseJwt(token) { // Función para decodificar el token JWT y obtener su contenido
    let base64Url = token.split('.')[1];
    let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(
        atob(base64)
        .split('')
        .map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join('')
    );

    return JSON.parse(jsonPayload);
}
 
