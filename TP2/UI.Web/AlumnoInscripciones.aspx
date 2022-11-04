<%@ Page Title="Inscripciones" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AlumnoInscripciones.aspx.cs" Inherits="UI.Web.AlumnoInscripciones" %>

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
                <asp:BoundField HeaderText="Nombre alumno" DataField="Alumno.Nombre" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Apellido alumno" DataField="Alumno.Apellido" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Identificador curso" DataField="Curso.IDCurso" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Año curso" DataField="Curso.AnioCalendario" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Condicion" DataField="Condicion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Nota" DataField="Nota" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>

                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
       <asp:Panel CssClass="gridActionsPanel" ID="gridActionsPanel" runat="server">
            <div class="d-flex justify-content-center">
            <asp:Button ID="editarButton" Text="Editar" runat="server" OnClick="editarButton_Click" CssClass="bg-primary"/>
            <asp:Button ID="eliminarButton" Text="Eliminar" runat="server" OnClick="eliminarButton_Click" CssClass="bg-primary" />
            <asp:Button ID="nuevoButton" Text="Nuevo" runat="server" OnClick="nuevoButton_Click" CssClass="bg-primary"/>
                <br />
                <br />
                * Las inscripciones con nota 0 se deben a que el docente no ha cargado la nota correspondiente aún.</div>
            <br />
            <br />
            <br />
        </asp:Panel>
        <div class="d-flex justify-content-center">
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
            <asp:Label CssClass="label" ID="condicionLabel" runat="server" Text="Condicion: "></asp:Label>
            <asp:TextBox ID="condicionTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label CssClass="label" ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
            <asp:TextBox ID="notaTextBox" runat="server"></asp:TextBox>
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
