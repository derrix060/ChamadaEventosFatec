﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ChamadaEventosFatec.aluno.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Mobile First -->
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <!-- Login -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="../Sources/login.css" rel="stylesheet"/>

    <title>Login - Chamada Fatec</title>

    <!-- Bootstrap -->
    <script src="../Sources/jquery.min.js"></script>
    <link href="../Sources/bootstrap.min.css" rel="stylesheet"/>
    <script src="../Sources/bootstrap.min.js"></script>

</head>
<body>
    <div class="container">
        <form id="formLogin" runat="server" class="form-signin">
            <h2 class="form-signin-heading">Bem-vindo Aluno!</h2>
            
            <!-- Email -->
            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" id="inputEmail" aria-describedby="emailHelp" placeholder="Digite seu email..."></asp:TextBox>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="inputEmail" ErrorMessage="Formato de email inválido" CssClass="label label-danger"></asp:RegularExpressionValidator>
        
            <!-- Senha -->
            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="inputSenha" placeholder="Digite sua senha..."></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="inputSenha" ErrorMessage="Digite uma senha!" CssClass="label label-danger"></asp:RequiredFieldValidator>

            <!-- Botão -->
            <div class="row">
                <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" Text="Entrar" OnClick="Logar" />
            </div>
            <!-- Aviso -->
            
                <asp:Label runat="server" CssClass="label label-danger" ID="alertSenha" Visible="false"></asp:Label>
            
        </form>
    </div>
    
</body>
</html>