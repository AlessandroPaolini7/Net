﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AlumnoInscripciones.aspx.cs" Inherits="UI.Web.AlumnoInscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ABM_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="myGridClass" AlternatingRowStyle-CssClass="alt" 
            SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
            DataKeyNames="IDInscripcion" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre alumno" DataField="Alumno.Nombre" />
                <asp:BoundField HeaderText="Apellido alumno" DataField="Alumno.Apellido" />
                <asp:BoundField HeaderText="Identificador curso" DataField="Curso.IDCurso" />
                <asp:BoundField HeaderText="Año curso" DataField="Curso.AnioCalendario" />
                <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />

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
            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Alumno: "></asp:Label>
            <asp:DropDownList ID="AlumnoDDLInscripcion" runat="server" DataTextField="Nombre" DataValueField="IDPersona">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AlumnoDDLInscripcion" Display="Dynamic" ErrorMessage="El alumno no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label3" runat="server" Text="Curso: "></asp:Label>
            <asp:DropDownList ID="CursoDLLInscripcion" runat="server" DataTextField="IDCurso" DataValueField="IDCurso">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CursoDLLInscripcion" Display="Dynamic" ErrorMessage="El curso no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="Condicion: "></asp:Label>
            <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="condicionTextBox" Display="Dynamic" ErrorMessage="La condicion del alumno no puede estar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label2" runat="server" Text="Nota: "></asp:Label>
            <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="notaTextBox" Display="Dynamic" ErrorMessage="La nota del alumno no puede estar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Panel CssClass="formsActionsPanel" ID="formsActionsPanel" runat="server">
                <asp:button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click"/>
                <asp:button ID="cancelarButton" runat="server" Text="Cancelar" OnClick="cancelarButton_Click" CausesValidation="False"/>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0066" />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
