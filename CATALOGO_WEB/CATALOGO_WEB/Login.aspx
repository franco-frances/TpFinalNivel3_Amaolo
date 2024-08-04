<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CATALOGO_WEB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function validar() {
            const txtUser = document.getElementById("txtUser");
            const txtPass = document.getElementById("txtPass");
            var valido = true;

            if (txtUser.value == "") {
                txtUser.classList.add("is-invalid");
                valido = false;
            } else {
                txtUser.classList.remove("is-invalid");
            }

            if (txtPass.value == "") {
                txtPass.classList.add("is-invalid");
                valido = false;
            } else {
                txtPass.classList.remove("is-invalid");
            }

            return valido;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row justify-content-center">
        <asp:Image ID="imgAvatar" CssClass="rounded-circle img-fluid d-inline-block mt-2" Style="height: 100px; width: 120px; margin-left: 6px;" runat="server" />
    </div>

    <div class="row justify-content-center ">
        <div class="col-4">
            <h2>Login</h2>
            <div class="form-floating mb-3">
                
                <asp:TextBox ClientIDMode="Static" runat="server" CssClass="form-control" ID="txtUser" />
                <label for="txtUser">Usuario</label>
                <div class="invalid-feedback">El campo de usuario es obligatorio.</div>
            </div>
            <div class="form-floating mb-3">
                
                <asp:TextBox ClientIDMode="Static" runat="server" CssClass="form-control" ID="txtPass" TextMode="Password" />
                <label for="txtPass">Contraseña</label>
                <div class="invalid-feedback">El campo de contraseña es obligatorio.</div>
            </div>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnLogin" OnClientClick="return validar()" OnClick="btnLogin_Click" runat="server" />
            <a href="/">Cancelar</a>

        </div>
    </div>

</asp:Content>
