﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscrever.aspx.cs" Inherits="ChamadaEventosFatec.inscricao.inscrever" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Inscricao</title>
    <!-- Bootstrap -->
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet"/>
    <script src="../Scripts/bootstrap.min.js"></script>
    
    <!-- Bootstrap Select -->
    <link href="../Content/bootstrap-select.min.css" rel="stylesheet"/>
    <script src="../Scripts/bootstrap-select.min.js"></script>

</head>
<body>
    <form id="formInscricao" runat="server">
    <div class="container">

        <div class="jumbotron">
            <h1>Formulario de inscricao</h1>
        </div>
       
            
            <!-- Periodo -->
            <div class="form-group">
                <asp:Label runat="server" for="dropPeriodo">Periodo</asp:Label><br />
                <asp:DropDownList runat="server" CssClass="selectpicker" ID="dropPeriodo" AutoPostBack="true" OnSelectedIndexChanged="Refresh_Palestra_Materia"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="rfvPeriodo" runat="server" ControlToValidate="dropPeriodo" ErrorMessage="Campo obrigatório!" CssClass="label label-danger"></asp:RequiredFieldValidator>
            </div>


            <!-- Dia -->
            <div class="form-group">
                <asp:Label runat="server">Dias</asp:Label><br />
                <asp:DropDownList runat="server" CssClass="selectpicker" ID="dropDia" AutoPostBack="true" OnSelectedIndexChanged="Refresh_Palestra_Materia"></asp:DropDownList>
                    
                <asp:RequiredFieldValidator ID="rfvDia" runat="server" ControlToValidate="dropDia" ErrorMessage="Campo obrigatório!" CssClass="label label-danger"></asp:RequiredFieldValidator>
            </div>

            <!-- Palestra -->
            <div class="form-group">
                <asp:Label runat="server">Palestras</asp:Label><br />
                <asp:ListBox runat="server" CssClass="selectpicker show-tick" data-live-search="true" ID="listPalestra" multiple="true" SelectionMode="Multiple"></asp:ListBox>
            </div>
        
        
            <!-- Materia -->
            <div class="form-group">
                <asp:Label runat="server">Materias</asp:Label><br />
                <asp:ListBox runat="server" CssClass="selectpicker show-tick" data-live-search="true" ID="listMateria" SelectionMode="Multiple"></asp:ListBox>
            </div>
        
        

        <!-- Inscricao -->
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="progress">
                        <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:100%">
                          Processando...
                        </div>
                      </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnInscrever" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Inscrever" />
                </ContentTemplate>
            </asp:UpdatePanel>
        

        <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-default" Text="Voltar" OnClick="Voltar" />

       

        <!-- Alertas -->
        <div class="alert alert-success alert-dismissable fade in" runat="server" id="alertSuccess" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Parabéns!</strong> Inscrição realizada com sucesso!
        </div>

        <div class="alert alert-danger alert-dismissable fade in" runat="server" id="alertDanger" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Ops... </strong> Algo aconteceu errado, tente novamente mais tarde!
        </div>

    
    <script type="text/javascript">
            $(document).ready(function() {  
                $(".selectpicker").selectpicker();
            });
    </script>

    </div>
    </form>

    
    </body>
</html>
