function initializeCrearUsuarioSuper() {
    document.getElementById("departamentos").addEventListener("change", function() {
        let departamento = this.options[this.selectedIndex].text;
        cargarMunicipios(departamento);
    });
}

function cargarMunicipios(departamento) {
    const municipiosSelect = document.getElementById("municipios");

    // Limpiar las opciones anteriores
    municipiosSelect.innerHTML = "";

    let municipios = [];

    switch (departamento) {
        case "Antioquia":
            municipios = ["Medellín", "Bello", "Envigado"];
            break;
        case "Atlántico":
            municipios = ["Barranquilla", "Soledad", "Malambo"];
            break;
        case "Bolívar":
            municipios = ["Cartagena", "Magangué", "El Carmen de Bolívar"];
            break;
        case "Boyacá":
            municipios = ["Tunja", "Duitama", "Sogamoso"];
            break;
        case "Caldas":
            municipios = ["Manizales", "Villamaría", "La Dorada"];
            break;
        case "Caquetá":
            municipios = ["Florencia", "Belén de los Andaquíes", "Cartagena del Chairá"];
            break;
        case "Casanare":
            municipios = ["Yopal", "Aguazul", "Villanueva"];
            break;
        case "Vichada":
            municipios = ["Puerto Carreño", "La Primavera", "Santa Rosalía"];
            break;
        case "Arauca":
                municipios = ["Arauca", "Arauquita", "Saravena"];
            break;
        case "Amazonas":
                municipios = ["Leticia", "El Encanto", "La Chorrera"];
            break;
        case "Cauca":
                municipios = ["Popayán", "Santander de Quilichao", "Corinto"];
            break;
        case "Cesar":
                municipios = ["Valledupar", "Aguachica", "La Paz"];
            break;
        case "Chocó":
                municipios = ["Quibdó", "Nuquí", "El Carmen de Atrato"];
            break;
        case "Córdoba":
                municipios = ["Montería", "Cereté", "Lorica"];
            break;
        case "Cundinamarca":
                municipios = ["Bogotá", "Soacha", "Girardot"];
            break;
        case "Guainía":
                municipios = ["Inírida", "Barranco Minas", "Mapiripana"];
            break;
        case "Guaviare":
                municipios = ["San José del Guaviare", "Calamar", "El Retorno"];
            break;
        case "Huila":
                municipios = ["Neiva", "Pitalito", "Garzón"];
            break;
        case "La Guajira":
                municipios = ["Riohacha", "Maicao", "Uribia"];
            break;
        case "Magdalena":
                municipios = ["Santa Marta", "Ciénaga", "El Banco"];
            break;
        case "Meta":
                municipios = ["Villavicencio", "Granada", "Puerto López"];
            break;
        case "Nariño":
                municipios = ["Pasto", "Tumaco", "Ipiales"];
            break;
        case "Norte de Santander":
                municipios = ["Cúcuta", "Ocaña", "Villa del Rosario"];
            break;
        case "Putumayo":
                municipios = ["Mocoa", "Puerto Asís", "Villagarzón"];
            break;
        case "Quindío":
                municipios = ["Armenia", "Montenegro", "Circasia"];
            break;
        case "Risaralda":
                municipios = ["Pereira", "Dosquebradas", "Santa Rosa de Cabal"];
            break;
        case "San Andrés y Providencia":
                municipios = ["San Andrés", "Providencia"];
            break;
        case "Santander":
                municipios = ["Bucaramanga", "Floridablanca", "Girón"];
            break;
        case "Sucre":
                municipios = ["Sincelejo", "Corozal", "Tolú"];
            break;
        case "Tolima":
                municipios = ["Ibagué", "Espinal", "Melgar"];
            break;
        case "Valle del Cauca":
                municipios = ["Cali", "Buenaventura", "Palmira"];
            break;
        case "Vaupés":
                municipios = ["Mitú", "Pacoa", "Yavaraté"];
            break;                
    }

    for (let municipio of municipios) {
        let option = new Option(municipio, municipio);
        municipiosSelect.options.add(option);
    }
}

// Función para inicializar los eventos de la vista "Mis Datos"
function initializeMisDatos() {
    // Aquí pondrás el código para inicializar los eventos 
    // de los botones "Editar" y otros elementos interactivos.
    
    const botonEditar = document.getElementById("botonEditar");
    const modalEdicionContra = document.getElementById("modalEdicionContra");

    botonEditar.addEventListener("click", function() {
        modalEdicionContra.style.display = "block";
    });

    // Puedes agregar otros eventos aquí si es necesario...
}

// Función para cerrar el modal
function cerrarModal(modalId) {
    const modal = document.getElementById(modalId);
    if (modal) modal.style.display = "none";
}

// Lógica para manejar los clics en los ítems del menú y cargar contenido dinámicamente
window.addEventListener("DOMContentLoaded", function() {
    const links = document.querySelectorAll(".menu a");

    links.forEach(function(link) {
        link.addEventListener("click", function(e) {
            e.preventDefault();

            links.forEach(innerLink => innerLink.classList.remove("active"));
            this.classList.add("active");

            if (this.href.includes("/HTML/vistaprincipalSUPER.html")) {
                const img = document.querySelector("img");
                if (img) img.style.display = "block";
                document.getElementById("main-content").innerHTML = "";
                return;
            }

            if (this.href && !this.href.includes("javascript:void(0);")) {
                fetch(this.href)
                    .then(response => response.text())
                    .then(data => {
                        document.getElementById("main-content").innerHTML = data;

                        const img = document.querySelector("img");
                        if (img) img.style.display = "none";

                        if (this.href.includes("/HTML/MisDatos.html")) {
                            initializeMisDatos();
                        }
                        if (this.href.includes("/HTML/CrearUsuarioSuper.html")) {
                            initializeCrearUsuarioSuper(); // Inicializamos los eventos para esta vista
                        }
                    })
                    .catch(error => console.error(error));
            }
        });
    });
});
