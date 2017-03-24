<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmCaptura.aspx.cs" Inherits="CM2017.Sistema.frmCaptura" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Menu ID="Menu1" runat="server" />
&nbsp;<h2>Captura para Evento</h2>

    <table class="table">
    <tr><td align="right">Nombre del Evento:</td><td>
        <asp:TextBox ID="TextBox1" runat="server" Width="450px" CssClass="form-control"></asp:TextBox></td></tr>
    <tr><td align="right">Fecha de Solicitud:</td>
        <td class="form-inline">

            <asp:TextBox ID="TextBox2" runat="server" Width="86px" CssClass="form-control"></asp:TextBox>
            Fecha del Evento:<asp:TextBox ID="TextBox3" runat="server" Width="170px" CssClass="form-control"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="..." Width="18px" />&nbsp;
            Fecha de Fin del Evento:<asp:TextBox ID="TextBox4" runat="server" Width="170px" CssClass="form-control"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="..." Width="18px" />

        </td></tr>
    <tr><td align="right">Tipo de Evento:</td><td><asp:DropDownList ID="ddlTipoEvento" runat="server" CssClass="form-control" Width="200px">
        </asp:DropDownList></td></tr>
    <tr><td align="right">Flujo de Autorización:</td><td>
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Value="0">Incluye a Ventas</asp:ListItem>
            <asp:ListItem Value="1">No incluye a Ventas</asp:ListItem>
        </asp:RadioButtonList></td></tr>
    <tr><td align="right">Gerente de Producto:</td><td><asp:DropDownList ID="ddlGteProd" runat="server" CssClass="form-control" Width="200px">
        </asp:DropDownList></td></tr>
    <tr><td align="right"><asp:Label ID="lblProducto" runat="server" Text="Producto:"></asp:Label></td>
        <td><asp:CheckBoxList ID="chkProducto" runat="server" RepeatColumns="7"></asp:CheckBoxList></td></tr>
    <tr><td align="right">Tipo de Audiencia:</td><td><asp:DropDownList ID="ddlAudiencia" runat="server" CssClass="form-control" Width="200px">
        </asp:DropDownList></td></tr>
    <tr><td align="right">Número de Invitados:</td><td>
        <asp:TextBox ID="TextBox5" runat="server" Width="19px" CssClass="form-control"></asp:TextBox></td></tr>
    <tr><td align="right">Objetivo del Evento:</td><td>
        <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></td></tr>
    <tr><td align="right">Locación:</td><td>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="form-control">
            <asp:ListItem Value="1">Local</asp:ListItem>
            <asp:ListItem Value="2">Nacional</asp:ListItem>
            <asp:ListItem Value="3">Internacional</asp:ListItem>
        </asp:RadioButtonList>
        <asp:DropDownList ID="ddlLocalizacion" runat="server" Visible="False" CssClass="form-control" Width="200px">
        </asp:DropDownList></td></tr>
    <tr><td align="right">Agenda:</td><td>
        <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></td></tr>
    <tr><td align="right">División:</td><td><asp:RadioButtonList runat="server" ID="rblDivision" RepeatDirection="Horizontal" CssClass="form-control"></asp:RadioButtonList></td></tr>
    <tr><td align="right">Area Terapeutica:</td><td><asp:RadioButtonList runat="server" ID="rblAT" RepeatDirection="Horizontal" CssClass="form-control"></asp:RadioButtonList></td></tr>
    <tr><td align="right">Team Leader:</td><td><asp:DropDownList ID="ddlTeamLeader" runat="server" CssClass="listado form-control" Width="200px">
        </asp:DropDownList></td></tr>
    <tr><td colspan="2" align="right">
        <asp:Button ID="Button4" runat="server" Text="Aceptar" OnClick="Button4_Click" CssClass="btn-primary" />&nbsp;</td></tr>
    </table>    
        <asp:Label runat="server" ID="lblMsg"></asp:Label>
</asp:Content>
