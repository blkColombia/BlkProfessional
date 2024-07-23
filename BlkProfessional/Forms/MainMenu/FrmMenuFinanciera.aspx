<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMenuFinanciera.aspx.cs" Inherits="BlkProfessional.Forms.MainMenu.FrmMenuFinanciera" %>
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
       <asp:LinkButton runat="server" ID="lnkMenu" OnClick="lnkMenu_Click" ><h5 style="padding:10px;text-align: left;color:orange; font-weight:bold; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">Menu Principal </h5></asp:LinkButton>
    </div>

    <div class="grid-container">
        <div class="grid-item">
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/Transporte.png" />
                         <asp:LinkButton runat="server" ID="lnkInformeTolva" OnClick="lnkInformeTolvas_Click"><p class="txt_user">Informe Tolvas</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo Financiero</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Informe Tolvas</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a las tolvas de bulkmatic.</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/sac2.png" />
                         <asp:LinkButton runat="server" ID="lnkWeekly" OnClick="lnkWeekly_Click"><p class="txt_user">Weekly</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo Financiero</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Informe de Ingresos </h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a los ingresos de bulkmatic.</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item" >
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/OperacionesBulkmatic.jpg" />
                            <asp:LinkButton runat="server" ID="lnkInventario" OnClick="lnkInventario_Click"><p class="txt_user">Inventarios</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Informe de Inventarios </h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a los Inventarios de Bulkmatic.</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item" >
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/gestionFinanciera.jpg" />
                        <asp:LinkButton runat="server" ID="lnkCierreBarranca" OnClick="lnkCierreBarranca_Click"><p class="txt_user">Cierre Ecopetrol</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Cierre Ecopetrol</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a la gestion financiera de bulkmatic</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class" >
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/Transporte.png" />
                       <asp:LinkButton runat="server" ID="lnkCedisTerceros" OnClick="lnkCedisTerceros_Click"><p class="txt_user">Cierre Cedis Terceros</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo Principal</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Cierre Terceros</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente a las preliquidaciones de los cedis terceros.</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>

        </div>
        <div class="grid-item">
            <div class="delete_class">
                <div class="card_main">
                    <div class="post_header">
                        <img class="card_image" src="../../Img/Tecnologia.png" />
                          <asp:LinkButton runat="server" ID="lnkCierreCartagena" OnClick="lnkCierreCartagena_Click"><p class="txt_user">Cierre Cartagena</p></asp:linkbutton>
                        <p class="txt_user_description">Modulo</p>
                    </div>
                    <div class="card_content">
                        <h1 class="txt_title">Modulo Cierre Cartagena</h1>
                        <p class="txt_article">En este modulo encontraras todo lo referente al cierre de cartagena</p>
                    </div>
                    <div class="box"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
