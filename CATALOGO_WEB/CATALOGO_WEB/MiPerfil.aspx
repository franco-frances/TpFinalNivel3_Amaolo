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
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> Mi perfil</h1>

    <div class="row">
        <div class="col-md-5">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />

            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
                </asp:TextBox>

            </div>
            

        </div>
        <div class="col-md-5">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            
            
            <asp:Image ID="imgNuevoPerfil"  ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" runat="server" CssClass="img-thumbnail mb-2 img-fluid custom-avatar"  />

        </div>

    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary"  ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
            <a href="/">Regresar</a>
        </div>
    </div>


</asp:Content>
