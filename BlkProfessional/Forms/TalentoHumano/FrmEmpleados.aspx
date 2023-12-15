<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmEmpleados.aspx.cs" Inherits="BlkProfessional.Forms.TalentoHumano.FrmEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://cdn.datatables.net/1.13.4/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
     

    <script>

        $(document).ready(function () {
         
            try {                       
                $.ajax({
                    type: "POST",
                  // url:'<%= ResolveUrl("FrmEmpleados.aspx/BuscarEmpleados") %>',      
                   url: "https://localhost:44374/Forms/TalentoHumano/FrmEmpleados.aspx/BuscarEmpleados",

                    data: "{idEmpresa: 1}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    success: function (resultado) {
                        if (resultado != "") {
                            var table = $('#TablaEmpleados').DataTable({
                                data: resultado.d,
                                columns: [
                                    { data: 'EmployeeId' },
                                    {
                                        data: 'IdTipoIdentificacion',
                                        visible: false
                                    },
                                    { data: 'TipoIdentificacion' },
                                    { data: 'NumeroIdentificacion' },
                                    { data: 'Nombres' },
                                    { data: 'Apellidos' },
                                    {
                                        data: 'CargoId',
                                        visible: false
                                    },
                                    { data: 'Cargo' },
                                    { data: 'Correo' },
                                    { data: 'Telefono' }
                                ]
                            });

                            $('#TablaEmpleados tbody').on('click', 'tr', function () {
                                if ($(this).hasClass('selected')) {
                                    $(this).removeClass('selected');
                                } else {
                                    table.$('tr.selected').removeClass('selected');
                                    $(this).addClass('selected');
                                }
                            });

                           

                            $('#btnEditar').click(function () {
                                var data = table.row('.selected').data();
                                console.log(data);
                                if (data != undefined) {
                                    $("#txtIdentificacion").val(data.NumeroIdentificacion);
                                    $("#cmbTipoIdentificacion").val(data.IdTipoIdentificacion);
                                    $("#txtNombres").val(data.Nombres);
                                    $("#txtApellidos").val(data.Apellidos);
                                    $("#cmbCargo").val(data.CargoId);
                                    $("#txtCorreo").val(data.Correo);
                                    $("#txtTelefono").val(data.Telefono);
                                    $("#txtIdEmpleado").val(data.EmployeeId); 
                                }                               
                            });

                        }
                    }
                }
                );
            } catch (e) {
                alert('error' + e.toString());
            }
            //eventos
            $("#btnAgregar").click(function (evento) {
                $('#btnGuardarEmpleado').show();
                $('#btnActualizarEmpleado').hide();
            });

            $("#btnEditar").click(function (evento) {
                $('#btnGuardarEmpleado').hide();
                $('#btnActualizarEmpleado').show();
            });

            $("#btnGuardarEmpleado").click(function (evento) {

                function TipoIdentificacion() {
                    var TipoIdentificacion = $("#cmbTipoIdentificacion option:selected").val();
                    if (TipoIdentificacion == "0") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return TipoIdentificacion;
                }

                function NumeroIdentificacion() {
                    var NumeroIdentificacion = $("#txtIdentificacion").val();
                    if (NumeroIdentificacion == "") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return NumeroIdentificacion;
                }

                function Nombres() {
                    var Nombres = $("#txtNombres").val();
                    if (Nombres == "") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return Nombres;
                }

                function Apellidos() {
                    var Apellidos = $("#txtApellidos").val();
                    if (Apellidos == "") {
                        alert("Los Apellidos no pueden ser vacios");
                        return;
                    }
                    return Apellidos;
                }


                function Cargo() {
                    var Cargo = $("#cmbCargo option:selected").val();
                    if (Cargo == "0") {
                        alert("El cargo no puede ser vacio");
                        return;
                    }
                    return Cargo;
                }

                function Correo() {
                    var Correo = $("#txtCorreo").val();
                    if (Correo == "") {
                        alert("El correo no puede ser vacio");
                        return;
                    }
                    return Correo;
                }

                function Telefono() {
                    var Telefono = $("#txtTelefono").val();
                    if (Telefono == "") {
                        alert("El telefono no puede ser vacia");
                        return;
                    }
                    return Telefono;
                }
                try {
                    $.ajax({
                        type: "POST",
                       // url:'<%= ResolveUrl("FrmEmpleados.aspx/GuardarEmpleado") %>',
                        data: "{idEmpresa: 1 , idTipoIdentificacion : '" + TipoIdentificacion() + "', identificacion : '" + NumeroIdentificacion() + "', nombres : '" + Nombres() + "', apellidos : '" + Apellidos() + "', cargo : '" + Cargo() + "', correo : '" + Correo() + "', telefono : '" + Telefono() + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (resultado) {
                            if (resultado != "") {
                                var consulta = resultado.d;
                                window.location.href = '/Forms/FrmEmpleados.aspx';
                            }
                        }
                    }
                    );
                } catch (e) {
                    alert('error' + e.toString());
                }
            });


            //boton de actualizar

            $("#btnActualizarEmpleado").click(function (evento) {

                function IdEmpleado() {
                    var IdEmpleado = $("#txtIdEmpleado").val();
                    if (IdEmpleado == "") {
                        alert("El Id del empleado no puede ser vacio");
                        return;
                    }
                    return IdEmpleado;
                }


                function TipoIdentificacion() {
                    var TipoIdentificacion = $("#cmbTipoIdentificacion option:selected").val();
                    if (TipoIdentificacion == "0") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return TipoIdentificacion;
                }

                function NumeroIdentificacion() {
                    var NumeroIdentificacion = $("#txtIdentificacion").val();
                    if (NumeroIdentificacion == "") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return NumeroIdentificacion;
                }

                function Nombres() {
                    var Nombres = $("#txtNombres").val();
                    if (Nombres == "") {
                        alert("La identificacion no puede ser vacia");
                        return;
                    }
                    return Nombres;
                }

                function Apellidos() {
                    var Apellidos = $("#txtApellidos").val();
                    if (Apellidos == "") {
                        alert("Los Apellidos no pueden ser vacios");
                        return;
                    }
                    return Apellidos;
                }


                function Cargo() {
                    var Cargo = $("#cmbCargo option:selected").val();
                    if (Cargo == "0") {
                        alert("El cargo no puede ser vacio");
                        return;
                    }
                    return Cargo;
                }

                function Correo() {
                    var Correo = $("#txtCorreo").val();
                    if (Correo == "") {
                        alert("El correo no puede ser vacio");
                        return;
                    }
                    return Correo;
                }

                function Telefono() {
                    var Telefono = $("#txtTelefono").val();
                    if (Telefono == "") {
                        alert("El telefono no puede ser vacia");
                        return;
                    }
                    return Telefono;
                }           

               <%-- try {
                    $.ajax({
                        type: "POST",
                        url:"http://localhost:44374/Forms/TalentoHumano/FrmEmpleados",
                    //    url:'<%= ResolveUrl("FrmEmpleados.aspx/ActualizarEmpleado") %>',
                        data: "{idEmpresa: 1 , idTipoIdentificacion : '" + TipoIdentificacion() + "', identificacion : '" + NumeroIdentificacion() + "', nombres : '" + Nombres() + "', apellidos : '" + Apellidos() + "', cargo : '" + Cargo() + "', correo : '" + Correo() + "', telefono : '" + Telefono() + "',idEmpleado : '"+IdEmpleado()+"'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (resultado) {
                            if (resultado != "") {
                                var consulta = resultado.d;
                                window.location.href = '/Forms/FrmEmpleados.aspx';
                            }
                        }
                    }
                    );
                } catch (e) {
                    alert('error' + e.toString());
                }--%>
            });
        }); </script>

    <div class="formularios">
        <div class="row">
            <div class="col">
                <br>
                <br>
                <h1 style="text-align: center;">Configuracion Empleado</h1>
                <br>
                <br>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group row">
                    <%--<label for="txtFiltro" class="col-sm-1 col-form-label">Filtro</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" style="width: 100% !important;" id="txtReferencia" placeholder="Filtrar" name="pswd">
                    </div>--%>
                </div>
            </div>
            <div class="col">
                <button type="button" id="btnAgregar" class="btn botones btn-success" data-toggle="modal" data-target="#modal" style="width: 40%;">Agregar Empleado</button>
                <button type="button" id="btnEditar" class="btn botones btn-primary" data-toggle="modal" data-target="#modal" style="width: 40%;">Editar Empleado</button>
            </div>
        </div>
        <br>
        <!-- Modal -->
        <div class="modal bd-example-modal-lg" tabindex="-1" id="modal" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title">Ingresar Empleado</h2>
                    </div>
                    <div class="modal-body">
                        <br>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label style="display:none;" id="txtIdEmpleado" class="col-sm-4 col-form-label">Tipo</label>
                                        <label for="txtTipoIdentificacion" class="col-sm-4 col-form-label">Tipo</label>
                                        <div class="col-sm-8">
                                            <select class="form-control" id="cmbTipoIdentificacion">
                                                <option value="0">--Seleccione Tipo Identificacion --  </option>
                                                <option value="1">Cedula Ciudadania</option>
                                                <option value="2">Cedula Extranjeria</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtIdentificacion" class="col-sm-4 col-form-label">Identificacion</label>
                                        <div class="col-sm-8">
                                            <input type="text" class="form-control" style="width: 100% !important;" id="txtIdentificacion" placeholder="Identificacion">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtNombres" class="col-sm-4 col-form-label">Nombres</label>
                                        <div class="col-sm-8">
                                            <input type="text" class="form-control" style="width: 100% !important;" id="txtNombres" placeholder="Nombres">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtApellidos" class="col-sm-4 col-form-label">Apellidos</label>
                                        <div class="col-sm-8">
                                            <input type="text" class="form-control" style="width: 100% !important;" id="txtApellidos" placeholder="Apellidos">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtCargo" class="col-sm-4 col-form-label">Cargo</label>
                                        <div class="col-sm-8">
                                            <select id="cmbCargo" class="form-control">
                                                <option value="0">--Seleccione Cargo --  </option>
                                                <option value="1">Auxiliar</option>
                                                <option value="2">Gerente</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtEstado" class="col-sm-4 col-form-label">Estado</label>
                                        <div class="col-sm-8">
                                            <select id="cmbEstado" disabled="disabled" class="form-control">
                                                <option value="0">--Seleccione Estado --  </option>
                                                <option value="1" selected>Activo</option>
                                                <option value="2">Inactivo</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtCorreo" class="col-sm-4 col-form-label">Correo</label>
                                        <div class="col-sm-8">
                                            <input type="text" class="form-control" style="width: 100% !important;" id="txtCorreo" placeholder="Correo">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="txtTelefono" class="col-sm-4 col-form-label">Telefono</label>
                                        <div class="col-sm-8">
                                            <input type="text" class="form-control" style="width: 100% !important;" id="txtTelefono" placeholder="Telefono">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" id="btnActualizarEmpleado" class="btn botones btn-primary">Actualizar</button>
                        <button type="button" id="btnGuardarEmpleado" class="btn botones btn-primary">Guardar</button>
                        <button type="button" class="btn botones btn-danger" data-dismiss="modal">Salir</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="padding-left: 50px; padding-right: 50px;">
            <table id="TablaEmpleados" class="table" style="width: 100% !important;">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">EmployeeId</th>
                        <th style="display:none;" scope="col">IdTipoIdentificacion</th>
                        <th scope="col">TipoIdentificacion</th>
                        <th scope="col">Identificacion</th>
                        <th scope="col">Nombres</th>
                        <th scope="col">Apellidos</th>
                        <th style="display:none;" scope="col">CargoId</th>
                        <th scope="col">Cargo</th>
                        <th scope="col">Correo</th>
                        <th scope="col">Telefono</th>
                    </tr>
                </thead>
                <tbody id="tblBody">
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
