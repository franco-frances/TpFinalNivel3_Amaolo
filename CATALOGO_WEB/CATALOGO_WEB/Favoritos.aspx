<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CATALOGO_WEB.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />


    <h1>Tus Favoritos</h1>

    <%if (lista.Count == 0)
        { %>

    <h3>No tienes articulos agregados a favoritos</h3>

    <% } %>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
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
                                                    <asp:Button Text="Eliminar de Favoritos" ID="btnEliminarFavorito" CssClass="btn btn-outline-danger " CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnEliminarFavorito_Click" runat="server" />
                                                    <asp:Label Text="Eliminado" ID="lblEliminado" CssClass="btn btn-warning font-monospace" Visible="false" runat="server" />
                                                </p>
                                            </div>
                                        </article>
                                    </div>
                                </div>
                            </div>

                        </div>



                    </ItemTemplate>



                </asp:Repeater>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
