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