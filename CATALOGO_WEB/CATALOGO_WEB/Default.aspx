<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CATALOGO_WEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row row-cols-1 row-cols-md-3 g-4">
   
        <%foreach (Dominio.Articulo articulo in lista)
        { %>
    
    <div class="col">
    <div class="background">
        <div class="centering">
            <div class="articles">
                <article>
                    <figure>
                        <img src="<%:articulo.UrlImagen%>"
                            alt="Preview">
                    </figure>
                    <div class="article-preview">
                        <h2><%:articulo.Nombre %></h2>
                        <p>
                           <%:articulo.Descripcion %> 
                        <a href="#" class="read-more" title="Read More">Read more
                        </a>
                            <asp:Button Text="Agregar a Favoritos" ID="btnFavorito" CssClass="btn btn-outline-primary" runat="server" />
                        </p>
                    </div>
                </article>
            </div>
        </div>
    </div>
    </div>


    <%} %>
        </div>
</asp:Content>
