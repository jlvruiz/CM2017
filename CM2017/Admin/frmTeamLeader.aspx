<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmTeamLeader.aspx.cs" Inherits="CM2017.Admin.frmTeamLeader" ErrorPage="~/Error.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2><%= objGerenteTL._title %></h2>

    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdTL" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" 
                RowStyle-Wrap="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" 
                OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" 
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ButtonType="Link" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Act/Des" ButtonType="Link" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                </Columns>
            </asp:GridView>
        </div>

        <div id="divEncima" style="position: fixed; z-index: 151; top: 0; width: 100%; height: 100%; display: none">

            <div style="background-color: white; width: 25%; height:34%; position: relative; top: 15%; left: 30%; border:1px solid orange;">
            
                <div style="background-color: #161665; color: white; width: 100%; height: 30px;">
                    <span style="float:left; line-height: 30px; padding-left: 3px"><asp:Label ID="lblTitulo" runat="server" Text="Detalle de Evento Seleccionado" ForeColor="White" Font-Bold="true"></asp:Label></span>
                    <span style="float:right"><a href="#" onclick="javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();"><img src="../Imagenes/boton_cancelar.png" /></a></span>
                </div>

                <table align="center">
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td style="width: 50px">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td style="width: 50px">
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td style="width: 50px">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox></td>
                        <td style="width: 50px">

                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td style="width: 50px">
                            <asp:Label ID="lblStatus" runat="server" Text="Activo:"></asp:Label></td>
                        <td colspan="3">
                            <asp:CheckBox ID="chkActivo" runat="server" /></td>
                        <td style="width: 50px">
                        </td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr><td colspan="5" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btnAbajo3" OnClick="btnAceptar_Click" /></td></tr>

                </table>
            </div>
        </div>





    </div>


</asp:Content>
