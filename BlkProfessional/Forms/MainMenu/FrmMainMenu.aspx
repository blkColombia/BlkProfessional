<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMainMenu.aspx.cs" Inherits="BlkProfessional.Forms.Menu.FrmMainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .grid-container {
            display: grid;
            column-gap: 50px;
            row-gap: 50px;
            grid-template-columns: auto auto auto;
            /* background-color: #2196F3;*/
            padding: 10px;
        }

        .grid-item {
            /* background-color: rgba(255, 255, 255, 0.8);*/
            border: 1px solid orange;
            padding: 20px;
            font-size: 30px;
            text-align: center;
        }

        .botones {
            width: 100%;
            height: 100%;
            font-size: 14px !important;
            border-radius: 10px;
            background-image: url(../Img/Lider.png);
        }

        p {
            font-size: 20px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
        }
    </style>
    
    
    <div class="col">
        <h5 style="padding: 30px; text-align: left; color: orange; font-weight: bold; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal</h5>
    </div>

    <div class="grid-container">
        <div class="grid-item">
            <div>
                <div style="width: 250px; height: 250px;">
                    <asp:ImageButton ID="btnTareas" OnClick="btnTareas_Click" ImageUrl="~/Img/Tareas.png" CssClass="botones" runat="server" />
                </div>
                <div>
                    <p>Mis Tareas</p>
                </div>
            </div>
        </div>
        <div class="grid-item">
            <div>
                <div style="width: 250px; height: 250px;">
                    <asp:ImageButton ID="btnLider" OnClick="btnLider_Click" ImageUrl="~/Img/Lider.png" CssClass="botones" runat="server" />
                </div>
                <div>
                    <p>Lider</p>
                </div>
            </div>
        </div>
        <div class="grid-item">
            <div>
                <div style="width: 250px; height: 250px;">
                    <asp:ImageButton ID="btnEstadistica" OnClick="btnEstadistica_Click" ImageUrl="~/Img/Estadistica.png" CssClass="botones" runat="server" />
                </div>
                <div>
                    <p>Informes</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
