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
    public partial class ModuloUsuariosDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.ModuloUsuario ModuloUsuarioActual = new Business.Entities.ModuloUsuario();
        public ModuloUsuariosDesktop()
        {
            InitializeComponent();
        }
        public ModuloUsuariosDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            this.cmbUsuarios.DataSource = usuarioLogic.GetAll();
            ModuloLogic moduloLogic = new ModuloLogic();
            this.cmbModulos.DataSource = moduloLogic.GetAll();
        }

        public ModuloUsuariosDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            ModuloUsuarioLogic moduloUsuarioLogic = new ModuloUsuarioLogic();
            ModuloUsuarioActual = moduloUsuarioLogic.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void ModuloUsuariosDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloUsuarioActual.IDModuloUsuario.ToString();

            UsuarioLogic usuarioLogic = new UsuarioLogic();
            this.cmbUsuarios.DataSource = usuarioLogic.GetAll();
            this.cmbUsuarios.SelectedValue = this.ModuloUsuarioActual.Usuario.ID;

            ModuloLogic moduloLogic = new ModuloLogic();
            this.cmbModulos.DataSource = moduloLogic.GetAll();
            this.cmbModulos.SelectedItem = (Business.Entities.Modulo)moduloLogic.GetOne(this.ModuloUsuarioActual.Modulo.IDModulo);

            this.chkAlta.Checked = this.ModuloUsuarioActual.PermiteAlta;
            this.chkBaja.Checked = this.ModuloUsuarioActual.PermiteBaja;
            this.chkModificacion.Checked = this.ModuloUsuarioActual.PermiteModificacion;
            this.chkConsulta.Checked = this.ModuloUsuarioActual.PermiteConsulta;


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                cmbUsuarios.Enabled = false;
                cmbModulos.Enabled = false;
                chkAlta.Enabled = false;
                chkBaja.Enabled = false;
                chkModificacion.Enabled = false;
                chkConsulta.Enabled = false;
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
                ModuloUsuarioActual = new Business.Entities.ModuloUsuario();

                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuarioActual.Usuario = usuarioLogic.GetOne(Convert.ToInt32(this.cmbUsuarios.SelectedValue));
                ModuloLogic moduloLogic = new ModuloLogic();
                ModuloUsuarioActual.Modulo = moduloLogic.GetOne(Convert.ToInt32(this.cmbModulos.SelectedValue));

                ModuloUsuarioActual.PermiteAlta = this.chkAlta.Checked;
                ModuloUsuarioActual.PermiteBaja = this.chkBaja.Checked;
                ModuloUsuarioActual.PermiteModificacion = this.chkModificacion.Checked;
                ModuloUsuarioActual.PermiteConsulta = this.chkConsulta.Checked;

                ModuloUsuarioActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuarioActual.Usuario = usuarioLogic.GetOne(Convert.ToInt32(this.cmbUsuarios.SelectedValue));
                ModuloLogic moduloLogic = new ModuloLogic();
                ModuloUsuarioActual.Modulo = moduloLogic.GetOne(Convert.ToInt32(this.cmbModulos.SelectedValue));

                ModuloUsuarioActual.PermiteAlta = this.chkAlta.Checked;
                ModuloUsuarioActual.PermiteBaja = this.chkBaja.Checked;
                ModuloUsuarioActual.PermiteModificacion = this.chkModificacion.Checked;
                ModuloUsuarioActual.PermiteConsulta = this.chkConsulta.Checked;

                ModuloUsuarioActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                ModuloUsuarioActual.State = BusinessEntity.States.Deleted;
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                mul.Save(ModuloUsuarioActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public override bool Validar()
        {
            return true;
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
