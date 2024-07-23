<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCierreCedis.aspx.cs" Inherits="BlkProfessional.Forms.Financiera.CEDIS.FrmCierreCedis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo Financiero</h5></asp:LinkButton>
        <h1 style="text-align: center;">Cierre Cedis Terceros</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Cierre Cedis Terceros</label>
            </div>
            <div class="panel-body">
                <div class="row" style="padding: 10px;">
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuario" class="col-sm-4 col-form-label">Año </label>
                                <div class="col-sm-8">
                                     <asp:DropDownList CssClass="form-control" ID="ddlYear" Enabled="false" runat="server">
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
                                      <asp:DropDownList CssClass="form-control"  ID="ddlMonth" runat="server">
                                        <asp:ListItem Value="0">-Seleccione Mes-</asp:ListItem>
                                   <%--   <asp:ListItem Value="01">Enero</asp:ListItem>
                                          <asp:ListItem Value="02">Febrero</asp:ListItem>
                                          <asp:ListItem Value="03">Marzo</asp:ListItem>--%>
                                          <asp:ListItem Value="04">Abril</asp:ListItem>
                                          <asp:ListItem Value="05">Mayo</asp:ListItem>
                                     <asp:ListItem Value="06">Junio</asp:ListItem>
                                         <asp:ListItem Value="07">Julio</asp:ListItem>
                                        <%--        <asp:ListItem Value="08">Agosto</asp:ListItem>
                                          <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                          <asp:ListItem Value="10">Octubre</asp:ListItem>
                                          <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                          <asp:ListItem Value="12">Diciembre</asp:ListItem>  --%>                                                                               
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
                                    <asp:Button ID="btnDescargar" Enabled="false" CssClass="btn btn-warning" OnClick="btnDescargar_Click" runat="server" Text="Crear" />
                                     <asp:Button ID="btnResumen" CssClass="btn btn-warning" OnClick="btnResumen_Click" runat="server" Text="Visualizar" />
                                </div>
                                <div class="col-sm-6">    
       
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-12">
                            <asp:GridView ID="gvCierre" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvCierre_RowDataBound" CssClass="table table-bordered table-striped" OnRowCommand="gvCierre_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="FechaInicial" HeaderText="Fecha Inicio" SortExpression="Periodo Inicio" />
                                    <asp:BoundField DataField="FechaFinal" HeaderText="Fecha Fin" SortExpression="Periodo Fin" />
                                  <%--  <asp:BoundField DataField="Terminal" HeaderText="Terminal" SortExpression="Terminal" />--%>
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                     <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Apertura" SortExpression="Fecha Apertura" />
                                    <asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Apertura" SortExpression="Usuario Apertura" />                                    
                                    <asp:BoundField DataField="FechaCierre" HeaderText="Fecha Cierre" SortExpression="Fecha Cierre" />
                                    <asp:BoundField DataField="UsuarioCierre" HeaderText="Usuario Cierre" SortExpression="Usuario Cierre" />
                                     <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <!-- Agrega aquí tus iconos y lógica -->
                                            <asp:LinkButton CommandName="Visualizar" CommandArgument='<%# Eval("IdCierre") %>' runat="server" CssClass="btn btn-link btn-sm">Gestionar
                                             <%--<i class="fas fa-search text-primary"> Gestionar</i>--%>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
