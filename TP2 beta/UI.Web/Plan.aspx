<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="UI.Web.Plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="myGridClass" AlternatingRowStyle-CssClass="alt" 
            SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="IDPlan" DataField="IDEspecialidad" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="IDEspecialidad" DataField="IDEspecialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
        <asp:Panel CssClass="gridActionsPanel" ID="gridActionsPanel" runat="server">
            <asp:Button ID="editarButton" Text="Editar" runat="server" OnClick="editarButton_Click" />
            <asp:Button ID="eliminarButton" Text="Eliminar" runat="server" OnClick="eliminarButton_Click" />
            <asp:Button ID="nuevoButton" Text="Nuevo" runat="server" OnClick="nuevoButton_Click" />
            <br />
            <br />
            <br />
        </asp:Panel>
        <asp:Panel CssClass="formPanel" ID="formPanel" Visible="false" runat="server">
            <asp:Label CssClass="label" ID="descripcionLabel" runat="server" Text="Plan: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="ID Especialidad: "></asp:Label>
            <asp:TextBox ID="idespecialidadTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Panel CssClass="formsActionsPanel" ID="formsActionsPanel" runat="server">
                <asp:button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click"/>
                <asp:button ID="cancelarButton" runat="server" Text="Cancelar" OnClick="cancelarButton_Click" CausesValidation="False"/>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
