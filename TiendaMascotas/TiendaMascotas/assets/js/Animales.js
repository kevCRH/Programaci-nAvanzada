$(document).on("click", ".openModal", function () {
    var id = $(this).data('id');
    $("#idModalHidden").val(id);
});

function CambiarEstadoAnimal() {

    let id = $("#idModalHidden").val();

    $.ajax({
        type: "POST",
        url: "/Perros/CambiarEstado",
        dataType: "json",
        data: {
            "id": id
        },
        success: function (res) {
            window.location.href = "/Perros/AdopcionPerros"
        }
    });
}

function CambiarEstadoAnimal2() {

    let id = $("#idModalHidden").val();

    $.ajax({
        type: "POST",
        url: "/Gatos/CambiarEstado",
        dataType: "json",
        data: {
            "id": id
        },
        success: function (res) {
            window.location.href = "/Gatos/AdopcionGatos"
        }
    });
}

$(document).on("click", "#btnSolicitudAdopcion", function () {
    var idAnimal = $(this).data('idanimal');
    var cedula = $(this).data('cedula');
    SolicitudAdopcion(idAnimal, cedula);
});

function SolicitudAdopcion(IdAnimal, Cedula) {

    $.ajax({
        type: "POST",
        url: "/Perros/SolicitarAdopcion",
        dataType: "json",
        data: {
            "IdAnimal": IdAnimal,
            "Cedula": Cedula
        },
        success: function (res) {

            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: '¡Su solicitud de adopción, ha sido enviada!',
                //body: Se le enviara un correo si su adopcion ha sido aceptada.
                showConfirmButton: false,
                timer: 25000,
                //onClose: RecargarPantalla()
            });
            //window.location.href = "/Home/IniciarSesion";
        }
    });

}



