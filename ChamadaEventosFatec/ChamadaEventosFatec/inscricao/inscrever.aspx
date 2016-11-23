<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscrever.aspx.cs" Inherits="ChamadaEventosFatec.inscricao.inscrever" %>

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
    <form id="formInscricao" runat="server" class="container">

        <div class="jumbotron">
            <h1>Formulario de inscricao</h1>
            <h3>Bem-vindo aluno!</h3>
        </div>
       
        
        <div class="form-group">
            
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
                <asp:DropDownList runat="server" CssClass="selectpicker show-tick" data-live-search="true" ID="dropPalestra" multiple="true"></asp:DropDownList>
                    
                <asp:RequiredFieldValidator ID="rfvPalestra" runat="server" ControlToValidate="dropPalestra" ErrorMessage="Campo obrigatório!" CssClass="label label-danger"></asp:RequiredFieldValidator>
            </div>
        
        
            <!-- Materia -->
            <div class="form-group">
                <asp:Label runat="server">Materias</asp:Label><br />
                <asp:DropDownList runat="server" CssClass="selectpicker show-tick" data-live-search="true" ID="dropMateria"  multiple="true"></asp:DropDownList>
                    
                <asp:RequiredFieldValidator ID="rfvMateria" runat="server" ControlToValidate="dropMateria" ErrorMessage="Campo obrigatório!" CssClass="label label-danger"></asp:RequiredFieldValidator>
            </div>
        </div>
        
        

        <!-- Inscricao -->
        <asp:Button ID="btnInscrever" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Inscrever" />

    </form>

    
    <script type="text/javascript">
            $(document).ready(function() {  
                $(".selectpicker").selectpicker();
            });
    </script>
</body>
</html>
