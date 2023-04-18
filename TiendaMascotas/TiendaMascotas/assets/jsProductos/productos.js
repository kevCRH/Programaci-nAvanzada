$(document).on("click", ".openModal", function () {
    var id = $(this).data('id');
    $("#idModalHidden").val(id);
});

function EliminarProducto() {
    let id = $("#idModalHidden").val();

    $.ajax({
        type: "POST",
        url: "/Productos/EliminarProducto",
        dataType: "json",
        data: {
            "id": id
        },
        success: function (res) {
            window.location.href = "/Productos/ProductosVenta";
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("Error eliminando el producto:", errorThrown);
        }
    });
}


