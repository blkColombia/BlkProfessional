<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmIngresosBlk.aspx.cs" Inherits="BlkProfessional.Forms.Financiera.FrmIngresosBlk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo Financiero</h5></asp:LinkButton>
        <h1 style="text-align: center;">Ingresos de Bulkmatic</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informes de Ingresos Bulkmatic</label>
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
                                        <asp:ListItem Value="2022">2022</asp:ListItem>
                                        <asp:ListItem Value="2023">2023</asp:ListItem>   
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
                    <div class="col-md-12" style="display:none;">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtPassword" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">
                                     <asp:TextBox ID="txtCliente" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
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
                    <div class="col-md-12" style="display:none;">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbTerminal" class="col-sm-4 col-form-label">Terminal</label>
                                <div class="col-sm-8">
                                  <asp:DropDownList ID="ddl_Terminal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Terminal_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6" style="display:none;">
                            <div class="form-group row">
                                <label for="cmbLocation" class="col-sm-4 col-form-label">Almacen</label>
                                <div class="col-sm-8">
                                         <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" ></asp:DropDownList>
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
                                    <asp:Button ID="btnDescargar" CssClass="btn btn-warning" OnClick="btnDescargar_Click" runat="server" Text="Detalle" />
                                     <asp:Button ID="btnResumen" CssClass="btn btn-warning" OnClick="btnResumen_Click" runat="server" Text="Resumen" />
                                </div>
                                <div class="col-sm-6">    
       
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-12">
                            <asp:GridView ID="gvTolvas" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvTolvas_RowDataBound" CssClass="table table-bordered table-striped" OnRowCommand="gvTolvas_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="CentrodeCosto" HeaderText="Centro de Costo" SortExpression="CentrodeCosto" />
                                    <asp:BoundField DataField="Terminal" HeaderText="Terminal" SortExpression="Cliente" />
                                    <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" />
                                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />
                                    <asp:BoundField DataField="ValorIngreso" HeaderText="Total Ejecutado Mes" SortExpression="ValorIngreso" />
               
                                </Columns>
                            </asp:GridView>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
