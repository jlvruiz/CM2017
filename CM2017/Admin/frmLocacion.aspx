<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmLocacion.aspx.cs" Inherits="CM2017.Admin.frmLocacion" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Menu ID="Menu1" runat="server" />
&nbsp;<h2>Control de Localización</h2>
    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdLoc" RowStyle-Wrap="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ButtonType="Link" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Act/Des" ButtonType="Link" />
                </Columns>
            </asp:GridView>
        </div>


        <div id="divEncima" style="position: fixed; z-index: 151; top: 0; width: 100%; height: 100%; display: none">

                <div style="background-color: white; width: 25%; height:34%; position: relative; top: 15%; left: 30%; border:1px solid orange;">
            
                    <div style="background-color: #161665; color: white; width: 100%; height: 30px;">
                        <span style="float:left; line-height: 30px; padding-left: 3px"><asp:Label ID="lblTitulo" runat="server" Text="Detalle de Evento Seleccionado" ForeColor="White" Font-Bold="true"></asp:Label></span>
                        <span style="float:right"><a href="#" onclick="javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();"><img src="../Imagenes/boton_cancelar.png" /></a></span>
                    </div>

                    <div style="padding:15px;">

                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label></td>
                                <td>
                                <asp:RadioButtonList ID="rblTipo" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Value="1">Local</asp:ListItem>
                                    <asp:ListItem Value="2">Nacional</asp:ListItem>
                                    <asp:ListItem Value="3">Internacional</asp:ListItem>
                                </asp:RadioButtonList>    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text="Activo:"></asp:Label></td>
                                <td>
                                    <asp:CheckBox ID="chkActivo" runat="server" /></td>
                            </tr>
                            <tr><td colspan="2" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" /></td></tr>

                        </table>

                    </div>

                </div>

            </div>
        </div>




    </div>

</asp:Content>

