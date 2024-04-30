<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmLiquidacionImportaciones.aspx.cs" Inherits="BlkProfessional.Forms.Sac.FrmLiquidacionImportaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <div class="container">
                        <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo SAC</h5></asp:LinkButton>
        <br />
        <h1 style="text-align: center;">Cierre de Almacenamiento y Descarga ITR</h1>
        <br />
        <div class="panel panel-default">
            <div class="panel-heading">
                <label class="col-form-label">Cierre de Almacenamiento y Descarga ITR</label>
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
                                <label for="txtUsuarioCorreo" class="col-sm-4 col-form-label">Mes</label>
                                <div class="col-sm-8">
                                     <asp:TextBox ID="txtFechaFin" TextMode="Date"  placeholder="Fecha Fin"  CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
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
                                <label for="txtPassword" class="col-sm-4 col-form-label">Cliente</label>
                                <div class="col-sm-8">
                                       <asp:DropDownList ID="ddlCliente" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>
<%--                                     <asp:TextBox ID="txtCliente" AutoPostBack="true" placeholder="Seleccion Cliente" OnTextChanged="txtCliente_TextChanged" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtTotalIngresosAlm"  Visible="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                           <asp:TextBox ID="txtTotalIngresosDesc"  Visible="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
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
                                <label for="txtPassword" class="col-sm-4 col-form-label">Tarifa Almacenamiento</label>
                                <div class="col-sm-8">
                                     <asp:TextBox ID="txtTarifaAlmacenamiento" AutoPostBack="true" placeholder="Tarifa Almacenamiento" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtRepPassword" class="col-sm-4 col-form-label">Tarifa Descarga Paletizado</label>
                                <div class="col-sm-8">
                                 <asp:TextBox ID="txtTarifaDescarga" placeholder="Tarifa Descarga Paletizado" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                     <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtPassword" class="col-sm-4 col-form-label">Tipo Liquidacion</label>
                                <div class="col-sm-8">
                                     <asp:TextBox ID="txtTipoLiquidacion" AutoPostBack="true" placeholder="Tipo Liquidacion" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6" >
                            <div class="form-group row">
                                <label for="txtRepPassword" class="col-sm-4 col-form-label">Tarifa Carga Suelta</label>
                                <div class="col-sm-8">
                                                                <asp:TextBox ID="txtTarifaCargaSuelta" AutoPostBack="true" placeholder="Tarifa Carga Suelta" Enabled="false" CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>        
                     <div class="col-md-12">
                        <div class="col-sm-6">
                            <div class="form-group row">
                                <label for="txtPassword" class="col-sm-4 col-form-label">Importacion</label>
                                <div class="col-sm-8">
                                          <asp:TextBox ID="txtImportacion" placeholder="Importacion"  CssClass="form-control"  style="width: 100% !important;" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6" >
                        
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
                                     <asp:Button ID="btnLimpiar" CssClass="btn btn-warning" OnClick="btnLimpiar_Click" runat="server" Text="Limpiar" />
                                </div>
                                <div class="col-sm-6">                                   
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-12">
                            <asp:GridView ID="GridViewLiquidacion" ShowFooter="true" runat="server" OnRowDataBound="GridViewLiquidacion_RowDataBound" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="GridViewLiquidacion_RowCommand">
                           
                                <Columns>

                                 
                                    <asp:BoundField DataField="dia" HeaderText="Dia" SortExpression="Id"  Visible="false"/>
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                    <asp:BoundField DataField="SaldoInicial" HeaderText="Saldo Inicial" SortExpression="Saldo Inicial" />
                              <%--      <asp:BoundField DataField="Entradas" HeaderText="Entradas" SortExpression="Entradas" />--%>
                                   <%-- <asp:BoundField DataField="Salidas" HeaderText="Salidas" SortExpression="Salidas" />--%>
                              <%--      <asp:BoundField DataField="Saldo" HeaderText="Saldo" SortExpression="Saldo" />--%>
                                    <asp:BoundField DataField="ValorUnitario" HeaderText="Valor Unitario" SortExpression="Valor Almacenamiento"  Visible="false"/>
<%--                                    <asp:BoundField DataField="ValorAlmacenamiento" HeaderText="Almacenamiento" SortExpression="Almacenamiento" />--%>
                                    <asp:BoundField DataField="TarifaDescarga" HeaderText="TarifaDescarga" SortExpression="Tarifa Descarga" Visible="false" />
                                   <%-- <asp:BoundField DataField="ValorDescarga" HeaderText="Descarga" SortExpression="ValorDescarga" />--%>
                                   

                                    <asp:TemplateField HeaderText="Entradas" >
			                         <ItemTemplate>
				                        <asp:Label ID="lblEntradas" runat="server" Text='<%# Eval("Entradas") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalEntradas" runat="server" />
			                         </FooterTemplate>
		                          </asp:TemplateField>


                                      <asp:TemplateField HeaderText="Salidas" >
			                         <ItemTemplate>
				                        <asp:Label ID="lblSalidas" runat="server" Text='<%# Eval("Salidas") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalSalidas" runat="server" />
			                         </FooterTemplate>
		                          </asp:TemplateField>



                                         <asp:TemplateField HeaderText="Saldo" >
			                         <ItemTemplate>
				                        <asp:Label ID="lblSaldo" runat="server" Text='<%# Eval("Saldo") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalSaldo" runat="server" />
			                         </FooterTemplate>
		                          </asp:TemplateField>

                                    
                                     <asp:TemplateField  HeaderText=" Ingreso Almacenamiento"  >
			                         <ItemTemplate>
				                        <asp:Label ID="lblValorAlmacenamiento" runat="server" Text='<%# Eval("ValorAlmacenamiento") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalAlmacenamiento" runat="server" />
			                         </FooterTemplate>
		                          </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Cargue/Descarga"   >
			                         <ItemTemplate>
				                        <asp:Label ID="lblValorDescarga" runat="server" Text='<%# Eval("ValorDescarga") %>'  />
			                         </ItemTemplate>
			                         <FooterTemplate >
				                        <asp:Label ID="lblTotalDescarga" runat="server" /> 
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
                                    <asp:Button ID="btnEnvar" Visible="false" CssClass="btn btn-warning" OnClick="btnEnvar_Click" runat="server" Text="Aprobar" />
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
