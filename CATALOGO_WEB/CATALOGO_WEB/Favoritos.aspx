<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CATALOGO_WEB.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />


    <h1>Tus Favoritos</h1>

    <%if (lista.Count==0) { %>
        
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
                                                <p>
                                                    <%#Eval("Descripcion") %>
                                                    <a href="#" class="read-more" title="Read More">Read more
                                                    </a>

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
