<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmInformeCantidadITR.aspx.cs" Inherits="BlkProfessional.Forms.Operaciones.FrmInformeCantidadITR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo SAC</h5></asp:LinkButton>
        <br />
        <h1 style="text-align: center;">Informe de Logistica y Transporte</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Informe de Logistica y Transporte</label>
            </div>
            <div class="panel-body">
                <div class="row" style="padding: 10px;">
                    <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuario" class="col-sm-4 col-form-label">Fecha Inicio </label>
                                <div class="col-sm-8">
                                 <asp:TextBox ID="txtFechaInicio" TextMode="Date"  placeholder="Fecha Inicio"  CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtUsuarioCorreo" class="col-sm-4 col-form-label">Fecha Fin</label>
                                <div class="col-sm-8">
                                  <asp:TextBox ID="txtFechaFin" TextMode="Date"  placeholder="Fecha Fin"  CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12" >
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtPassword" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">
                                       <asp:DropDownList ID="ddlCliente" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
                <%--                     <asp:TextBox ID="txtCliente" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>--%>
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
                    <div class="col-md-12" >
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
                                <label for="cmbLocation" class="col-sm-4 col-form-label">Almacen</label>
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
                                <div class="col-sm-10">
                                    <asp:Button ID="btnDescargar" CssClass="btn btn-warning" OnClick="btnDescargar_Click" runat="server" Text="Descargar" />
                                       <asp:Button ID="btnGenerar" CssClass="btn btn-warning" OnClick="btnGenerar_Click" runat="server" Text="Generar" />
                                    <asp:Button ID="btnLimpiar" CssClass="btn btn-warning" OnClick="btnLimpiar_Click" runat="server" Text="Limpiar" />
                                </div>
                                <div class="col-sm-2">                                   
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-12">
                            <asp:GridView ID="gvLogisticaITR" ShowFooter="true" runat="server" OnRowDataBound="gvLogisticaITR_RowDataBound" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="gvLogisticaITR_RowCommand">
                           
                                <Columns>

                                 
                                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente"  />
                                    <asp:BoundField DataField="Importacion" HeaderText="Importacion" SortExpression="Importacion" />
                                    <asp:BoundField DataField="NumeroContenedores" HeaderText="No Contenedores" SortExpression="No Contenedores" />                                   

                                    <asp:TemplateField HeaderText="Tarifa" >
			                         <ItemTemplate>
				                        <asp:Label ID="lblTarifa" runat="server" Text='<%# Eval("Tarifa") %>'  />
			                         </ItemTemplate>  
		                          </asp:TemplateField>


                                      <asp:TemplateField HeaderText="TotalIngreso" >
			                         <ItemTemplate>
				                        <asp:Label ID="lbllIngreso" runat="server" Text='<%# Eval("TotalIngreso") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalIngresos" runat="server" />
			                         </FooterTemplate>
		                          </asp:TemplateField>



                               
                                                     
                                </Columns>
   
                                <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                  
                                   
                                 
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
                                    <asp:Button ID="btnEnvar" Visible="false" CssClass="btn btn-warning" OnClick="btnEnvar_Click" runat="server" Text="Enviar" />
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
