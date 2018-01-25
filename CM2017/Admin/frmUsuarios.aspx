<%@ Page Title="" Language="C#" MasterPageFile="~/CM.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="CM2017.Admin.frmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><%= objUsuarios._title %></h2>
    <script src="../js/Admin/frmUsuarios.js"></script>

    <h4><asp:LinkButton ID="lnbAgregar" runat="server" Text="Agregar Nuevo" OnClick="lnbAgregar_Click"></asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton ID="lnkBuscar" runat="server" Text="Buscar" OnClick="lnkBuscar_Click"></asp:LinkButton></h4>
    <div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="IdResCM" RowStyle-Wrap="false" AutoGenerateColumns="false" 
                CssClass="mydatagrid table-hover" HeaderStyle-CssClass="header" SelectedRowStyle-CssClass="selectedrow" 
                OnRowCreated="GridView1_RowCreated" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" 
                OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" SelectText="Editar" ButtonType="Link" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Act/Des" ButtonType="Link" />
                    <asp:ButtonField CommandName="Add" Text="Seleccion" ButtonType="Link" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button runat="server" ID="IncreaseButton"
                            Text="Increase Price 5%"
                            CommandName="Increase"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn btn-default btn-sm"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Activo" HeaderText="Estatus" />
                    <asp:BoundField DataField="Clave" HeaderText="Clave" />
                    <asp:BoundField DataField="Contra" HeaderText="Contraseña" />
                </Columns>
            </asp:GridView>
        </div>

        
        <div id="divEncima" style="position: fixed; z-index: 151; top: 0; width: 100%; height: 100%; display: none">

            <div style="background-color: white; width: 25%; height:52%; position: relative; top: 15%; left: 30%; border:1px solid orange;">
            
            <div style="background-color: #161665; color: white; width: 100%; height: 30px;">
                <span style="float:left; line-height: 30px; padding-left: 3px"><asp:Label ID="lblTitulo" runat="server" Text="Detalle de Evento Seleccionado" ForeColor="White" Font-Bold="true"></asp:Label></span>
                <span style="float:right"><a href="#" onclick="javascript: $('#divPantallaBloqueo').hide(); $('#divEncima').hide();"><img src="../Imagenes/boton_cancelar.png" /></a></span>
            </div>

                <div class="form-inline text-center">
                    <div class="form-group">
                    </div>
                    <br />
                    <div class="form-group">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Width="80px"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br /><br />
                    <div class="form-group">
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo:" Width="80px"></asp:Label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br /><br />
                    <div class="form-group">
                            <asp:Label ID="lblStatus" runat="server" Text="Activo:" Width="50px"></asp:Label>
                            <asp:CheckBox ID="chkActivo" runat="server" /><span style="margin-right: 130px"></span>
                    </div>
                    <br /><br />
                    <div class="form-group">
                            <asp:Label ID="lblClave" runat="server" Text="Clave:" Width="80px"></asp:Label>
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br /><br />
                    <div class="form-group">
                            <asp:Label ID="lblContra" runat="server" Text="Contraseña:" Width="80px"></asp:Label>
                            <asp:TextBox ID="txtContra" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br /><br />
                    <div class="form-group">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btnAbajo3" OnClick="btnAceptar_Click" />
                    </div>
                </div>

            </div>

         </div>
  

    </div>
    
</asp:Content>
