<%@ Page Title="Planes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ABM_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="myGridClass" AlternatingRowStyle-CssClass="alt" 
            SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="IDPlan" DataField="IDPlan" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="IDEspecialidad" DataField="IDEspecialidad" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
         <asp:Panel CssClass="gridActionsPanel" ID="gridActionsPanel" runat="server">
            <div class="d-flex justify-content-center">
            <asp:Button ID="editarButton" Text="Editar" runat="server" OnClick="editarButton_Click" CssClass="bg-primary"/>
            <asp:Button ID="eliminarButton" Text="Eliminar" runat="server" OnClick="eliminarButton_Click" CssClass="bg-primary" />
            <asp:Button ID="nuevoButton" Text="Nuevo" runat="server" OnClick="nuevoButton_Click" CssClass="bg-primary"/>
            </div>
            <br />
            <br />
            <br />
        </asp:Panel>
        <div class="d-flex justify-content-center">
        <asp:Panel CssClass="formPanel" ID="formPanel" Visible="false" runat="server">
            <asp:Label CssClass="label" ID="descripcionLabel" runat="server" Text="Descripcion plan: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorDescripcion" runat="server" ControlToValidate="descripcionTextBox" Display="Dynamic" ErrorMessage="La descripcion del plan no puede estrar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="ID Especialidad: "></asp:Label>
            <asp:TextBox ID="idespecialidadTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorIdEspecialidad" runat="server" ControlToValidate="descripcionTextBox" Display="Dynamic" ErrorMessage="El id de la especialidad no puede estrar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Panel CssClass="formsActionsPanel" ID="formsActionsPanel" runat="server">
                <asp:button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click" CssClass="bg-primary"/>
                <asp:button ID="cancelarButton" runat="server" Text="Cancelar" OnClick="cancelarButton_Click" CausesValidation="False" CssClass="bg-primary"/>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0066" />
            </asp:Panel>
        </asp:Panel>
            </div>
    </asp:Panel>
</asp:Content>
