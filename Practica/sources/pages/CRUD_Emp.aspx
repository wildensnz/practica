<%@ Page Title="" Language="C#" MasterPageFile="~/sources/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="CRUD_Emp.aspx.cs" Inherits="Practica.sources.pages.CRUD_Emp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" width="250px">
        <center><asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label></center>
        <br />
    </div>
    <formview runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div class="container">
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"></asp:TextBox>
        </div>
         <div class="mb-3">
            <label class="form-label">Apellido</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbApellido"></asp:TextBox>
        </div>
         <div class="mb-3">
            <label class="form-label">Edad</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbEdad"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbEmail"></asp:TextBox>
        </div>
         <div class="mb-3">
            <label class="form-label">Productos</label>
            <asp:DropDownList ID="tbProducto" runat="server">

            </asp:DropDownList>
        </div>

        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCrear" Text="Crear" Visible="false" OnClick="btnCrear_Click"/>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnActualizar" Text="Actualizar" Visible="false" OnClick="btnActualizar_Click"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-danger" ID="btnEliminar" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="btnVolver" Text="Volver" Visible="True" OnClick="btnVolver_Click"/>
        </div>
    </formview>
</asp:Content>
