<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmEventosDesactivados.aspx.cs" Inherits="CM2017.Admin.frmEventosDesactivados" ErrorPage="~/Error.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%= eventosdesactivados._title %></h2>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageIndex="10" DataKeyNames="Id" 
            CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table style="border: none">
                            <tr style="border: none">
                                <td style="border: none">
                                    <asp:LinkButton ID="LigaActivar" runat="server" CommandName="Select" Text="Activar" OnClick="LigaActivar_Click"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br /><br />

    



</asp:Content>