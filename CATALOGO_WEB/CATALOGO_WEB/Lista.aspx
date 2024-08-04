<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster-Catalogo.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="CATALOGO_WEB.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptManager1" runat="server" />

    <h1>Lista de articulos</h1>
    <h2>Zona Administracion</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" ID="lblFiltrar" runat="server" CssClass="font-monospace" />
                <asp:TextBox runat="server" ID="txtFiltrar" OnTextChanged="txtFiltrar_TextChanged" CssClass="form-control" AutoPostBack="true" />
            </div>
        </div>
            
            <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">

                <div class="mb-3">
                    <asp:CheckBox  runat="server" CssClass="" AutoPostBack="true" ID="chkFiltroAvanzado" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" />
                    <asp:Label CssClass="form-control-sm"  Text="Filtro Avanzado" runat="server" />
                </div>

            </div>
    </div>

    <%if (chkFiltroAvanzado.Checked)
        { %>
    <div class="row">

        <div class="col-3">
            <div class="mb-3">

                <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-select" AutoPostBack="true"  OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
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
                
                <!-- Panel para que cuando aprieto enter en u text box no se vaya para el evento Salir-->
                <asp:Panel DefaultButton="btnBuscar" runat="server">
                <asp:TextBox ID="txtFiltroAvanzado" runat="server" CssClass=" form-control"   />
                    <asp:RegularExpressionValidator ID="reValidator" CssClass="text-danger" ErrorMessage="Ingrese solo números" ControlToValidate="txtFiltroAvanzado" ValidationExpression="^[0-9]+$" Enabled="false" runat="server" />
                </asp:Panel>
            </div>

        </div>

    </div>

    <div class="row">
        <div class="mb-3">
            <asp:Button Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" runat="server" />
            <asp:Button Text="Limpiar Filtro" ID="btnLimpiar"  OnClick="btnLimpiar_Click"  CssClass=" btn btn-danger" CausesValidation="false" runat="server" />

        </div>
    </div>

    <%} %>
    
    <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-dark table-bordered" >

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

    <br />
    <br />
    <br />


</asp:Content>
