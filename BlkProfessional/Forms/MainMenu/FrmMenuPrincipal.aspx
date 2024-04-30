<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMenuPrincipal.aspx.cs" Inherits="BlkProfessional.Forms.MainMenu.FrmMenuPrincipal" %>

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
               /*font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;*/
            /* background-color: rgba(255, 255, 255, 0.8);*/
          /*  border: 1px solid;
            border-radius: 10px;*/
           /* padding: 20px;*/
         /*   font-size: 30px;
            text-align: center;*/
        }

 /*       .botones {
            width: 100%;
            height: 100%;
            font-size: 14px !important;
            border-radius: 10px;
            background-image: url(../Img/Lider.png);
        }*/

      /*  p {
            font-size: 20px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
        }*/



        .txt_article {
            overflow: hidden;
            text-overflow: ellipsis;
            display: -webkit-box;
            -webkit-box-orient: vertical;
            line-height: 1.4em; /* fallback */
            max-height: 4.2em; /* fallback */
            -webkit-line-clamp: 3; /* number of lines to show */
        }

        .card_main {
            width: 100%;
        }


        .delete_class {
            /*width: 18em;*/
        }

        .txt_user {
            margin: 18px 16px 8px 16px;
            padding-top: 16px;
            font-size: 120%;
            font-weight:bold;
        }

        .txt_user_description {
            margin: 0px 16px 0px 16px;
            padding-bottom: 16px;
            font-size: 80%;
        }

        .txt_title {
            font-size: 1.6em;
        }

        .txt_post_type {
            color: #ffffff;
            margin: 0px;
            font-family: roboto;
            font-weight: 400;
            padding: 8px 16px;
        }

        .post_header {
        /*    color: #ffffff;*/
            color:orange;
            position: relative;
            margin-top: 0px;
            width: 100%;
            box-shadow: 0px 4px 8px rgba(0,0,0,.4);
            border-radius: 8px 8px 0px 0px;
            height: auto;
            background-color: #ddd;
        }


        .card_image {
            margin-right: 16px;
            position: absolute;
            right: 0;
            z-index: 1;
            top: -1em;
            width: 36%;
            border-radius: 50%;
            box-shadow: 0px 4px 6px rgba(0,0,0,.5);
        }

        .card_content {
            position: relative;
            background: #ffffff;
            margin: 0px;
            border-radius: 0px 0px 8px 8px;
            box-shadow: 0 2px 16px rgba(0, 0, 0, 0.2);
            max-width: 100%;
            height: auto;
            padding: 4px 16px;
            -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
            transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
        }

            /* Pre-render the bigger shadow, but hide it */
            .card_content::after {
                box-shadow: 0 5px 15px rgba(0, 0, 0, .4);
                opacity: 0;
                height: 100%;
                width: 100%;
                left: 0;
                top: 0;
                position: absolute;
                content: "";
                border-radius: 8px;
                -webkit-transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
                transition: all 0.6s cubic-bezier(0.165, 0.84, 0.44, 1);
            }

            /* Transition to showing the bigger shadow on hover */
            .card_content:hover::after, .post_header:hover + .card_content::after {
                opacity: 1;
            }
    </style>

    <div class="col">
        <h5 style="padding: 20px; text-align: left; color: orange; font-weight: bold; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal</h5>
    </div>

    <div class="grid-container">
        <div class="grid-item">
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/ggghhh.jpg" />
                        <asp:LinkButton runat="server" ID="lnkGestionHumana" OnClick="lnkGestionHumana_Click"><p class="txt_user">Gestion Humana</p></asp:LinkButton>
                        
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content"> 
                        <h1 class="txt_title">Modulo Gestion Humana</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la gestion humana de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item" >
            <div class="delete_class" >
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/sac2.png" />
                         <asp:LinkButton runat="server" ID="lnkSAC" OnClick="lnkSAC_Click"><p class="txt_user">Servicio al Cliente</p></asp:LinkButton>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Servicio al cliente</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente SAC de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item" >
            <div class="delete_class" >
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/OperacionesBulkmatic.jpg" />
                         <asp:LinkButton runat="server" ID="lnkOperaciones" OnClick="lnkOperaciones_Click"><p class="txt_user">Operaciones</p></asp:LinkButton>
                        
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Operaciones</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la operacion de Bulkmatic.</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/gestionFinanciera.jpg" />
                        <asp:LinkButton runat="server" ID="lnkGestionFinanciera" OnClick="lnkGestionFinanciera_Click"><p class="txt_user">Gestion Financiera</p></asp:LinkButton>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Gestion Financiera</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la gestion financiera de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class" style="display:none;">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/Transporte.png" />
                        <p class="txt_user">Transporte</p>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo de Transporte</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la gestion del proceso de transporte de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class" style="display:none;">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/Tecnologia.png" />
                        <p class="txt_user">Tecnologia</p>
                        <p class="txt_user_description">Modulo</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Gestion Tecnologica</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la gestion tecnologica de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
