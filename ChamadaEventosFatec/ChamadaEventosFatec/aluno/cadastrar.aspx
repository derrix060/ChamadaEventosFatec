<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadastrar.aspx.cs" Inherits="ChamadaEventosFatec.aluno.cadastrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cadastro Aluno</title>

    <!-- Bootstrap -->
    <script src="../Sources/jquery.min.js"></script>
    <link href="../Sources/bootstrap.min.css" rel="stylesheet"/>
    <script src="../Sources/bootstrap.min.js"></script>
    
</head>
<body>
    <form id="formCadastroAluno" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1>Cadastro Aluno</h1>
        </div>

        <div class="page-header">
            <h2>Formulário de inscrição</h2>
        </div>

         <!-- Matricula -->
        <div class="form-group">
            <asp:Label for="inputMatricula" runat="server">Matricula</asp:Label>
            <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" id="inputMatricula" placeholder="Digite sua matricula..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revMatricula" runat="server" ValidationExpression="\d{13}" ControlToValidate="inputMatricula" ErrorMessage="Insira uma matricula válida (13 numeros)" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>


        <!-- Email -->
        <div class="form-group">
            <asp:Label  runat="server" >Email</asp:Label>
            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" id="inputEmail" aria-describedby="emailHelp" placeholder="Digite seu email..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="inputEmail" ErrorMessage="Formato de email inválido" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>


        <!-- Nome -->
        <div class="form-group">
            <asp:Label runat="server" >Nome</asp:Label>
            <asp:TextBox runat="server" TextMode="SingleLine" CssClass="form-control" ID="inputNome" placeholder="Digite seu nome completo como ficará no certificado..."></asp:TextBox>
             <asp:RegularExpressionValidator ID="revNome" runat="server" ControlToValidate="inputNome"  ValidationExpression="^[a-zA-Z'.\s]{1,150}" Text="Digite um nome válido!" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>


        <!-- Senha -->
        <div class="form-group">
            <asp:Label runat="server">Senha</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="inputSenha" placeholder="Digite sua senha (de 5 a 15 caracteres)..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revSenha" runat="server" ControlToValidate="inputSenha" ValidationExpression="\w{5,15}" Text="Digite uma senha de 5 a 15 caracteres" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>

        <!-- Adicionar -->
        <asp:Button ID="btnCadastrarAluno" runat="server" CssClass="btn btn-primary" Text="Cadastrar" OnClick="CadastrarAluno" />
        
        
        <!-- Alertas -->
        <div class="alert alert-success alert-dismissable fade in" runat="server" id="alertSuccess" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        </div>

        <div class="alert alert-danger alert-dismissable fade in" runat="server" id="alertDanger" visible="false">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        </div>

    </div>
    </form>

</body>
</html>
