function BuscarID() {
    let Cedula = $("#Cedula").val();
    let url = "https://apis.gometa.org/cedulas/" + Cedula;

    fetch(url)
        .then(response => response.json())
        .then(data => mostrarData(data))
        .catch(error => console.log(error))

    let mostrarData = (data) => {
        console.log(data)
        let nombre = data.nombre
        let edad = data.edad


        if (nombre == null)
        {
            Swal.fire({
                title: "Upss...",
                text: "No se encontró a nadie con esta identificación",
                icon: 'error',
            });
            $("#Identificacion").val("");
            $("#Nombre").val("");
        }
        else
        {
            let inputNombre = document.getElementById('Nombre');
            inputNombre.value = nombre
        }
    }
}