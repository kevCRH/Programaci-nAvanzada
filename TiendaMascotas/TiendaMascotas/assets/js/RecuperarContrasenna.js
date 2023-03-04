function RecuperarContrasenna() {

    $("#btnEnviar").prop("disabled", true);
    let validar = $("#CorreoElectronico").val();

    $.ajax({
        type: "POST",
        url: "/Home/ValidarRegistrar",
        dataType: "json",
        data: {
            "validar": validar
        },
        success: function (res) {
                if (res != "ERROR") {
                    if (res != "") {
                        $("#btnEnviar").prop("disabled", false);
                    }
                    else {
                        alert("No hay registro de este nombre de usuario");
                    }
                }
            }
    });
}