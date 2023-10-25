var eye = document.getElementById('Eye');
var contra = document.getElementById('contra');

eye.addEventListener("click", function() {
    if (contra.type == "password") {
        contra.type = "text";  // Corregí esta línea
        eye.style.opacity = 0.8;
        eye.src = "/imagenes/ojoo2.png";  // Cambia a la ruta de tu imagen
    } else {
        contra.type = "password";
        eye.style.opacity = 1;  // Puedes cambiar esto según lo que desees
        eye.src = "/imagenes/ojo.png";  // Cambia a la ruta original de tu imagen
    }
});
