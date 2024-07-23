<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInformeLiquidacionMes.aspx.cs" Inherits="BlkProfessional.Forms.Operaciones.FrmInformeLiquidacionMes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <h1 style="text-align: center;">Informes Liquidacion por Cliente</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informes de Liquidacion por Cliente</label>
            </div>
            <div class="panel-body">
                <div class="row" style="padding: 10px;">
                  <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuario" class="col-sm-4 col-form-label">Año </label>
                                <div class="col-sm-8">
                                     <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server">
                                        <asp:ListItem Value="0">-Seleccione Movimiento-</asp:ListItem>        
                                        <asp:ListItem Value="2024">2024</asp:ListItem>  
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuarioCorreo" class="col-sm-4 col-form-label">Mes</label>
                                <div class="col-sm-8">
                                      <asp:DropDownList CssClass="form-control" ID="ddlMonth" runat="server">
                                        <asp:ListItem Value="0">-Seleccione Mes-</asp:ListItem>
                                        <asp:ListItem Value="01">Enero</asp:ListItem>
                                          <asp:ListItem Value="02">Febrero</asp:ListItem>
                                          <asp:ListItem Value="03">Marzo</asp:ListItem>
                                          <asp:ListItem Value="04">Abril</asp:ListItem>
                                          <asp:ListItem Value="05">Mayo</asp:ListItem>
                                          <asp:ListItem Value="06">Junio</asp:ListItem>
                                          <asp:ListItem Value="07">Julio</asp:ListItem>
                                          <asp:ListItem Value="08">Agosto</asp:ListItem>
                                          <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                          <asp:ListItem Value="10">Octubre</asp:ListItem>
                                          <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                          <asp:ListItem Value="12">Diciembre</asp:ListItem>                                                                                 
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtPassword" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">

                             <asp:DropDownList ID="ddlCliente"  OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>      
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtRepPassword" class="col-sm-4 col-form-label">Descripcion Cliente</label>
                                <div class="col-sm-8">
                                 <asp:TextBox ID="txtDescripcionCliente" placeholder="Descripcion Cliente" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbTerminal" class="col-sm-4 col-form-label">Terminal</label>
                                <div class="col-sm-8">
                                  <asp:DropDownList ID="ddl_Terminal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Terminal_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbPedido" class="col-sm-4 col-form-label">Numero Pedido</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPedido" placeholder="Numero Pedido" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>              
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                             
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnDescargar" CssClass="btn btn-warning" OnClick="btnDescargar_Click" runat="server" Text="Descargar" />
                                </div>
                                <div class="col-sm-6">  
                                        <asp:Button ID="btnDescargarPdf" CssClass="btn btn-warning" OnClick="btnDescargarPdf_Click" runat="server" Text="Descargar Pdf" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
