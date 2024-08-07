﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInventarioCliente.aspx.cs" Inherits="BlkProfessional.Forms.Clientes.FrmInventarioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">     
        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo Operaciones</h5></asp:LinkButton>
        <br />
        <h1 style="text-align: center;">Informe de Inventarios</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informes de Liquidacion de Inventarios</label>
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
                                        <asp:ListItem Value="2024">2024</asp:ListItem>   
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuarioCorreo" class="col-sm-4 col-form-label">Mes</label>
                                <div class="col-sm-8">
                                      <asp:DropDownList CssClass="form-control" ID="ddlMonth" Enabled="false" runat="server">
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
                                     <asp:TextBox ID="txtCliente" Enabled="false" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
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
                                  <asp:DropDownList ID="ddl_Terminal" Enabled="false" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Terminal_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="cmbLocation" class="col-sm-4 col-form-label">Almacen</label>
                                <div class="col-sm-8">
                                         <asp:DropDownList ID="ddlLocation" Enabled="false" runat="server" CssClass="form-control" ></asp:DropDownList>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>