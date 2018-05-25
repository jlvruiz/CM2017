<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CM2017.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        //$(document).ready(function(){
        //    alert('Success');
        //});
    </script>


    <div class="container" style="margin-top: 10%">



        <div class="row">
            <div class="col-sm-3 col-sm-offset-4 col-md-3 col-md-offset-4 col-lg-3  col-lg-offset-4">

                <div class="panel panel-primary">
                    <div class="panel-heading text-center">Administración del Sistema</div>
                    <div class="panel-body">

                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="row">

                                <asp:Label ID="lblClave" runat="server" CssClass="text-info">Clave:</asp:Label><asp:TextBox ID="txtClave" runat="server" CssClass="form-control col-md-4"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="row">
                                                            
                                <asp:Label ID="lblContra" runat="server" CssClass="text-info">Contraseña:</asp:Label><asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control col-md-4"></asp:TextBox>
                                                            
                            </div>
                        </div>
                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="row text-center">
                                                            
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click1" />

                            </div>
                        </div>

                        <div class="form-group col-sm-12 col-md-12 col-lg-12">
                            <div class="row text-left">
                            </div>
                        </div>                                                            

                    </div>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
