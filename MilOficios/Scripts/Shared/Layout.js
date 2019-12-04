//#region TOAST

var Toast = function (heading, text, transition, icon, stack, close, position, time) {
    $.toast({
        heading: heading,
        text: text,
        showHideTransition: transition,
        icon: icon,
        stack: stack,
        allowToastClose: close,
        position: position,
        hideAfter: time
    });
};
var Sucess = function (mensaje, time) {
    $.toast({
        heading: 'Exito',
        text: mensaje,
        showHideTransition: 'fade',
        icon: 'success',
        stack: false,
        allowToastClose: true,
        position: 'top-center',
        hideAfter: time
    });
}
var Warning = function (mensaje, time) {
    $.toast({
        heading: 'Aviso',
        text: mensaje,
        showHideTransition: 'fade',
        icon: 'warning',
        stack: false,
        allowToastClose: true,
        position: 'top-center',
        hideAfter: time
    });
}
var Info = function (mensaje, time) {
    $.toast({
        heading: 'Información',
        text: mensaje,
        showHideTransition: 'fade',
        icon: 'info',
        stack: false,
        allowToastClose: true,
        position: 'top-center',
        hideAfter: time
    });
}
var Err = function (mensaje, time) {
    $.toast({
        heading: 'Error',
        text: mensaje,
        showHideTransition: 'fade',
        icon: 'error',
        stack: false,
        allowToastClose: true,
        position: 'top-center',
        hideAfter: time
    });
}

//#endregion