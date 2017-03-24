<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CM2017.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Administrador del Sistema</h2>
    <table>
        <tr><td align="right">Clave:</td><td><asp:TextBox ID="txtClave" runat="server"></asp:TextBox></td></tr>
        <tr><td align="right">Contraseña:</td><td><asp:TextBox ID="txtContra" runat="server"></asp:TextBox></td></tr>
        <tr><td colspan="2" align="center"><asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Entrar" /></td></tr>
        <tr><td colspan="2"><asp:Label ID="lblMensajes" runat="server"></asp:Label></td></tr>
    </table>

</asp:Content>
