/* Proporciona reglas de validación personalizadas sobre el modelo. */

// -------------  Validación de horas en formato AM/PM del lado del cliente. -------------
$.validator.unobtrusive.adapters.add('timeampmvalidation', ['timeampmpattern'],
        function (options) {

            options.rules['timeampmvalidation'] = options.params;

            if (options.message != null) {
                $.validator.messages.timeampmvalidation = options.message;
            }

        }
    );

$.validator.addMethod('timeampmvalidation', function (value, element, params) {

    var pattern = new RegExp(params.timeampmpattern);

    if (!(this.optional(element) || pattern.test(value))) {
        var message = $(element).attr('data-val-timeampmvalidation');
        $.validator.messages.timeampmvalidation = message;
        return false;
    }

    return true;
}, '');


// -------------  Validación del correo electrónico del lado del cliente. -------------
$.validator.unobtrusive.adapters.add('correoelectronicovalidation', ['correoelectronicopattern'],
        function (options) {

            options.rules['correoelectronicovalidation'] = options.params;

            if (options.message != null) {
                $.validator.messages.correoelectronicovalidation = options.message;
            }

        }
    );

$.validator.addMethod('correoelectronicovalidation', function (value, element, params) {

    var pattern = new RegExp(params.correoelectronicopattern);

    if (!(this.optional(element) || pattern.test(value))) {
        var message = $(element).attr('data-val-correoelectronicovalidation');
        $.validator.messages.correoelectronicovalidation = message;
        return false;
    }

    return true;
}, '');


// -------------  Validación de mayoría de edad. -------------
$.validator.unobtrusive.adapters.add('mayoriaedadvalidation', ['mayoriaedadpattern'],
        function (options) {

            options.rules['mayoriaedadvalidation'] = options.params;

            if (options.message != null) {
                $.validator.messages.mayoriaedadvalidation = options.message;
            }

        }
    );

$.validator.addMethod('mayoriaedadvalidation', function (value, element, params) {

    var fechaFraccionada = value.split('/');

    var fechaActual = new Date();
    var fechaNacimiento = new Date(fechaFraccionada[2], fechaFraccionada[1] - 1, fechaFraccionada[0]);
    var edad = fechaActual.getFullYear() - fechaNacimiento.getFullYear();
    var mesNacimiento = fechaActual.getMonth() - fechaNacimiento.getMonth();

    if (mesNacimiento < 0 || (mesNacimiento === 0 && fechaActual.getDate() < fechaNacimiento.getDate())) {
        edad--;
    }

    if (!(this.optional(element) || parseInt(edad) >= parseInt(params.mayoriaedadpattern))) {
        var message = $(element).attr('data-val-mayoriaedadvalidation');
        $.validator.messages.mayoriaedadvalidation = message;
        return false;
    }

    return true;

}, '');