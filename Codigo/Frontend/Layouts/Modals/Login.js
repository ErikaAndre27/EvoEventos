
// ── Referencia a los elementos del HTML ──
// Guardamos los elementos en variables para
// no tener que buscarlos cada vez.
var modal   = document.getElementById('modal');
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
  var ojoAbierto    = document.getElementById('ojo-abierto');
  var ojoCerrado    = document.getElementById('ojo-cerrado');

  // Si el input está en modo "password", cambiarlo a "text" (visible)
  if (inputPassword.type === 'password') {
    inputPassword.type = 'text';
    ojoAbierto.style.display  = 'none';
    ojoCerrado.style.display  = 'block';
  } else {
    // Si ya está en "text", volver a ocultarlo
    inputPassword.type = 'password';
    ojoAbierto.style.display  = 'block';
    ojoCerrado.style.display  = 'none';
  }
}


/* ── Cerrar con tecla Escape ─────────────
   Si el usuario presiona Escape y el modal
   está abierto, lo cerramos.
────────────────────────────────────────── */
document.addEventListener('keydown', function(evento) {
  if (evento.key === 'Escape' && modal.classList.contains('activo')) {
    cerrarModal();
  }
});
