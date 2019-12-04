//#region VARIABLES GLOBALES
var idCategoria = 0;
//#endregion

$("#btnAgregarServicio").click(function () {
    $("#nuevoServicio_Modal").modal("show");
})

$("#btnGuardar").click(function () {
    var cod = $("#id").val();
    var des = $("#txtDescripcion").val();
    var fec =$("#txtFecha").val();
    var cate =$("#categoria").val();
    var ubi =$("#ubicacion").val();
    var latitud;
    var longitud;
    if (ubi == 1)
    {
        latitud = -12.046490;
        longitud = -77.032130;
    } else if (ubi == 2) {
        latitud = -8.107150;
        longitud = -79.027470;    
    } else if (ubi == 3) {
        latitud = -9.526110;
        longitud = -77.528750;
    }
    else if (ubi == 4) {
        latitud = -10.067352;
        longitud = -78.152757;
    }

    var obj = Object();
    obj.CodUsuario = cod;
    obj.Descripcion = des;
    obj.FechaFin = fec;
    obj.CodCategoria = cate;
    obj.codLocalizacion = ubi;
    obj.latitud = latitud;
    obj.longitud = longitud;

    $.ajax({
        type: "POST",
        url: "/Home/Register",
        data: obj,
        success: function (data) {
            if (data.codResultado == 0)
                alert(data.desResultado)
            //else
                //confirm("El servicio fue registrado correctamente!!")
                
        }
    }).then(function () {
        $("#nuevoServicio_Modal").modal("hide");
        LimpiarCajas();
        Sucess("El servicio fue registrado correctamente!!");
    })
})

function LimpiarCajas() {
    $("#id").val("");
    $("#txtDescripcion").val("");
    $("#txtFecha").val("");
    $("#categoria").val("");
    $("#ubicacion").val(""); 
}

//#region CARDS
$("#cardMudanzas").click(function () {
    location.href = "/Home/ListMudanza";    
})

$("#cardMudanzas").click(function () {
    location.href("Home/ListServicio");
})
$("#cardMudanzas").click(function () {
    location.href("Home/ListServicio");
})
$("#cardMudanzas").click(function () {
    location.href("Home/ListServicio");
})
$("#cardMudanzas").click(function () {
    location.href("Home/ListServicio");
})
//#endregion
