<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CATALOGO_WEB.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row mt-2">


        <div class="col-5">
            <h2>Creá tu perfil</h2>
            <div class=" form-floating mb-3">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <label for="txtEmail" class="form-label">Email</label>
                <div>
                    <asp:RegularExpressionValidator ID="reValidator" CssClass="text-danger" ErrorMessage="Solo formato E-mail" ControlToValidate="txtEmail" Visible="false" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
                </div>
                <asp:RequiredFieldValidator ID="requiredValidator" CssClass="text-danger" ErrorMessage="Debe ingresar un E-mail" ControlToValidate="txtEmail" Visible="false" runat="server" />
            </div>
            <div class=" form-floating mb-3">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
                <label for="txtPassword" class="form-label">Password</label>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtPassword" runat="server" />
            </div>
            <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>

        </div>

           
    </div>
</asp:Content>
