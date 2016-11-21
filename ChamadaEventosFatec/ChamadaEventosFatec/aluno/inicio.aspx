<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ChamadaEventosFatec.aluno.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Login -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../App_Themes/alunoInicio.css" rel="stylesheet" />

    <title>Login - Chamada Fatec</title>

    <!-- Bootstrap -->
    <script src="../Sources/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../Sources/bootstrap.min.js"></script>
</head>
<body>
    <div class="intro-header">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="intro-message">
                        <h1>Chamada Fatec</h1>
                        <h3>Área do Aluno</h3>
                        <hr class="intro-divider"/>
                        <ul class="list-inline intro-social-buttons">
                            <li>
                                <a href="/aluno/editar.aspx" class="btn btn-primary btn-lg btn-huge"><i class="glyphicon glyphicon-pencil"></i> Editar dados</a>
                            </li>
                            <li>
                                <a href="/inscricao/inscrever.aspx" class="btn btn-success btn-lg btn-huge"><i class="glyphicon glyphicon-check"></i> Inscrever-se</a>
                            </li>
                            <li>
                                <a href="#" class="btn btn-warning btn-lg btn-huge"><i class="glyphicon glyphicon-list-alt"></i> Ver inscrições</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">

                    <p class="copyright text-muted small">Copyright © Mário Aprá 2016. All Rights Reserved</p>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
