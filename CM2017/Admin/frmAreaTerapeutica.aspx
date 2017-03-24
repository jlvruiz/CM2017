﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmAreaTerapeutica.aspx.cs" Inherits="CM2017.Admin.frmAreaTerapeutica" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <uc1:Menu ID="Menu1" runat="server" />
&nbsp;<h2>Area Terapéutica</h2>

    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdAT" RowStyle-Wrap="false" CssClass="table" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ButtonType="Link" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Act/Des" ButtonType="Link" />
                </Columns>
            </asp:GridView>
        </div>
        <div style="float:right">

            <table id="tblAgregar" runat="server" visible="false" class="table">
            <tr>
                <td style="width: 50px">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Nombre:"></asp:Label></td>
                <td colspan="3">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td style="width: 50px">
                </td>
            </tr>

            <tr>
                <td style="width: 50px">
                    <asp:Label ID="lblStatus" runat="server" Text="Activo:"></asp:Label></td>
                <td colspan="3">
                    <div class="checkbox-inline">
                    <asp:CheckBox ID="chkActivo" runat="server" /></div></td>
                <td style="width: 50px">
                </td>
            </tr>

            <tr><td colspan="5" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn-primary" /></td></tr>

            </table>

        </div>
    </div>


</asp:Content>
