<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CATALOGO_WEB.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>


            <div class="row ">
                
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" ID="lblFiltrar" runat="server" CssClass="font-sans-serif text-dark fw-bold mb-2 fs-4" />
                        <asp:TextBox runat="server" ID="txtFiltrar" OnTextChanged="txtFiltrar_TextChanged" CssClass="form-control" AutoPostBack="true" />
                    </div>
                </div>

                <div class="col-6 " style="display: flex; flex-direction: column; justify-content: flex-end;">

                    <div class="mb-3">
                        <asp:CheckBox runat="server" CssClass="" AutoPostBack="true" ID="chkFiltroAvanzado" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" />
                        <asp:Label CssClass="form-control-sm fw-bold" Text="Filtro Avanzado" runat="server" />
                    </div>

                </div>

            </div>



            <%if (chkFiltroAvanzado.Checked)
                { %>
            <div class="row">

                <div class="col-3">
                    <div class="mb-3">

                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoria" />
                            <asp:ListItem Text="Precio" />

                        </asp:DropDownList>

                    </div>

                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <asp:DropDownList ID="ddlCriterio" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="col-3">
                    <div class="mb-3">

                        <!-- Panel para que cuando aprieto enter en un text box no se vaya para el evento Salir-->
                        <asp:Panel DefaultButton="btnBuscar" runat="server">
                            <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass=" form-control" />
                            <asp:RegularExpressionValidator ID="reValidator" CssClass="text-danger" ErrorMessage="Ingrese solo números" ControlToValidate="txtFiltroAvanzado" ValidationExpression="^[0-9]+$" Enabled="false" runat="server" />
                        </asp:Panel>
                    </div>

                </div>

            </div>

            <div class="row">
                <div class="mb-3">
                    <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" runat="server" />
                    <asp:Button Text="Limpiar Filtro" ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass=" btn btn-danger" CausesValidation="false" runat="server" />

                </div>
            </div>

            <%} %>


            <h1 id="notFound" runat="server" visible="false">No se encontraron coincidencias con tu busqueda</h1>





            <div class="row row-cols-1 row-cols-md-3 g-4">

                <asp:Repeater ID="Repetidor" runat="server">

                    <ItemTemplate>
                        <div class="col">
                            <div class="background">
                                <div class="centering">
                                    <div class="articles">
                                        <article>
                                            <figure>
                                                <img src="<%#Eval("UrlImagen") %>"
                                                    alt="Preview">
                                            </figure>
                                            <div class="article-preview">
                                                <h2><%#Eval("Nombre") %></h2>
                                                <p class="fw-semibold">
                                                    <asp:Label Text="Precio" runat="server" />
                                                    $ <%#Eval("Precio") %>
                                                    <div>
                                                        <button type="button" class="btn btn-info mb-2" data-bs-toggle="modal" data-bs-target='<%# "#modal" + Eval("Id") %>'>
                                                            Ver Detalles
                                                        </button>

                                                    </div>
                                                    </a>
                                            <div class="modal fade" id='<%# "modal" + Eval("Id") %>' tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <h1 class="modal-title fs-5" id="exampleModalLabel">Detalles</h1>
                                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                        </div>
                                                        <div class="modal-body">

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Código:" runat="server" />
                                                                <%#Eval("CodigoArticulo") %>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Nombre:" runat="server" />
                                                                <%#Eval("Nombre") %>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Descripcion:" runat="server" />
                                                                <%#Eval("Descripcion") %>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Marca:" runat="server" />
                                                                <%#Eval("Marca") %>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Categoria:" runat="server" />
                                                                <%#Eval("Categoria") %>
                                                            </div>

                                                            <div class="mb-2">
                                                                <asp:Label CssClass="fw-semibold" Text="Precio:" runat="server" />
                                                                $<%#Eval("Precio") %>
                                                            </div>


                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>

                                                            <asp:Button Text="Agregar a Favoritos" ID="btnFavorito" CssClass="btn btn-outline-primary" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnFavorito_Click" runat="server" Visible='<%# !((bool)Eval("EsFavorito")) %>' />
                                                            <asp:Label Text="Agregado" ID="lblAgregado" CssClass="form-control text-bg-success font-monospace" Visible='<%# (bool)Eval("EsFavorito") %>' runat="server" />

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </p>
                                            </div>
                                        </article>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </ItemTemplate>


                </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>



    </div>
</asp:Content>
