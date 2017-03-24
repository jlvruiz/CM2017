<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmTeamLeader.aspx.cs" Inherits="CM2017.Admin.frmTeamLeader" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Menu ID="Menu1" runat="server" />
&nbsp;<h2>Gerentes Team Leader</h2>
    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdTL" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" RowStyle-Wrap="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ButtonType="Link" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Act/Des" ButtonType="Link" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Activo" HeaderText="Activo" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="float:right">

            <table id="tblAgregar" runat="server" visible="false">
            <tr>
                <td style="width: 50px">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                <td style="width: 50px">
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox></td>
                <td style="width: 50px">
                </td>
            </tr>
            <tr>
                <td style="width: 50px">
                    <asp:Label ID="lblStatus" runat="server" Text="Activo:"></asp:Label></td>
                <td colspan="3">
                    <asp:CheckBox ID="chkActivo" runat="server" /></td>
                <td style="width: 50px">
                </td>
            </tr>

            <tr><td colspan="5" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" /></td></tr>

            </table>

        </div>
    </div>


</asp:Content>
