<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmGerenteProducto.aspx.cs" Inherits="CM2017.Admin.frmGerenteProducto" ErrorPage="~/Error.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2><%= objGerentes._title %></h2>
    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdGerente" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" 
                RowStyle-Wrap="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" 
                OnRowCreated="GridView1_RowCreated" 
                OnRowDataBound="GridView1_RowDataBound" 
                OnRowCommand="GridView1_RowCommand" 
                OnPageIndexChanging="GridView1_PageIndexChanging" 
                OnRowDeleting="GridView1_RowDeleting">
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

            <div style="background-color: white; width: 15%; height:35%; position: relative; top: 10%; margin: auto">
            
                <div style="background-color: #161665; color: white; width: 100%; height: 30px;">
                    <span style="float:left; line-height: 30px; padding-left: 3px"><asp:Label ID="lblTitulo" runat="server" Text="Detalle de Evento Seleccionado" ForeColor="White" Font-Bold="true"></asp:Label></span>
                    <span style="float:right"><a href="#" onclick="javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();"><img src="../Imagenes/boton_cancelar.png" /></a></span>
                </div>

                <div style="padding: 15px">

                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr><td colspan="2">&nbsp;</td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr><td colspan="2">&nbsp;</td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblStatus" runat="server" Text="Activo:"></asp:Label></td>
                            <td>
                                <asp:CheckBox ID="chkActivo" runat="server" /></td>
                        </tr>
                        <tr><td colspan="2">&nbsp;</td></tr>
                        <tr><td colspan="2" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btnAbajo3" OnClick="btnAceptar_Click" /></td></tr>

                    </table>

                </div>

            </div>
        </div>




    </div>

</asp:Content>
