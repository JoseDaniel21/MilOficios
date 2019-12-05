//#region ONLOAD
ListPage();
//#endregion

function ListPage() {
    $.ajax({
        type: "GET",
        url: "/Home/JListTecnico",
        dataType: 'json',
        beforeSend: function () {
            $("#contenedor_carga").css("visibility", "visible");
        }
    }).then(function (listado) {
        console.log(listado);
        $("#contenedor_carga").css("visibility", "hidden");
        TableOC(listado);
    });
}
//Table
function TableOC(listado) {
    $("#table tbody").empty();
    $.each(listado.listaServicio, function (key, listaServicio) {
        $("#table tbody").append(
            "<tr>" +
            "<td>" + key + "</td>" +
            "<td>" + listaServicio.nombre + "</td>" +
            "<td>" + listaServicio.fechaInicio + "</td>" +
            "<td>" + listaServicio.fechaFin + "</td>" +
            "<td>" + listaServicio.descripcion + "</td>" +
            "<td><i class='fa fa-plus-square icon-md text-warning' onclick='VerDetalle(" + JSON.stringify(listaServicio) + ")' style='cursor:pointer'></i></td>" +
            "</tr>"
        );
    });
};

function VerDetalle(listaServicio) {
    $("#detalle_Modal").modal("show");
    console.log(listaServicio.urlFoto);
    $("#imagen").attr("src", listaServicio.urlFoto);

}
$("#btnGuardar").click(function () {
    var cod = $("#id").val();
    var cos = 122.51;
    var cot = 365.36;
    var codUsu = $("#idUsuario").val();

    var obj = Object();
    obj.codServicio = cod;
    obj.costo = cos;
    obj.cotizacion = cot;
    obj.codUsuario = codUsu;

    $.ajax({
        type: "POST",
        url: "/Home/Solicitar",
        data: obj,
        success: function (data) {
            if (data.codResultado == 0)
                alert(data.desResultado)
            else
                //confirm("Se registró usuario!!")
                Sucess("Se registró Correctamente!!")
        }
    }).then(function () {
        $("#detalle_Modal").modal("hide");
        LimpiarCajas();
        Sucess("El servicio fue registrado correctamente!!");
    })
})