<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmProductos.aspx.cs" Inherits="CM2017.Admin.frmProductos" %>
<%@ Register src="../Utilerias/Menu.ascx" tagname="Menu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <uc1:Menu ID="Menu1" runat="server" />
&nbsp;<h2>Productos</h2>

    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageIndex="10" DataKeyNames="IdProducto, Visible" 
                RowStyle-Wrap="false" CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow"  
                OnRowDataBound="GridView1_RowDataBound" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table style="border: none">
                                <tr style="border: none">
                                    <td style="border: none">
                                        <asp:LinkButton ID="LigaEditar" runat="server" CommandName="Select" Text="Editar" OnClick="LigaEditar_Click"></asp:LinkButton>
                                    </td>
                                    <td style="border: none">
                                        <asp:LinkButton ID="LigaBorrar" runat="server" CommandName="Delete" Text="Eliminar" OnClick="LigaBorrar_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="float:right">

            <table id="tblAgregar" runat="server" visible="false">
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
                    <asp:Label ID="lblStatus" runat="server" Text="Activo:" CssClass="checkbox-inline"></asp:Label></td>
                <td colspan="3">
                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="checkbox-inline" /></td>
                <td style="width: 50px">
                </td>
            </tr>

            <tr><td colspan="5" align="center"><asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" /></td></tr>

            </table>

        </div>
    </div>


</asp:Content>
