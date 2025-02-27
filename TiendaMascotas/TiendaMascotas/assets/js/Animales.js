﻿$(document).on("click", ".openModal", function () {
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
            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: '¡El cambio de estado ha sido efectuado!',
                showConfirmButton: false
            }).then(function () {
                window.location.href = "/Perros/AdopcionPerros";
            });
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

$(document).on("click", ".openModal2", function () {
    var idAnimal = $(this).data('idanimal');
    var cedula = $(this).data('cedula');
    var tipoanimal = $(this).data('idtanimal');
    $("#idModalHidden2").val(idAnimal);
    $("#idModalHidden3").val(cedula);
    $("#idModalHidden4").val(tipoanimal);
});

function SolicitudAdopcion() {

    let IdAnimal = $("#idModalHidden2").val();
    let Cedula = $("#idModalHidden3").val();

    $.ajax({
        type: "POST",
        url: "/Home/SolicitarAdopcion",
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
                showConfirmButton: false,
                willClose: function () {
                    RecargarPantalla();
                    },
            });
            
        }
    });

    function RecargarPantalla()
    {
        let tipoAnimal = $("#idModalHidden4").val();

        if (tipoAnimal == "perro")
        {
            window.location.href = "/Perros/AdopcionPerros";
        }
        else {
            window.location.href = "/Gatos/AdopcionGatos";
        }
    }

}



