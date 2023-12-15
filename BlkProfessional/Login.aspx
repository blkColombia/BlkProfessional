<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"  Inherits="BlkProfessional.Login" %>

<!DOCTYPE html>
<!-- Representa la raíz de un documento HTML o XHTML. Todos los demás elementos deben ser descendientes de este elemento. -->
<html lang="es">

<head>
    <meta charset="utf-8">
    <title>Bulkmatic </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <meta name="author" content="Videojuegos & Desarrollo">
    <meta name="description" content="Muestra de un formulario de acceso en HTML y CSS">
    <meta name="keywords" content="Formulario Acceso, Formulario de LogIn">

    <link href="https://fonts.googleapis.com/css?family=Nunito&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Overpass&display=swap" rel="stylesheet">

    <!-- Link hacia el archivo de estilos css -->
    <link rel="stylesheet" href="Content/Login.css">

    <style type="text/css">
            
        </style>

    <script type="text/javascript">

</script>

</head>

<body>
    <div id="contenedor">
        <div id="central">
            <div id="login">
                <div class="titulo">
                    Bulkmatic
                </div>
                <form id="loginform" runat="server" >           
                    <input type="text" runat="server" id="txtLogueo"  placeholder="Usuario" required>
                    <input type="password" runat="server"  id="txtPassword" placeholder="Contraseña" name="password" required>
                <%--    <button type="submit" title="Ingresar" name="Ingresar">Login</button>--%>
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Ingresar" CssClass="btn btn-secondary" />                                    
                </form>
                <div class="pie-form">
                    <a href="#">¿Perdiste tu contraseña?</a>
                    <a href="#">¿No tienes Cuenta? Registrate</a>
                </div>
            </div>
            <div class="inferior">
                <a href="#">Volver</a>
            </div>
        </div>
    </div>
</body>
</html>
