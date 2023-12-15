<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTrazabilidad.aspx.cs" Inherits="BlkProfessional.Forms.Operaciones.FrmTrazabilidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <h1 style="text-align: center;">Informe de Trazabilidad</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informes de Trazabilidad</label>
            </div>
            <div class="panel-body">
                <div class="row" style="padding: 10px;">
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="lblFechaInicio" class="col-sm-4 col-form-label">Fecha Inicio </label>
                                <div class="col-sm-8">
                                    <asp:TextBox CssClass="form-control"  style="width: 100% !important;" ID="txtFechaInicio" TextMode="Date" runat="server"></asp:TextBox>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="lblFechaFin" class="col-sm-4 col-form-label">Fecha Fin</label>
                                <div class="col-sm-8">
                                    <asp:TextBox CssClass="form-control"  style="width: 100% !important;" ID="txtFechaFin" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
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
                                <label for="lblCliente" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">                                    
                                    <asp:TextBox ID="txtDescripcionCliente" placeholder="Descripcion Cliente" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbTiendas" class="col-sm-4 col-form-label">Tipo Movimiento</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList CssClass="form-control" ID="ddlMovimientos" runat="server">
                                        <asp:ListItem Value="0">-Seleccione Movimiento-</asp:ListItem>
                                        <asp:ListItem Value="2">Entradas</asp:ListItem>
                                        <asp:ListItem Value="3">Salidas</asp:ListItem>
                                        <asp:ListItem Value="4">Transferencias</asp:ListItem>                                        
                                    </asp:DropDownList>
                        
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbRol" class="col-sm-4 col-form-label">Segmento</label>
                                <div class="col-sm-8">
                                   <asp:DropDownList CssClass="form-control" ID="ddlSegmentos" runat="server">
                                        <asp:ListItem Value="0">-Seleccione Segmento-</asp:ListItem>
                                        <asp:ListItem Value="ENSACADO">ENSACADO</asp:ListItem>
                                        <asp:ListItem Value="GRANEL">GRANEL</asp:ListItem>
                                        <asp:ListItem Value="ITR">ITR</asp:ListItem>                                        
                                    </asp:DropDownList>
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
                               <%--     <button type="button" class="btn btn-warning">Descargar Excel</button>--%>
                                    
                                    <asp:Button ID="btnDescargar" CssClass="btn btn-warning" OnClick="btnDescargar_Click" runat="server" Text="Descargar" />
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
