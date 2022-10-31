<%@ Page Title="Personas" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ABM_Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="myGridClass" AlternatingRowStyle-CssClass="alt"
            SelectedRowStyle-BackColor="Black"
             SelectedRowStyle-ForeColor="White"
            DataKeyNames="IDPersona" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Email" DataField="Email" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:BoundField HeaderText="Plan" DataField="Plan.Descripcion" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
            </Columns>
        </asp:GridView>
        <<asp:Panel CssClass="gridActionsPanel" ID="gridActionsPanel" runat="server">
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
            <asp:Label CssClass="label" ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorNombre" runat="server" ControlToValidate="nombreTextBox" Display="Dynamic" ErrorMessage="El nombre no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label1" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="apellidoTextBox" Display="Dynamic" ErrorMessage="El apellido no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label2" runat="server" Text="Dirección: "></asp:Label>
            <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="direccionTextBox" Display="Dynamic" ErrorMessage="La dirección no puede estar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label3" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="emailTextBox" Display="Dynamic" ErrorMessage="El mail no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label4" runat="server" Text="Teléfono: "></asp:Label>
            <asp:TextBox ID="telefonoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="telefonoTextBox" Display="Dynamic" ErrorMessage="El teléfono no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label5" runat="server" Text="Fecha de nacimiento: "></asp:Label>
            <asp:TextBox ID="fechaNacimientoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="fechaNacimientoTextBox" Display="Dynamic" ErrorMessage="La fecha de nacimiento no puede estar vacía" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label6" runat="server" Text="Legajo: "></asp:Label>
            <asp:TextBox ID="legajoTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="legajoTextBox" Display="Dynamic" ErrorMessage="El legajo no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="Label7" runat="server" Text="Plan: "></asp:Label>
            <asp:DropDownList ID="PlanDDLPersonas" runat="server" DataTextField="Descripcion" DataValueField="IDPlan" OnSelectedIndexChanged="PlanDDL_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PlanDDLPersonas" Display="Dynamic" ErrorMessage="El plan no puede estar vacío" ForeColor="#CC0066">*</asp:RequiredFieldValidator>
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
