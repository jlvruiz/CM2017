<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEstadisticas.aspx.cs" Inherits="CM2017.Sistema.frmEstadisticas" MasterPageFile="~/CM.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/jquery.circliful.css" rel="stylesheet" />
    <link href="../Estilos/material-design-iconic-font.css" rel="stylesheet" />
    <link href="../Estilos/material-design-iconic-font.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%= objEstadisticas._title %></h2>
    <br />

    <div class="row">
        <div class="col-lg-2">
            <h3>Terminados</h3>
            <div id="test-circle1" data-percent="<%= terminados %>"></div>
        </div>
        <div class="col-lg-2">
            <h3>Desactivados</h3>
            <div id="test-circle2" data-percent="<%= desactivados %>"></div>
        </div>
        <div class="col-lg-2">
            <h3>Activos</h3>
            <div id="test-circle3" data-percent="<%= activos %>"></div>
        </div>

    </div>

    <script src="../js/jquery.circliful.js"></script>
    <script>
        $( document ).ready(function() {
            $("#test-circle1").circliful({
                animation: 1,
                animationStep: 5,
                foregroundBorderWidth: 15,
                backgroundBorderWidth: 15,
                percent: 38,
                textSize: 28,
                textStyle: 'font-size: 12px;',
                textColor: '#666',
                noPercentageSign: true,
            });
            $("#test-circle2").circliful({
                animation: 1,
                animationStep: 5,
                foregroundBorderWidth: 15,
                backgroundBorderWidth: 15,
                percent: 38,
                textSize: 28,
                textStyle: 'font-size: 12px;',
                textColor: '#666',
                foregroundColor: '#ff0000',
                noPercentageSign: true,
            });
            $("#test-circle3").circliful({
                animation: 1,
                animationStep: 5,
                foregroundBorderWidth: 15,
                backgroundBorderWidth: 15,
                percent: 38,
                textSize: 28,
                textStyle: 'font-size: 12px;',
                textColor: '#666',
                foregroundColor: '#49ff00',
                noPercentageSign: true,
            });
       });
    </script>

</asp:Content>