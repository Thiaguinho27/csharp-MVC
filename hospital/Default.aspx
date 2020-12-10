<%@ Page Title="Hospital" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hospital._Default" %>
<%@ import Namespace="hospital.Model.Entidades" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html>

        <head >
            <title>
                hospital
            </title>

            <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
            <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
            <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>


            <meta charset="utf-8"/>
            <link href="estilo.css" rel="stylesheet" />
        </head>
        <body>

            <!--
             <div id="colecao-links">
                     <div class="links">
                        <a href="viewPacientes.aspx">Visualizar Pacientes</a>
                    </div>
                    <div class="links">
                        <a href="cadastrarEquipamento.aspx">Cadastro de equipamento
                    </div>
                    <div class="links">
                        <a href="cadastrarDoenca.aspx">Cadastro de Doencas</a>
                    </div>
                    <div class="links">
                        <a href="cadastrarPaciente.aspx">Cadastro de Pacientes</a>
                    </div>
                </div>
                   -->

                <nav class="navbar navbar-expand-lg navbar-light bg-light">
                  <a class="navbar-brand" href="Default">Hospital</a>
                  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                  </button>
                  <div class="collapse navbar-collapse" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                      <li class="nav-item active">
                        <a class="nav-link" href="Default">Home<span class="sr-only">(current)</span></a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="viewPacientes">Pacientes</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="viewDoencas">Doenças</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="viewEquipamentos">Equipamentos</a>
                      </li>
                      
                    </ul>
                  </div>
                </nav>

                 <br />
            <center>
               
                <div>
                    <h1>Sistema de Gerenciamento de Equipamentos</h1>
                </div>
               <div style="width:600px;background-color:gray;">
                    Este Sistema fio realizado para a disciplina de C# com o intuito de criar um projeto ASP NET utilizando arquitetura MVC nele vemos a relação entre um certo número de pacientes que tem uma certa doença, e necessitam de um certo equipamento
                      para serem tratados (com quantidade limitada). 
                </div>
                
                <div style="width:600px;background-color:gray;">

                    

                </div>
            </center>
        </body>

    </html>
   

</asp:Content>
