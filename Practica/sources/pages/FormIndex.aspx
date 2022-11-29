<%@ Page Title="" Language="C#" MasterPageFile="~/sources/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormIndex.aspx.cs" Inherits="Practica.sources.pages.FormIndex" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <formview>
        <br />
        <div class ="mx-auto" style="width:500px">
            <h2>Listado de productos</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="btnCrear" CssClass="btn btn-success form-control-sm" Text="Crear producto"  OnClick="btnCrear_Click"/>

                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <asp:GridView runat="server" ID="gvUsuarios" class="table table-striped table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Leer" CssClass="btn btn form-control-sm btn-info" ID="btnLeer" OnClick="btnLeer_Click"/>
                                <asp:Button runat="server" Text="Actualizar" CssClass="btn btn form-control-sm btn-warning" ID="btnActualizar" OnClick="btnActualizar_Click"/>
                                <asp:Button runat="server" Text="Eliminar" CssClass="btn btn form-control-sm btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </formview>
</asp:Content>
