<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CRUD.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <div class="mb-3">
        <label class="form-label">Nombre completo</label>
        <asp:TextBox ID="txtNombreCompleto" CssClass="form-control" runat="server" />
    </div>
    <div class="mb-3">
        <label class="form-label">Departamentos</label>
        <asp:DropDownList ID="ddlDepartamento" CssClass="form-select" runat="server"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label class="form-label">Sueldo </label>
        <asp:TextBox ID="txtSueldo" CssClass="form-control"  runat="server" />
    </div>
    <div class="mb-3">
        <label class="form-label">Fecha de Contrato </label>
        <asp:TextBox ID="txtFechaContrato" CssClass="form-control" TextMode="Date" runat="server" />
    </div>
    <div class="mb-3">
        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" cssClass="btn btn-sm btn-primary" runat="server" Text="Enviar" />
        <a href="Default.aspx" class="btn btn-sm btn-warning">Volver</a>
    </div>

</asp:Content>
