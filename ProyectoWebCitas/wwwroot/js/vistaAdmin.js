// Función para inicializar los eventos de la vista "Mis Datos"
function initializeMisDatos() {
    const botonEditar = document.getElementById("botonEditar");
    const modalEdicionContra = document.getElementById("modalEdicionContra");

    if (botonEditar && modalEdicionContra) {
        botonEditar.addEventListener("click", function() {
            modalEdicionContra.style.display = "block";
        });
    }
}

// Función para cerrar el modal
function cerrarModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) modal.style.display = "none";
}

// Lógica para manejar los clics en los ítems del menú y cargar contenido dinámicamente
window.addEventListener("DOMContentLoaded", function() {
    const links = document.querySelectorAll(".menu a");
    const mainContent = document.getElementById("main-content");
    const container = document.querySelector('.container');
    const img = document.querySelector('img');

    links.forEach(function(link) {
        link.addEventListener("click", function(e) {
            e.preventDefault();

            // Quitar clase 'active' de todos los enlaces
            links.forEach(innerLink => innerLink.classList.remove("active"));

            // Añadir clase 'active' al enlace seleccionado
            this.classList.add("active");

            if (this.href.includes("/HTML/VistaPrincipalAdmin.html")) {
                container.style.display = "block";  // Muestra el container
                img.style.display = "block";  // Muestra la imagen
                mainContent.innerHTML = ""; // Vacía el contenido dinámico
                return;
            } else {
                container.style.display = "none";  // Oculta el container
                img.style.display = "none";  // Oculta la imagen
            }

            if (this.href && !this.href.includes("javascript:void(0);")) {
                fetch(this.href)
                    .then(response => response.text())
                    .then(data => {
                        mainContent.innerHTML = data;
                        
                        if (this.href.includes("/HTML/MisDatos.html")) {
                            initializeMisDatos();
                        }
                    })
                    .catch(error => console.error(error));
            }
        });
    });
});
