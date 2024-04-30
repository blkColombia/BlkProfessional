<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTarea.aspx.cs" Inherits="BlkProfessional.Forms.TalentoHumano.FrmTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">

    <div class="formularios">
         <div class="row">
                <div class="col">
                    <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:30px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal >>  Modulo Direccion Gestion Humana</h5></asp:LinkButton>
                 </div>
             </div>
        <div class="row">
            <div class="col">
                <h1 style="text-align: center;">Mis Compromisos de Cierre de Brechas</h1>
                <br>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group row">
                    <%--  <label for="txtFiltro" class="col-sm-1 col-form-label">Filtro</label>--%>
                    <div class="col-sm-8">
                        <%--<input type="text" class="form-control" style="width: 100% !important;" id="txtReferencia" placeholder="Filtrar" name="pswd">--%>
                    </div>
                </div>
            </div>
            <div class="col-sm-6">

            </div>
        </div>
        <br>

        <div class="row">
            <div class="col-md-12">
                <div class="container mt-4">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridViewEmpleados" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" OnRowCommand="GridViewEmpleados_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="IdTarea" HeaderText="ID" SortExpression="Id" />
                                    <asp:BoundField DataField="Responsable" HeaderText="Nombre" SortExpression="Nombre" />
                                    <asp:BoundField DataField="CargoResponsable" HeaderText="Cargo" SortExpression="Cargo" />
                                    <asp:BoundField DataField="CBResultadosExcelentes" HeaderText="Resultado a la excelencia" SortExpression="Resultado a la excelencia" />
                                     <asp:BoundField DataField="EstadoTareaResult" HeaderText="Estado" SortExpression="Estado" />
                                    <asp:BoundField DataField="FechaCierreResult" HeaderText="Fecha Cierre" SortExpression="Servicio al Cliente" />
                                    <asp:BoundField DataField="CBServicioalCliente" HeaderText="Servicio al cliente" SortExpression="Fecha Cierre" />
                                    <asp:BoundField DataField="EstadoTareaSC" HeaderText="Estado" SortExpression="Estado" />
                                     <asp:BoundField DataField="FechaCierreSC" HeaderText="FEcha Cierre" SortExpression="Estado" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <!-- Agrega aquí tus iconos y lógica -->
                                            <asp:LinkButton CommandName="Visualizar" CommandArgument='<%# Eval("IdTarea") %>' runat="server" CssClass="btn btn-link btn-sm">
                                             <i class="fas fa-search text-primary"></i>
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
    </div>




</asp:Content>
