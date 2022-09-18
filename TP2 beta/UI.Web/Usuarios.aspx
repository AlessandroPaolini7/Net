<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
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
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
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
            <asp:Label CssClass="label" ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox  ID="nombreTextBox" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="nombreValidator" runat="server" ControlToValidate="nombreTextBox" Display="Dynamic" ErrorMessage="El nombre no puede estar vacío" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server" OnTextChanged="apellidoTextBox_TextChanged"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="apellidoValidator" runat="server" ControlToValidate="apellidoTextBox" Display="Dynamic" ErrorMessage="El apellido no puede estar vacío" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="emailLabel" runat="server" Text="Email: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="emailValidator" runat="server" ControlToValidate="emailTextBox" Display="Dynamic" ErrorMessage="El email no puede estar vacío" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="emailExpValidator" runat="server" ControlToValidate="emailTextBox" Display="Dynamic" ErrorMessage="El email es inválido." ForeColor="#CC0066" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <br />
            <asp:Label  CssClass="label" ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
            <br />
            <asp:Label CssClass="label" ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="nombreUsuarioValidator" runat="server" ControlToValidate="nombreUsuarioTextBox" Display="Dynamic" ErrorMessage="El nombre de usuario no puede estar vacío" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="claveValidator" runat="server" ControlToValidate="claveTextBox" Display="Dynamic" ErrorMessage="La clave no puede estar vacía" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label CssClass="label" ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" runat="server" OnTextChanged="repetirClaveTextBox_TextChanged" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="repetirClaveValidator" runat="server" ControlToValidate="repetirClaveTextBox" Display="Dynamic" ErrorMessage="Debe repetir la clave" ForeColor="#CC0066" SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="repetirClaveComValidator" runat="server" ControlToCompare="claveTextBox" ControlToValidate="repetirClaveTextBox" Display="Dynamic" ErrorMessage="Las claves no coinciden" ForeColor="#CC0066" SetFocusOnError="True">*</asp:CompareValidator>
            <br />
            <asp:Panel CssClass="formsActionsPanel" ID="formsActionsPanel" runat="server">
                <asp:button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click"/>
                <asp:button ID="cancelarButton" runat="server" Text="Cancelar" OnClick="cancelarButton_Click" CausesValidation="False"/>
                <asp:ValidationSummary ID="validationSummary" runat="server" ForeColor="#CC0066" />
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
