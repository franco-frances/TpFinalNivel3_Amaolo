<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="CATALOGO_WEB.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />

    <h1 class="text-center">Formulario</h1>

    <div class="row">
        <div class="col-6">


            <asp:Panel DefaultButton="btnAceptar" runat="server">
                <div class="form-floating mb-3">

                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" />
                    <label for="txtCodigo">Código</label>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese codigo" ControlToValidate="txtCodigo" runat="server" />
                </div>
            </asp:Panel>

            <asp:Panel DefaultButton="btnAceptar" runat="server">
                <div class="form-floating mb-3">

                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                    <label for="txtNombre">Nombre</label>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese Nombre" ControlToValidate="txtNombre" runat="server" />
                </div>
            </asp:Panel>

            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="mb-3">

                <label for="ddlCategoria" class="form-label">Categoria</label>

                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select">
                </asp:DropDownList>

            </div>

            <asp:Panel DefaultButton="btnAceptar" runat="server">
                <div class="form-floating mb-3">


                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
                    <label for="txtPrecio">Precio</label>
                    <asp:RequiredFieldValidator ID="requiredValidator" CssClass="text-danger" ErrorMessage="Ingrese un precio" ControlToValidate="txtPrecio" Visible="true" runat="server" />
                    <asp:RegularExpressionValidator ID="reValidator" CssClass="text-danger" ErrorMessage="Ingrese solo números" ControlToValidate="txtPrecio" ValidationExpression="^[0-9]+$" Visible="false" runat="server" />

                </div>
            </asp:Panel>





            <asp:Button Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-success mb-3" runat="server" ID="btnAceptar" />



            <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                <ContentTemplate>

                    <%if (Request.QueryString["Id"] != null)
                        { %>


                    <asp:Button Text="Eliminar" OnClick="btnEliminar_Click" runat="server" ID="btnEliminar" CssClass="btn btn-danger" />

                    <% }
                        else
                        {%>

                    <a href="Lista.aspx" class="btn btn-outline-primary">Cancelar</a>


                    <%} %>




                    <% if (confirmarEliminacion)
                        {%>

                    <div class="row">
                        <div class="col-6">
                            <asp:CheckBox runat="server" ID="chkConfirmar"></asp:CheckBox>
                            <asp:Label CssClass="form-control-sm" Text="Confirmar Elimanacion" runat="server" />
                            <asp:Button runat="server" Text="Eliminar" ID="btnConfirmar" CssClass="btn btn-outline-danger" OnClick="btnConfirmar_Click"></asp:Button>

                        </div>

                    </div>


                    <%} %>
                </ContentTemplate>


            </asp:UpdatePanel>



            <br />
            <br />

        </div>

        <div class="col-6">
            <div class="form-floating mb-3">
                <asp:TextBox ID="txtDescripción" CssClass="form-control" TextMode="MultiLine" runat="server" />
                <label for="txtDescripción">Descripción</label>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Ingrese Descripcion" ControlToValidate="txtDescripción" runat="server" />
            </div>

            <asp:UpdatePanel ID="upDatePanel1" runat="server">
                <ContentTemplate>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtUrlImagen" CssClass="form-control" runat="server" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true" />
                        <label for="urlImagen">URL imagen</label>
                    </div>

                    <asp:Image ImageUrl="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png" runat="server" ID="imgArticulo" Width="60%" CssClass="img-fluid rounded" />

                </ContentTemplate>
            </asp:UpdatePanel>


        </div>


    </div>
</asp:Content>
