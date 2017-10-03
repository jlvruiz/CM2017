<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CM2017.Sistema.Inicio" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Menu ID="Menu1" runat="server" />
    &nbsp;<h2>Eventos Disponibles</h2>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageIndex="10" DataKeyNames="Id" 
            CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
            OnPageIndexChanging="GridView1_PageIndexChanging" 
            OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table style="border: none">
                            <tr style="border: none">
                                <td style="border: none">
                                    <asp:LinkButton ID="LigaEditar" runat="server" CommandName="Select" Text="Editar" OnClick="LigaEditar_Click"></asp:LinkButton>
                                </td>
                                <td style="border: none">
                                    <asp:LinkButton ID="LigaDetalle" runat="server" CommandName="Select" Text="Detalle" OnClick="LigaDetalle_Click"></asp:LinkButton>
                                </td>
                                <td style="border: none">
                                    <asp:ImageButton ID="btnImagen" runat="server" OnClientClick="" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />

        <div id="divEncima" style="position: fixed; z-index: 151; top: 0; width: 100%; height: 100%; display: none">

        <div style="background-color: white; width: 820px; height:35%; position: relative; top: 10%; left:15%; border:1px solid orange;">

            <div style="background-color: #161665; color: white; width: 100%; height: 30px;">
                <span style="float:left; line-height: 30px; padding-left: 3px"><asp:Label ID="lblTituloPopUp" runat="server" Text="Detalle de Evento Seleccionado" ForeColor="White" Font-Bold="true"></asp:Label></span>
                <span style="float:right"><a href="#" onclick="javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();"><img src="../Imagenes/boton_cancelar.png" /></a></span>
            </div>

            <br /><br />

                <div style="max-height: 170px; width: 100%; padding-left: 4px; padding-right: 4px; overflow-y: auto; overflow-x: scroll;">
                    <asp:GridView ID="GridView2" runat="server" CssClass="mydatagrid" HeaderStyle-CssClass="header"></asp:GridView>
                </div>
            <center><asp:Button id="btnCerrar" runat="server" Text="Cerrar" CssClass="btn btn-warning" /></center>
        </div>
        </div>



</asp:Content>
