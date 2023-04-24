function ValidarRegistrar() {

    $("#btRegistrarse").prop("disabled", true);
    let validar = $("#CorreoElectronico").val();

    $.ajax({
        type: "POST",
        url: "/Home/ValidarRegistrar",
        dataType: "json",
        data: {
            "validar": validar
        },
        success: function (res)
        {
            if (res != "ERROR")
            {
                if (res == "") {
                    $("#btRegistrarse").prop("disabled", false);
                }
                else {
                    $("#CorreoElectronico").val("");
                    Swal.fire({
                        title: "Uups...",
                        text: "Este correo ya está registrado",
                        icon: 'error',
                        //*************VER POSIBILIDAD DE AGREGAR UNA IMAGEN*************/
                        //imageUrl: 'View/images/coche.png',
                        //imageWidth:'150px',
                        //imageAlt: 'Foto coche'
                    });
                }
            }
        }
    });
}


function ValidarCedula() {

    $("#btRegistrarse").prop("disabled", true);
    let validar = $("#Cedula").val();

    $.ajax({
        type: "POST",
        url: "/Home/ValidarCedula",
        dataType: "json",
        data: {
            "validar": validar
        },
        success: function (res) {
            if (res != "ERROR") {
                if (res == "") {
                    $("#btRegistrarse").prop("disabled", false);
                }
                else {
                    $("#Cedula").val("");
                    $("#Nombre").val("");
                    Swal.fire({
                        title: "Upss...",
                        text: res,
                        icon: 'error',
                    });
                }
            }
        }
    });
}


function ValidarContrasenna() {
    let contrasenna = $("#Contrasenna").val();
    let confirmarContrasenna = $("#ConfirmarContrasenna").val();

    if (contrasenna.trim() != "" && confirmarContrasenna.trim()) {
        if (contrasenna.trim() != confirmarContrasenna.trim()) {
            $("#ConfirmarContrasenna").val("");
            Swal.fire({
                title: "Upss...",
                text: "Las contraseñas no coinciden",
                icon: 'error',
            });
        }
    }
}