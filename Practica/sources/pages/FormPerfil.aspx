<%@ Page Title="" Language="C#" MasterPageFile="~/sources/pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormPerfil.aspx.cs" Inherits="Practica.sources.pages.FormPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Mi perfil
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <fieldset class="row">
            <div class="container text-black-50 row">
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <div class="row">
                                <asp:Image runat="server" ID="Image" CssClass="form-control img-thumbnail" Height="300"/>
                            </div>
                            <br />
                            <div class="row">
                                <asp:FileUpload runat="server" ID="FuImage" CssClass="form-control form-control-sm" />
                            </div>
                            <br />
                            <div class="row">
                                <asp:Button runat="server" ID="btnAplicar" CssClass="form-control btn btn-dark" Text="Aplicar Cambios" OnClick="btnAplicar_Click"/>
                            </div>
                        </fieldset>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" ID="lblError" CssClass="alert-danger"></asp:Label>
                    </div>
                </div>
                <div class="col-6 row justify-content-center">
                    <div class="align-items-center col-auto">
                        <fieldset>
                            <legend><i class="fa fa-database"> Datos personales </i></legend>
                            <asp:Table runat="server" Enabled="false">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Nombres"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbNombres"/>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Apellidos"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbApellidos"/>
                                    </asp:TableCell>
                                </asp:TableRow>

                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Fecha de nacimiento"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbFecha"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </fieldset>
                        <br />
                        <fieldset>
                            <legend>
                                <i class="fa fa-key"> Datos de sesion</i>
                            </legend>
                            <asp:Table runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Usuario"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox runat="server" CssClass="form-control" ID="TbUsuario" Enabled="false"/>


                                    </asp:TableCell>
                                   
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <br />
                                        <br />
                                        <asp:Button runat="server" CssClass="form-control btn btn-warning" ID="btnCambiar" Text="Cambiar contraseña" OnClick="btnCambiar_Click"></asp:Button>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <br />
                                        <br />

                                        <asp:Button runat="server" CssClass="form-control btn btn-success" ID="btnGuardar" Text="Guardar" Visible="false" OnClick="btnGuardar_Click"></asp:Button>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>

                            <asp:Table runat="server" ID="contrasena" Visible="false">
                                <asp:TableRow>
                                    <asp:TableCell>

                                        <br />
                                        <br />
                                        <asp:Label runat="server" CssClass="col-form-label" Text="Contraseña"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>

                                        <br />
                                        <br />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbClave" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <br />

                                        <asp:Label runat="server" CssClass="col-form-label" Text="Repetir contraseña"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <br />

                                        <asp:TextBox runat="server" CssClass="form-control" ID="tbClave2" placeholder="Repetir contraseña" TextMode="Password"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Label runat="server" ID="lblErrorClave" CssClass="alert-danger"></asp:Label>
                        </fieldset>
                    </div>
                </div>
            </div>
        </fieldset>
        <br />
        <br />
        <div class="container d-flex justify-content-end">
            <asp:Button runat="server" class="btn btn-danger" Text="Eliminar cuenta" OnClick="Eliminar" />
        </div>
    </div>
</asp:Content>
