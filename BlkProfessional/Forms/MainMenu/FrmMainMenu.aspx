<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMainMenu.aspx.cs" Inherits="BlkProfessional.Forms.Menu.FrmMainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
 /*      * {
    padding: 0;
    margin: 0;
    text-decoration: none;
    box-sizing: content-box;
    border: none;
}*/

body {
   /* background-color: #b7a6a6;*/
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}

.container-panel{
    display: inline;
    justify-content: center;
    height: 100vh;
    align-items:center;   
}

.card {
    background-color: #f5f5f5;
    border-radius: 1rem;
    box-shadow: 0 1rem 1rem;
    margin-inline-end: 5%;
    overflow: hidden;
    width: 25rem;
    height: 13rem;
    display: inline-flex;
}

    .card h6 { 
        opacity: 1;
      /*  letter-spacing: 0.05rem;  */      
        align-items: center;
       color: #000000;
       text-align:center;
    }

    .card h5 {
        opacity: 10;
        /*letter-spacing: .3rem;*/
       
       
        color: #000000;
        
    }

.left-column{
    color:#a45217;
    padding: 0.02rem;
    max-width: 0.5rem;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-between;
}

.left-colum h5{
    color: #a45217;
}

.right-column{
    padding: 1rem;
    display:flex;
    flex-direction: column;
    align-items:flex-start;
    justify-content:space-between;
}
       .viviana {
       width:100%;
       display:inline-flex;
       padding: 10%;
       }

   </style>
    
    <div class="container-panel">



        <div style="margin-right:10px;">
            <div class="viviana">
                <div class="card"> 
                    <div style="width:50%">
                    <img src="../../Img/AdministradorContable.jpeg" width="90" height="90" style="float:left;margin:10%; border-radius: 50%;border: 3px solid darkblue;">                                      
                     </div>
                    <div style="width:50%;text-align:left;">
                        <h3 style="font-size:20px;padding-top:5%;">SAC</h3>
                     <h5>Servicio atencion al cliente</h5>
                        </div>
                </div>
                <br />
                    
                <div class="card">
                    <div style=" background :#f17721;">
                        <br />
                        <h5>AREA PRODUCCION</h5>
                    </div>
                    <br />
                    <img src="../../Img/Procesos.jpeg" width="80" height="80" style="float:right; border-radius: 50%;">
                    <br />
                    <div >
                        <div style="margin-left:10px" ;>
                            <h6>se dedica a transformar los recursos o insumos en el producto final que llegará al clienteS</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div style="margin-right:10px;">
            <div class="span-10">
                <div class="card">
                    <div style=" background :#f17721;">
                        <br />
                        <h5>AREA INFRASTRUCTURA</h5>
                    </div>
                    <br />
                    <img src="../../Img/Infraestructura.jpeg" width="80" height="80" style="float:right; border-radius: 50%;">
                    <br />
                    <div class="span-20">
                        <div style="margin-left:10px" ;>
                            <h6>la gestión de los servicios empresariales de TI y entornos de TI.</h6>
                        </div>
                    </div>
                </div>
                <br />
                <div class="card">
                    <div style=" background :#f17721;">
                        <br />
                        <h5>AREA DESARROLLO</h5>
                    </div>
                    <br />
                    <img src="../../Img/Desarrollo.jpeg" width="80" height="80" style="float:right; border-radius: 50%;">
                    <br />
                    <div class="span-20">
                        <div style="margin-left:10px" ;>
                            <h6>Se encarga de la gestión de los servicios empresariales de TI y entornos de TI.</h6>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
