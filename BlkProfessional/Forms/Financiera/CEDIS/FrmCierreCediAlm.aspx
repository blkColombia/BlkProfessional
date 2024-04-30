<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmCierreCediAlm.aspx.cs" Inherits="BlkProfessional.Forms.Financiera.CEDIS.FrmCierreCediAlm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click"><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo Financiero</h5></asp:LinkButton>
        <h1 style="text-align: center;">Informe de Cierre Cedis Tercero</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informe Cierre Cedis Tercero</label>
            </div>
            <div class="panel-body">
                <div class="row" style="padding: 10px;">
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuario" class="col-sm-4 col-form-label">Año </label>
                                <div class="col-sm-8">
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlYear" runat="server">
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
                                    <asp:DropDownList Enabled="false" CssClass="form-control" ID="ddlMonth" runat="server">
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
                                    <asp:TextBox ID="txtCliente" Enabled="false" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control" Style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtRepPassword" class="col-sm-4 col-form-label">Descripcion Cliente</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtDescripcionCliente" placeholder="Descripcion Cliente" Enabled="false" CssClass="form-control" Style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbTerminal" class="col-sm-4 col-form-label">Terminal</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddl_Terminal" runat="server" Enabled="false" OnSelectedIndexChanged="ddl_Terminal_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6" style="display: none;">
                            <div class="form-group row">
                                <label for="cmbLocation" class="col-sm-4 col-form-label">Almacen</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlLocation" Enabled="false" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                <asp:BoundField DataField="CodCliente" HeaderText="CodCliente" SortExpression="CodCliente" />
                                <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto" />
                                <asp:BoundField DataField="Terminal" HeaderText="Terminal" SortExpression="Terminal" />
                                <asp:BoundField DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" />
                                <asp:BoundField DataField="ValorConcepto" HeaderText="Valor Concepto" SortExpression="Valor Concepto" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <!-- Agrega aquí tus iconos y lógica -->
                                        <asp:LinkButton CommandName="Visualizar" CommandArgument='<%# Eval("IdCierreDetalle") %>' runat="server" CssClass="btn btn-link btn-sm">Gestionar
                                          <%--   <i class="fas fa-search text-primary"></i>--%>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>

                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <div class="col-sm-6">

                                    <asp:Button ID="btnVolver" CssClass="btn btn-warning" OnClick="btnVolver_Click" runat="server" Text="Volver" />
                                </div>
                                <div class="col-sm-6">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>