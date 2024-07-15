<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="CATALOGO_WEB.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Lista de articulos</h1>
    <h2>Zona Administracion</h2>

    <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-dark table-bordered" >

        <Columns>

            <asp:BoundField HeaderText="Código" DataField="CodigoArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />


        </Columns>


    </asp:GridView>

    <a href="Formulario.aspx" class="btn btn-primary">Agregar</a>


</asp:Content>
