<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEventosTerminados.aspx.cs" Inherits="CM2017.Admin.frmEventosTerminados" MasterPageFile="~/CM.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%= eventosdesactivados._title %></h2>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageIndex="10" DataKeyNames="Id" 
            CssClass="mydatagrid" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow">
            <Columns>

            </Columns>
        </asp:GridView>
        <br /><br />

    



</asp:Content>