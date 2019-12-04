//#region ONLOAD
ListPage();
//#endregion

function ListPage() {
    $.ajax({
        type: "GET",
        url: "/Home/JListMudanza",
        dataType : 'json',
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
    $("#imagen").attr("src",listaServicio.urlFoto);

}
