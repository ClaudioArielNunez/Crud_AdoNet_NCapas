<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div classs="row">
        <div class="col-12">
            <asp:Button ID="btnNuevo" OnClick="btnNuevo_Click" CssClass="btn btn-success" runat="server" Text="Nuevo" />
        </div>
    </div>
    <div classs="row">
        <div class="col-12">
            <asp:GridView ID="GVEmpleado" CssClass="table table-bordered" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                    <asp:BoundField DataField="Departamento.Nombre" HeaderText="Departamento"/>
                    <asp:BoundField DataField="Sueldo" HeaderText="Sueldo"/>
                    <asp:BoundField DataField="FechaContrato" HeaderText="Fecha de Contrato" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton CommandArgument="<%#Eval("IdEmpleado") %>" runat="server"
                                 OnClick="Editar_Click" CssClass="btn btn-sm btn-primary">Editar</asp:LinkButton>
                            <asp:LinkButton CommandArgument="<%#Eval("IdEmpleado") %>" id="borrar" OnClick="borrar_Click" OnClientClick="return confirm('¿Desea eliminar?')" CssClass="btn btn-sm btn-danger" runat="server">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
