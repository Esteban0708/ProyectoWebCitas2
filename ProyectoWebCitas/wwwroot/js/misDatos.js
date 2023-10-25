function initializeMisDatos() {
    const botonEditarContra = document.getElementById("botonEditar");
    const modalContra = document.getElementById("modalEdicionContra");

    function mostrarModal() {
        modalContra.style.display = "flex";
    }

    window.cerrarModal = function(modalId) {
        const modal = document.getElementById(modalId);
        if (modal) modal.style.display = "none";
    }

    botonEditarContra.addEventListener("click", mostrarModal);

    modalContra.addEventListener("click", function(event) {
        const modalContent = modalContra.querySelector(".modal-content");
        if (!modalContent.contains(event.target)) {
            cerrarModal("modalEdicionContra");
        }
    });

    const modalContent = modalContra.querySelector(".modal-content");
    modalContent.addEventListener("click", function(event) {
        event.stopPropagation();
    });
}
