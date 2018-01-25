<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="CM2017.Utilerias.Menu" %>
    <style type="text/css">
        .static-banner {
          position: fixed;
          right: 80px;
          top: 53px;
          color: white;
          background: #A2C;
          z-index: 1999; /* above items */
        }
		#stickyheader 
		{
			width: 100%;
            z-index: 10000
		}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $(".dropdown").hover(
                    function () {
                        $('.dropdown-menu', this).stop(true, true).fadeIn("fast");
                        $(this).toggleClass('open');
                        $('b', this).toggleClass("caret caret-up");
                    },
                    function () {
                        $('.dropdown-menu', this).stop(true, true).fadeOut("fast");
                        $(this).toggleClass('open');
                        $('b', this).toggleClass("caret caret-up");
                    });
            });
            $(function () {
                // Check the initial Poistion of the Sticky Header
                var stickyHeaderTop = $('#stickyheader').offset().top;

                $(window).scroll(function () {
                    if ($(window).scrollTop() > stickyHeaderTop) {
                        $('#stickyheader').css({ position: 'fixed', top: '0px' });
                        $('#stickyalias').css('display', 'block');
                    } else {
                        $('#stickyheader').css({ position: 'static', top: '0px' });
                        $('#stickyalias').css('display', 'none');
                    }
                });
            });
        });
    </script>

    <div id="stickyheader">
        <nav class="navbar navbar-inverse" style="border-bottom: 2px solid black">
            <div class="container-fluid">
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li class="dropdown">
                            <a href="../Sistema/Inicio.aspx" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Inicio</a>
                        </li>
                        <li class="dropdown">
                            <a href="../Sistema/frmCaptura.aspx" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Capturar</a>
                        </li>
                        <li class="dropdown">
                            <a href="../Admin/frmUsuarios.aspx" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Usuarios</a>
                        </li>
                        <li class="dropdown">
                            <a href="../Admin/frmDivision.aspx" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Catalogos<span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="../Admin/frmDivision.aspx">División</a></li>
                                <li><a href="../Admin/frmGerenteProducto.aspx">Gerente de Producto</a></li>
                                <li><a href="../Admin/frmLocacion.aspx">Locación</a></li>
                                <li><a href="../Admin/frmTeamLeader.aspx">Team Leader</a></li>
                                <li><a href="../Admin/frmTipoAudiencia.aspx">Tipo de Audiencia</a></li>
                                <li><a href="../Admin/frmTipoEvento.aspx">Tipo de Evento</a></li>
                                <li><a href="../Admin/frmUDN.aspx">Unidad de Negocio</a></li>
                                <li><a href="../Admin/frmProductos.aspx">Productos</a></li>
                                <li><a href="../Admin/frmClienteInterno.aspx">Cliente Interno</a></li>
                                <li><a href="../Admin/frmAreaTerapeutica.aspx">Area Terapéutica</a></li>
                                <li><a href="../Admin/frmEventosDesactivados.aspx">Eventos Desactivados</a></li>
                                <li><a href="../Admin/frmEventosTerminados.aspx">Eventos Terminados</a></li>
                            </ul>
                        </li>
                        <li class="active">
                            <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="active">Cerrar sesión</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>