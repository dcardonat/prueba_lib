/* Proporciona funcionalidades genéricas del lado del cliente. */

function ConfirmarAccion(titulo, mensaje, callback) {
    //// <summary>Genera un PopUp de confirmación de una acción.</summary>
    //// <param name="titulo">Título del PopUp.</param>
    //// <param name="mensaje">Mensaje de confirmación a visualizar.</param>
    //// <param name="callback">Función a ejecutr cuando se hace click en aceptar.</param>

    titulo = titulo || "Confirmar operación";

    var divModal = ModalPopUp(titulo, mensaje);
    var modal = $('.modal-content', divModal);
    var modalFooter = $('<div class="modal-footer centered"><button type="button" class="btn btn-link" data-dismiss="modal">Cancelar</button></div>');
    var btnAceptar = $('<button type="button" class="btn btn-primary" id="modal-confirm-btn-aceptar">Aceptar</button>').click(function () {

        $('#' + divModal.attr("id")).modal('hide');

        try {
            callback();
        }
        catch (e) { }

    });

    modalFooter.append(btnAceptar);
    modal.append(modalFooter);

    $(document.body).append(divModal);
    $('#' + divModal.attr("id")).modal('show');
    $(document.body).removeClass("modal-open");
}

function InformarAccion(titulo, mensaje, callback) {
    //// <summary>Genera un PopUp informativo tipo alert.</summary>
    //// <param name="titulo">Título del PopUp.</param>
    //// <param name="mensaje">Mensaje de información a visualizar.</param>
    //// <param name="callback">Opcional. Función a ejecutar cuando se cierra el PopUp.</param>

    titulo = titulo || "Mensaje del sistema";

    var divModal = ModalPopUp(titulo, mensaje);
    var modal = $('.modal-content', divModal);
    var modalFooter = $('<div class="modal-footer"></div>');
    var btnAceptar = $('<button type="button" class="btn btn-primary" id="modal-confirm-btn-aceptar">Aceptar</button>').click(function () {

        $('#' + divModal.attr("id")).modal('hide');

        try {
            callback();
        }
        catch (e) { }

    });

    modalFooter.prepend(btnAceptar);
    modal.append(modalFooter);

    $(document.body).append(divModal);
    $('#' + divModal.attr("id")).modal('show');
    $(document.body).removeClass("modal-open");
}

function ModalPopUp(titulo, mensaje) {
    //// <summary>No invocar éste función desde las vistas. Función que genera el PopUp de Confirmación o Información.</summary>

    var id = new Date().getTime();
    var divModal = $('<div id="' + id + '" class="modal fade bs-example-modal-md mensajes" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static"></div>')
                    .append('<div class="modal-dialog modal-md"><div class="modal-content"></div></div>');
    var modal = $('.modal-content', divModal);
    var modalHeader = $('<div class="modal-header"><button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Cerrar</span></button></div>')
                        .append('<h4 class="modal-title" id="mySmallModalLabel">' + titulo + '</h4>');
    var modalBody = $('<div class="modal-body">' + mensaje + '</div>');
    modal.append(modalHeader).append(modalBody);

    return divModal;
}

function CancelarAccion(textoConfirmacion, urlRedireccion) {
    /// <summary>Mensaje PopUp para cancelar la operación actual.</summary>
    /// <param name="textoConfirmacion">Mensaje de confirmación a visualizar.</param>
    /// <param name="urlRedireccion">Url a redireccionar.</param>

    ConfirmarAccion("Cancelar operación", textoConfirmacion, function () {
        window.location.href = urlRedireccion;
    });
}

function Eliminar(textoConfirmacion, urlRedireccion) {
    /// <summary>Mensaje PopUp para la confirmación de la operación actual.</summary>
    /// <param name="textoConfirmacion">Mensaje de confirmación a visualizar.</param>
    /// <param name="urlRedireccion">Url a redireccionar.</param>

    ConfirmarAccion("Eliminar", textoConfirmacion, function () {
        window.location.href = urlRedireccion;
    });
}

function EstablecerFocoPrimerControl() {
    /// <summary>Se aplica el foco al primer control activo del formulario.</summary>

    $(":input:enabled:visible:not([type='image']):not([readonly='readonly']):not([type='submit']):not([type='button']):first").focus();
}

function OcultarMensajesNegocio() {
    /// <summary>Oculta automáticamente los mensajes de negocio luego de transcurrir 5 segundos.</summary>

    //setTimeout(function () {
    //    $('#mensajeNegocio').alert('close');
    //}, 7500);
}

function VisualizarMensajeNegocio(tipoMensaje, mensaje, tiempoVisualizacion) {
    /// <summary>Genera un mensaje de negocio solo para llamados desde Javascript o Ajax.</summary>
    /// <param name="tipoMensaje">Tipo de mensaje a visualizar. 1. Mensaje de tipo éxito, 2. Mensaje de tipo advertencia, 3. Mensaje de tipo error.</param>
    /// <param name="mensaje">Mensaje a visualizar.</param>
    /// <param name="tiempoVisualizacion">Tiempo en milisegundos para visualizar el mensaje. Opcional. Por defecto son 5000 milisegundos.</param>

    var claseTipoMensaje;
    tiempoVisualizacion = tiempoVisualizacion || 7500;

    switch (tipoMensaje) {
        case 1:
            claseTipoMensaje = "success";
            break;
        case 2:
            claseTipoMensaje = "warning";
            break;
        case 3:
            claseTipoMensaje = "danger";
            break;
    }

    var mensajeHtml = "<div style=\"text-align: center !important\" class=\"alert alert-" + claseTipoMensaje + " alert-dismissible\" role=\"alert\">";
    mensajeHtml += "         <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">";
    mensajeHtml += "             <span aria-hidden=\"true\">&times;</span>";
    mensajeHtml += "         </button>";
    mensajeHtml += mensaje;
    mensajeHtml += "    </div>";
    
    $('#mensajeNegocio').html(mensajeHtml);

    setTimeout(function () {
        $('#mensajeNegocio').html('');
    }, tiempoVisualizacion);

    return mensajeHtml;
}

/// Variable para determinar el tiempo de verificacion de la descarga de un archivo de Excel.
var fileDownloadCheckTimer;
var nombreBoton;

function IniciarDescargaArchivo(idBotonExportarExcel) {
    /// <summary>Valida el estado de descarga de un archivo de Excel.</summary>
    /// <param name="idBotonExportarExcel">Boton a manipular durante la exportación a Excel.</param>

    $("#" + idBotonExportarExcel).attr('disabled', 'disabled');

    nombreBoton = $("#" + idBotonExportarExcel).text();
    $("#" + idBotonExportarExcel).text("Procesando archivo...");


    var token = $('[name="tokenExportarExcel"]').val();

    fileDownloadCheckTimer = window.setInterval(function () {

        var cookieValue = $.cookie('cookieExportarExcel');
        if (cookieValue == token) {
            DetenerDescargaArchivo(idBotonExportarExcel);
        }

    }, 1000);

}

function DetenerDescargaArchivo(idBotonExportarExcel) {
    /// <summary>Habilita el boton exportar a Excel una vez se finaliza la exportacion.</summary>
    /// <param name="idBotonExportarExcel">Boton a manipular durante la exportación a Excel.</param>

    window.clearInterval(fileDownloadCheckTimer);

    $("#" + idBotonExportarExcel).removeAttr('disabled');
    $("#" + idBotonExportarExcel).text(nombreBoton);
}

function RegistrarErrorConsola(mensajeError) {
    /// <summary>Registra un mensaje de error en log del explorador.</summary>
    /// <param name="mensajeError">Mensaje de error a registrar.</param>

    console.log(mensajeError);
}

$(function () {

    OcultarMensajesNegocio();
    EstablecerFocoPrimerControl();

    var opcionesSpin = {
        lines: 13, // The number of lines to draw
        length: 35, // The length of each line
        width: 14, // The line thickness
        radius: 38, // The radius of the inner circle
        scale: 0.5, // Scales overall size of the spinner
        corners: 1, // Corner roundness (0..1)
        color: '#000', // #rgb or #rrggbb or array of colors
        opacity: 0.4, // Opacity of the lines
        rotate: 25, // The rotation offset
        direction: 1, // 1: clockwise, -1: counterclockwise
        speed: 1, // Rounds per second
        trail: 60, // Afterglow percentage
        fps: 20, // Frames per second when using setTimeout() as a fallback for CSS
        zIndex: 2e9, // The z-index (defaults to 2000000000)
        className: 'spinner', // The CSS class to assign to the spinner
        top: '50%', // Top position relative to parent
        left: '50%', // Left position relative to parent
        shadow: false, // Whether to render a shadow
        hwaccel: true, // Whether to use hardware acceleration
        position: 'absolute' // Element positioning
    };

    var target = document.getElementById("loading");
    
    var submitAsincrono = function () {
        
        $("#loading").fadeIn('fast');
        var spinner = new Spinner(opcionesSpin).spin(target);

        var formulario = $(this);
        var opciones = {
            url: formulario.attr("action"),
            type: formulario.attr("method"),
            data: formulario.serialize()
        };

        $.ajax(opciones).done(function (data) {
            
            var destino = $(formulario.attr("data-otf-target"));
            destino.html(data);
            $("#loading").fadeOut('fast');
            spinner.stop();
        });
        
        return false;
    };

    var obtenerPagina = function () {

        $("#loading").fadeIn('fast');
        var spinner = new Spinner(opcionesSpin).spin(target);

        var a = $(this);

        var opciones = {
            url: a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(opciones).done(function (data) {
            var destino = a.parents("div.paginacion").attr("data-otf-target");
            $(destino).replaceWith(data);
            $("#loading").fadeOut('fast');
            spinner.stop();
        });

        return false;
    };

    $("form[data-otf-ajax='true']").submit(submitAsincrono);
    $(".content-container").on("click", ".paginacion a", obtenerPagina)

});