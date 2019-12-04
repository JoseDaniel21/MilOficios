$("#btnFacebook").click(function () {
    location.href = "/Usuario/Facebook";
})

$("#btnIniciarSesion").click(function () {
    $("#pills-iniciar-tab").trigger("click");
    $(this).attr("class", "btn btn-dark btn-block");
    $("#btnRegistrarme").attr("class", "btn btn-outline-dark btn-block");
});

$("#btnRegistrarme").click(function () {
    $("#pills-registrar-tab").trigger("click");
    $(this).attr("class", "btn btn-dark btn-block");
    $("#btnIniciarSesion").attr("class", "btn btn-outline-dark btn-block");
    ListarRol();
});

//AQUI INTENTE USAR EL SERVICIO USANDO JQUERY :'v 

function ListarRol() {
    $.ajax({
        type: "GET",
        //dataType: "JSON",
        url: "/Usuario/Listado",
        dataType: 'json',
        success: function (data) {
            console.log(data);
            $.each(data.listaRol, function (key, rol) {
                $("#idRol").append(`<option data-item=${key} value='${rol.codRol}' >${rol.nomRol}</option`);
        })
        }        
    });
    // .then(function (roles) {
    //    $.each(roles, function (key, rol) {
    //        $("#idRol").append("<option value='" + rol.codRol + "'>" + rol.nomRol + "</option");
    //    })
    //})
}

$("#btnRegistrar").on("click", function () {
    x = new Object();
    x.Nombres = $("#nombres").val();
    x.Correo = $("#correo").val();
    x.Contrasena = $("#constrasenia").val();
    x.TipoUsuario = $("#idRol").val();
    //x.Localizacion = $("#nombres").val();
    x.telefono = $("#celular").val();

    $.ajax({
        type: "POST",   
        url: "/Usuario/Register",
        data: x,
        success: function (data) {
            if (data.codResultado == 0)
                //alert(data.desResultado)
                Sucess(data.desResultado)
            else
                //confirm("Se registró usuario!!")
                Sucess("Se registró usuario!!")
        }
    });
    limpiarCajas();
   
    $("#pills-iniciar-tab").trigger("click");
    $(this).attr("class", "btn btn-dark btn-block");
    $("#btnRegistrarme").attr("class", "btn btn-outline-dark btn-block");    
})

function limpiarCajas() {
    $("#nombres").val("");
    $("#correo").val("");
    $("#constrasenia").val("");
    $("#idRol").val("");
    //$("#nombres").empty();
    $("#celular").val("");
}

$("#btnIngresar").click(function () {
    
    x = new Object();
    x.Correo = $("#usuarioLogin").val();
    x.Contrasena = $("#contraseniaLogin").val();
    $.ajax({
        type: "POST",
        url: "/Usuario/Autenticacion",
        data: x,        
        success: function (data) {
            if (data.codResultado == 0)
                alert(data.desResultado)
            else {
                Sucess(data.desResultado);
                setTimeout(function () {
                    location.href = "/Usuario/Index";  
                }, 3000)
            }                                                             
        }
    });
});

//URL PRINCIPAL DEL SERVICIO http://miloficios.somee.com/