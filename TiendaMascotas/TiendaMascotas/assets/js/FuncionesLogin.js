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
                    alert(res);
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
            alert("Las contraseñas no coinciden");
        }
    }
}