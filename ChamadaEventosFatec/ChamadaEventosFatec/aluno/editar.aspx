<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar.aspx.cs" Inherits="ChamadaEventosFatec.aluno.editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editar Aluno</title>

    <!-- Bootstrap -->
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet"/>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
</head>
<body>
    <form id="formEditarAluno" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h1>Editar Aluno</h1>
        </div>

        <div class="page-header">
            <h2>Formulário de inscrição</h2>
        </div>

         <!-- Matricula -->
        <div class="form-group">
            <asp:Label for="inputMatricula" runat="server" Enabled="false">Matricula</asp:Label>
            <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" id="inputMatricula" placeholder="Digite sua matricula..." Enabled="false" Text="2040481423032"></asp:TextBox>
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
            <asp:Label runat="server">Senha Antiga</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="inputSenhaAntiga" placeholder="Digite sua senha antiga..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revSenhaAntiga" runat="server" ControlToValidate="inputSenhaAntiga" ValidationExpression="\w{5,15}" Text="Digite uma senha de 5 a 15 caracteres" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Senha Nova</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="inputSenhaNova1" placeholder="Digite uma nova senha (de 5 a 15 caracteres)..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revSenhaNova1" runat="server" ControlToValidate="inputSenhaNova1" ValidationExpression="\w{5,15}" Text="Digite uma senha de 5 a 15 caracteres" CssClass="label label-danger"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server">Senha Nova</asp:Label>
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="inputSenhaNova2" placeholder="Digite novamente uma nova senha (de 5 a 15 caracteres)..."></asp:TextBox>
            <asp:CompareValidator ID="compareSenha" runat="server" CssClass="alert alert-danger" ControlToCompare="inputSenhaNova1" ControlToValidate="inputSenhaNova2" Operator="Equal" ErrorMessage="Novas senhas não são iguais!"></asp:CompareValidator>
        </div>

        <!-- Adicionar -->
        <asp:Button ID="btnEditarAluno" runat="server" CssClass="btn btn-primary" Text="Salvar" OnClick="EditarAluno" />
        <asp:Button ID="btnExcluirAluno" runat="server" CssClass="btn btn-danger" Text="Excluir" OnClick="ExcluirAluno" />
        
        
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
