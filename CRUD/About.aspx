<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CRUD.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="fw-bold  my-3">Detalle Empleado</h4>
    <div class="row">
        <div class="mb-3 col-6">
            <div class="mb-3">
                <label class="fw-bold form-label">Id:</label>
                <asp:Label Text="text" ID="id" runat="server" />
            </div>
            <div class="mb-3">
                <label class="fw-bold form-label">Nombre:</label>
                <asp:Label Text="text" ID="nombre" runat="server" />
            </div>
            <div class="mb-3">
                <label class="fw-bold form-label">Departamento:</label>
                <asp:Label Text="text" ID="departamento" runat="server" />
            </div>
            <div class="mb-3">
                <label class="fw-bold form-label">Sueldo:</label>
                <asp:Label Text="text" ID="sueldo" runat="server" />
            </div>
            <div class="mb-3">
                <label class="fw-bold form-label">Fecha de contratación:</label>
                <asp:Label Text="text" ID="fecha" runat="server" />
            </div>
            <div class="mb-3">
                <a href="Default.aspx" class=" btn btn-sm btn-success">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>
