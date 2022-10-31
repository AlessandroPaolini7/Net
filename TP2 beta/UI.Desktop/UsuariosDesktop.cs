using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuariosDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.Usuario UsuarioActual = new Business.Entities.Usuario();
        public UsuariosDesktop()
        {
            InitializeComponent();
        }
        public UsuariosDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            PersonaLogic personaLogic = new PersonaLogic();
            this.cmbPersona.DataSource = personaLogic.GetAll();
        }
        public UsuariosDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            UsuarioLogic user = new UsuarioLogic();
            UsuarioActual = user.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }
        private void UsuariosDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            PersonaLogic personaLogic = new PersonaLogic();
            this.cmbPersona.DataSource = personaLogic.GetAll();
            this.cmbPersona.SelectedItem = (Business.Entities.Personas)personaLogic.GetOne(this.UsuarioActual.Persona.IDPersona);

            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtNombre.ReadOnly = true;
                txtApellido.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtUsuario.ReadOnly = true;
                chkHabilitado.Enabled = false;
                txtClave.ReadOnly = true;
                cmbPersona.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }

        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Business.Entities.Usuario();
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                PersonaLogic personaLogic = new PersonaLogic();
                UsuarioActual.Persona = personaLogic.GetOne(Convert.ToInt32(this.cmbPersona.SelectedValue));
                UsuarioActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;

                PersonaLogic personaLogic = new PersonaLogic();
                UsuarioActual.Persona = personaLogic.GetOne(Convert.ToInt32(this.cmbPersona.SelectedValue));
                UsuarioActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }


        }
        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic ul = new UsuarioLogic();
                ul.Save(UsuarioActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

        }
        public override bool Validar()
        {
            if (this.txtApellido.Text == null | this.txtNombre.Text == null | this.txtEmail.Text == null | this.txtClave.Text == null | this.txtUsuario.Text == null) return false;
            if (this.txtClave.Text != this.txtConfirmarClave.Text) return false;
            if (this.txtClave.Text.Length < 8) return false;
            if (!(this.txtEmail.Text.Contains("@")) | !(this.txtEmail.Text.EndsWith(".com"))) return false;
            return true;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                this.Notificar("Datos Invalidos", "Los datos ingresados no son correctos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
