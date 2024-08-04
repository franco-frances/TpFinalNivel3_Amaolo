<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CATALOGO_WEB.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .custom-avatar {
            width: 200px; /* Ajusta el ancho según sea necesario */
            height: 150px; /* Ajusta la altura según sea necesario */
            object-fit: cover; /* Asegura que la imagen se recorte y escale correctamente */
            border-radius: 15px; /* Bordes redondeados */
            margin-left: 6px; /* Margen izquierdo según tu requerimiento */


        }

        .validacion{
            color:red;
            font-size:12px;
             
        }
    </style>

    

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager1" runat="server" />
    <h1>Mi perfil</h1>

    <div class="row">
        <div class="col-md-5">
            <div class="mb-3">

                <label class="form-label">Email</label>
                
                <asp:Panel DefaultButton="btnGuardar" runat="server">

                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                    <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="Solo Formato E-mail" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />

                </asp:Panel>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                
                <asp:Panel DefaultButton="btnGuardar" runat="server">
                    
                    <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                    

                </asp:Panel>


            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:Panel DefaultButton="btnGuardar" runat="server">
                    
                    <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
                    </asp:TextBox>
                
                </asp:Panel>

            </div>


        </div>
        <div class="col-md-5">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>


            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-thumbnail mb-2 img-fluid custom-avatar rounded-5" />

        </div>

    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" runat="server"   OnClick="btnGuardar_Click" />
            <a href="/">Regresar</a>
        </div>
    </div>


</asp:Content>
