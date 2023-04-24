$(document).on("click", ".openModal", function () {
    var idAdopcion = $(this).data('idadopcion');
    $("#idModalHidden").val(idAdopcion);
});

function AceptarAdopcion() {

    let idAdopcion = $("#idModalHidden").val();
    let id = 1;

    $.ajax({
        type: "POST",
        url: "/Home/CambiarEstadoAdopcion",
        dataType: "json",
        data: {
            "idAdopcion": idAdopcion,
            "id": id
        },
        success: function (res) {

            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: '¡La donacion ha sido aceptada satisfactoriamente!',
                showConfirmButton: false,
                willClose: function () {
                    RecargarPantalla();
                },
            });

        }
    });
}


$(document).on("click", ".openModal2", function () {
    var idAdopcion = $(this).data('idadopcion');
    $("#idModalHidden2").val(idAdopcion);
});


function DenegarDonacion() {

    let idAdopcion = $("#idModalHidden2").val();
    let id = 2;

    $.ajax({
        type: "POST",
        url: "/Home/CambiarEstadoAdopcion",
        dataType: "json",
        data: {
            "idAdopcion": idAdopcion,
            "id": id
        },
        success: function (res) {

            Swal.fire({
                position: 'top-center',
                icon: 'success',
                title: '¡La donacion ha sido denegada satisfactoriamente!',
                showConfirmButton: false,
                willClose: function () {
                    RecargarPantalla();
                },
            });

        }
    });
}


function RecargarPantalla() {
        window.location.href = "/Home/SolicitudesAdopcion";
}


