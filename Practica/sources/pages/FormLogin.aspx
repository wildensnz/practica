<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="Practica.sources.pages.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
    <title>Inicio de sesion</title>
</head>
<body>
    <br />
    <br />
    <br />

    <form id="FormLogin" runat="server" class="container d-flex justify-content-center align-items-center">
        <div class="col-5">
            <br />
            <div class="form-control card card-body align-items-center">
                <div class="modal-title align-content-center h3">
                <asp:Label runat="server" Text="Inicio de sesion" Font-Size="Larger"></asp:Label>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Usuario" ID="tbUsuario"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Contraseña" ID="tbContra" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:Button runat="server" CssClass="form-control btn btn-dark" Text="Log In" OnClick="Iniciar"></asp:Button>
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblError" CssClass="alert-danger"></asp:Label>
                <br />
                <asp:Label runat="server" Text="¿No tienes cuenta?, Registrate"></asp:Label>
                <asp:LinkButton runat="server" Text="Aqui" OnClick="Registrarse"></asp:LinkButton>
            </div>
        </div>
            
        </div>
    </form>
</body>
</html>
