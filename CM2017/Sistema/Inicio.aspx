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
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br /><br />
    <asp:GridView ID="GridView2" runat="server" CssClass="mydatagrid" HeaderStyle-CssClass="header" Caption="Detalle de Evento Seleccionado"></asp:GridView>
</asp:Content>
