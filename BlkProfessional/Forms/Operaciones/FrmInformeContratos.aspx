<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInformeContratos.aspx.cs" Inherits="BlkProfessional.Forms.Operaciones.FrmInformeContratos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <h1 style="text-align: center;">Informes de OSI por contrato y Servicios</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informes de OSI por contrato y Servicios</label>
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
                                <label for="lblCliente" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">
                                     <asp:TextBox ID="txtCliente" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="lblClienteDescripcion" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtDescripcionCliente" placeholder="Descripcion Cliente" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbTiendas" class="col-sm-4 col-form-label">Contrato</label>
                                <div class="col-sm-8">
                                   <asp:TextBox ID="txtContratos" AutoPostBack="true" placeholder="Seleccion Contrato" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbRol" class="col-sm-4 col-form-label"></label>
                                <div class="col-sm-8">
                                  
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
                                    <button type="button" class="btn btn-warning">Descargar Excel</button>
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
