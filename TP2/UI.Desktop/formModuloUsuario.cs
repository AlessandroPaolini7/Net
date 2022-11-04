using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formModuloUsuario : Form
    {
        public formModuloUsuario()
        {
            InitializeComponent();
            this.dgvModulosUsuarios.AutoGenerateColumns = false;
        }
        
        private void formModuloUsuario_Load(object sender, EventArgs e)
        {
            this.Listar();

        }
        public void Listar()
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            List<Business.Entities.ModuloUsuario> moduloUsuarios = mul.GetAll();
            foreach (ModuloUsuario moduloUsuario in moduloUsuarios)
            {
                moduloUsuario.UsuarioDesc = moduloUsuario.Usuario.Nombre;
                moduloUsuario.ModuloDesc = moduloUsuario.Modulo.Descripcion;

            }
            this.dgvModulosUsuarios.DataSource = moduloUsuarios;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloUsuariosDesktop appABM = new ModuloUsuariosDesktop(ModuloUsuariosDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvModulosUsuarios.SelectedRows is null))
            {
                int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).IDModuloUsuario;
                ModuloUsuariosDesktop appABM = new ModuloUsuariosDesktop(ID, ModuloUsuariosDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvModulosUsuarios.SelectedRows is null))
            {
                int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).IDModuloUsuario;
                ModuloUsuariosDesktop appABM = new ModuloUsuariosDesktop(ID, ModuloUsuariosDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
