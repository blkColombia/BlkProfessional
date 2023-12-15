﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTareaDetalle.aspx.cs" Inherits="BlkProfessional.Forms.TalentoHumano.FrmTareaDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        textarea {
            max-width: 100% !important;
        }
    </style>
    <div class="container-fluid vh-100">
        <div class="row justify-content-center align-items-center h-100">
            <div class="col-md-12">

                <div class="card">
                    <div class="card-body">
                        <br />
                        <h1 class="card-title text-center">Compromisos y cierres de brecha</h1>
                        <br />
                        <div class="panel panel-default">
                            <div class="panel-heading">Compromisos Cierres de brecha resultados Excelentes</div>
                            <div class="panel-body">
                                <!-- Agrega tus controles de formulario aquí -->

                                <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label for="txtNombre">Responsable</label>
                                            <input type="text" class="form-control" id="txtNombre" runat="server" disabled="disabled">
                                        </div>

                                        <div class="form-group col-md-6"">
                                            <label for="txtNombre">Cargo</label>
                                            <input type="text" class="form-control" id="txtCargo" runat="server" disabled="disabled">
                                        </div>
                                </div>

                                  <div class="form-row">
                                        <div class="form-group col-md-6"">
                                            <label for="txtNombre">Fecha Cierre</label>
                                            <input type="text" class="form-control" id="txtFechaCierreRE" runat="server" disabled="disabled">
                                        </div>

                                        <div class="form-group col-md-6"">
                                             <label for="ddlEstadoTareaCB">Estado de la Tarea</label>
                                            <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Seleccione Estado--" Value="" />
                                                <asp:ListItem Text="Pendiente" Value="1" />
                                                <asp:ListItem Text="Finalizado" Value="2" />
                                             
                                            </asp:DropDownList>
                                        </div>
                                </div>

                                 <div class="form-row">
                                        <div class="form-group col-md-11">
                                            <label for="txtEmail">Compromiso Resultado Excelente</label>
                                            <textarea class="form-control" rows="2" id="txtResultadoExcelente"  runat="server" disabled="disabled"></textarea>
                                        </div>
                                 </div>

                                  <div class="form-row">
                                <div class="form-group col-md-11">
                                    <label for="txtEmail">Desarrollo de Tarea por parte del responsable</label>
                                    <textarea class="form-control" rows="2" id="txtSolucionTareaRE"  runat="server"></textarea>
                                </div>
                                </div>


                                <div class="form-row">
                                <div class="form-group col-md-11">
                                    <label for="txtEmail">Comentarios del Lider</label>
                                    <textarea class="form-control" rows="2" id="txtSeguimLRE" disabled="disabled" runat="server"></textarea>
                                </div>
                                     </div>


                                  <div class="form-row">
                                <div class="form-group col-md-11 text-center">
                                    <button type="submit" class="btn btn-primary">Atras</button>
                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-secondary" />                                    
                                </div>

                                      </div>
                            </div>
                            </div>
                        </div>

                        <div class="panel panel-default">
                            <div class="panel-heading">Compromisos Cierres de brecha servicio al cliente</div>
                            <div class="panel-body">
                                <!-- Agrega tus controles de formulario aquí -->

                                <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label for="txtNombre">Responsable</label>
                                            <input type="text" class="form-control" id="txtResponsableSC" runat="server" disabled="disabled">
                                        </div>

                                        <div class="form-group col-md-6"">
                                            <label for="txtNombre">Cargo</label>
                                            <input type="text" class="form-control" id="txtCargoSC" runat="server" disabled="disabled">
                                        </div>
                                </div>

                                  <div class="form-row">
                                        <div class="form-group col-md-6"">
                                            <label for="txtNombre">Fecha Cierre</label>
                                            <input type="text" class="form-control" id="txtFechaCierreSC" runat="server" disabled="disabled">
                                        </div>

                                        <div class="form-group col-md-6"">
                                            <label for="ddlEstadoTareaCBC">Estado de la Tarea</label>
                                            <asp:DropDownList ID="ddlEstadoTareaCBC" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Seleccione Estado--" Value="" />
                                                <asp:ListItem Text="Pendiente" Value="1" />
                                                <asp:ListItem Text="Finalizado" Value="2" />
                                              
                                            </asp:DropDownList>
                                        </div>
                                </div>

                                 <div class="form-row">
                                        <div class="form-group col-md-11">
                                            <label for="txtEmail">Compromiso Servicio al Cliente</label>
                                            <textarea class="form-control" rows="2" id="txtCompromisoSC"  runat="server" disabled="disabled"></textarea>
                                        </div>
                                 </div>

                                  <div class="form-row">
                                <div class="form-group col-md-11">
                                    <label for="txtEmail">Desarrollo de Tarea por parte del responsable</label>
                                    <textarea class="form-control" rows="2" id="txtSolucionSC" runat="server"></textarea>
                                </div>
                                </div>


                                <div class="form-row">
                                <div class="form-group col-md-11">
                                    <label for="txtEmail">Comentarios del Lider</label>
                                    <textarea class="form-control" rows="2" id="txtSeguimLSC" disabled="disabled" runat="server"></textarea>
                                </div>
                                     </div>


                                  <div class="form-row">
                                <div class="form-group col-md-11 text-center">
                                    <button type="submit" class="btn btn-primary">Enviar</button>
                                    <button type="button" class="btn btn-secondary">Atras</button>
                                </div>
                                      </div>


                                  <div class="form-row">
                                <div class="form-group col-md-11">                    
                                    <button type="button" class="btn btn-secondary">Atras</button>
                                </div>
                                      </div>

                            </div>
                            </div>
         
                    </div>
                </div>

            </div>
        </div>
   
</asp:Content>
