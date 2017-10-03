$(document).ready(function () {
    $('#ContentPlaceHolder1_TextBox1').focus();
    cargaDatePicker();

});

function cargaDatePicker() {
    var fechaInicio = new Date("Fri, 1 Jan 2016");
    var fechaFin = new Date();
    $("#ContentPlaceHolder1_TextBox2").datepicker({
        dateFormat: "dd/mm/yy",
        showOn: "button",
        buttonImage: "../Imagenes/boton_calendario.png",
        buttonImageOnly: true,
        firstDay: 1,
        onSelect: function () {
            $("#ContentPlaceHolder1_TextBox2").datepicker('option', 'minDate', this.value);
        }
    });
    $("#ContentPlaceHolder1_TextBox3").datepicker({
        dateFormat: "dd/mm/yy",
        showOn: "button",
        buttonImage: "../Imagenes/boton_calendario.png",
        buttonImageOnly: true,
        firstDay: 1,
        onSelect: function () {
            $("#ContentPlaceHolder1_TextBox3").datepicker('option', 'minDate', this.value);
        }
    });
    $("#ContentPlaceHolder1_TextBox4").datepicker({
        dateFormat: "dd/mm/yy",
        showOn: "button",
        buttonImage: "../Imagenes/boton_calendario.png",
        buttonImageOnly: true,
        firstDay: 1,
        onSelect: function () {
            $("#ContentPlaceHolder1_TextBox4").datepicker('option', 'minDate', this.value);
        }
    });
}

