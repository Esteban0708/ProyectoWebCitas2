document.getElementById("btn_registrarse").addEventListener("click", registro);
document.getElementById("btn_iniciarSesion").addEventListener("click", iniciarSesion);

window.addEventListener("resize", anchoPagina);

//declaracion de variables
var contenedor_login_registro = document.querySelector(".contenedor_login-registro");
var formulario_login = document.querySelector(".formulario_login");
var formulario_registro = document.querySelector(".formulario_registro");
var CajaTrasera_login = document.querySelector(".caja_trasera-login");
var CajaTrasera_registro = document.querySelector(".caja_trasera-registro");

function anchoPagina(){
    if(window.innerWidth>850){
        CajaTrasera_login.style.display= "block";
        CajaTrasera_registro.style.display= "block"; 
    }else{
        CajaTrasera_registro.style.display = "block";
        CajaTrasera_registro.style.opacity = "1";
        CajaTrasera_login.style.display = "none";
        formulario_login.style.display ="block"; 
        formulario_registro.style.display="none"; 
        contenedor_login_registro.style.left="0";
    }
}
anchoPagina(); 

function registro() {
    /**
     * cuando le demos click en el boton de registro de mostrara
     */
    if(window.innerWidth>850){
        formulario_registro.style.display = "block";
        contenedor_login_registro.style.left = "410px";
        formulario_login.style.display = "none";
        CajaTrasera_registro.style.opacity = "0";
        CajaTrasera_login.style.opacity = "1";
    }else{
        formulario_registro.style.display = "block";
        contenedor_login_registro.style.left = "0px";
        formulario_login.style.display = "none";
        CajaTrasera_registro.style.display = "none";
        CajaTrasera_login.style.display = "block";
        CajaTrasera_login.style.opacity = "1";
    }
    
}
function iniciarSesion() {
    /**
     * cuando le demos click en el boton de login de mostrara
     */
    if (window.innerWidth> 850) {
        formulario_registro.style.display = "none";
        contenedor_login_registro.style.left = "10px";
        formulario_login.style.display = "block";
        CajaTrasera_registro.style.opacity = "1";
        CajaTrasera_login.style.opacity = "0";
    }else{
        formulario_registro.style.display = "none";
        contenedor_login_registro.style.left = "0px";
        formulario_login.style.display = "block";
        CajaTrasera_registro.style.display = "block";
        CajaTrasera_login.style.display = "none";
    }

}
function checkHash() {
    if (window.location.hash === "#register") {
        registro();
    } else if (window.location.hash === "#Login") {
        iniciarSesion();
    }
}
window.addEventListener("load", checkHash);

