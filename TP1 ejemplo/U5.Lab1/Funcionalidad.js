
function btnIngresar_ClickJs() {
    if (document.getElementById("txtUsuario").value == "admin" & document.getElementById("txtClave").value == "admin") {
        alert("Bienvenido al sistema!");
    }
    else {
        alert("Usuario y/o clave incorrectos");
    }
}

