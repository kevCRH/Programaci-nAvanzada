function ValidarRegistrar() {

    $("#btRegistrarse").prop("disabled",true);
    let validar = $("#NombreUsuario").val();

    $.ajax({
        type: "POST",
        url: "/Home/ValidarRegistrar",
        dataType: "json",
        data: {
            "validar": validar
        },
        success: function (res)
        {
            if (res == "") {
                $("#btRegistrarse").prop("disabled", false);
            }
            else
            {
                alert(res);
                $("#NombreUsuario").val("");
                $("#NombreUsuario").focus();
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