<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CATALOGO_WEB.Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager" runat="server" />

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



    </div>
</asp:Content>
