﻿<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ABM_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="myGridClass" AlternatingRowStyle-CssClass="alt" 
            SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
            DataKeyNames="IDComision" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="AnioEspecialidad" DataField="AnioEspecialidad" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Plan" DataField="Plan.Descripcion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
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
            <asp:Label CssClass="label" ID="anioespecialidadLabel" runat="server" Text="Anio Especialidad: "></asp:Label>
            <asp:TextBox ID="anioespecialidadTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorAnioEspecialidad" runat="server" ControlToValidate="anioespecialidadTextBox" Display="Dynamic" ErrorMessage="El anio no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="descripcionLabel" runat="server" Text="Descripcion comision: "></asp:Label>
            <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorDescripcion" runat="server" ControlToValidate="descripcionTextBox" Display="Dynamic" ErrorMessage="La descripcion no puede estar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label3" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="PlanDDLComision" runat="server" DataTextField="Descripcion" DataValueField="IDPlan">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PlanDDLComision" Display="Dynamic" ErrorMessage="El plan no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
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
