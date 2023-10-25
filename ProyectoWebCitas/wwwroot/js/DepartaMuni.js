document.addEventListener("DOMContentLoaded", function() {

    document.getElementById("departamentos").addEventListener("change", function() {
        let departamento = this.options[this.selectedIndex].text;
        cargarMunicipios(departamento);
    });

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
});
