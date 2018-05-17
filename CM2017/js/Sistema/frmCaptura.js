$(document).ready(function () {
    $('#ContentPlaceHolder1_TextBox1').focus();
    
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestLocal);
    cargaDatePicker();

});

function EndRequestLocal(sender, args) {
    cargaDatePicker();
}


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


function muestraoculta() {
    var $radBtn = $("table.tbl input:radio");
    var $radChecked = $(':radio:checked');
    $('#divLocalizacion').css('display', 'block');
    $("#ddlLocalizacion").html('');
    $("#ddlLocalizacion").append("<option value='0'>Seleccione...</option>");
    if ($radChecked.val() == "1") {
        $("#ddlLocalizacion").append("<option value='200'>Hotel Balmis</option>");
    }
    else if ($radChecked.val() == "2") {
        $("#ddlLocalizacion").append("<option value='500'>Acapulco</option>");
    }
    else if ($radChecked.val() == "3") {
        $("#ddlLocalizacion").append("<option value='600'>Canada</option>");
        $("#ddlLocalizacion").append("<option value='601'>Atlanta</option>");
        $("#ddlLocalizacion").append("<option value='602'>Nueva york</option>");
    }

}
