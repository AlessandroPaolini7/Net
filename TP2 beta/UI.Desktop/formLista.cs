using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formLista : Form
    {
        public formLista()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;

        }
        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void formLista_Load(object sender, EventArgs e)
        {
            this.Listar();

        }
        public void Listar()
        {
            Business.Logic.UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();


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
            UsuariosDesktop appABM = new UsuariosDesktop(UsuariosDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();


        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvUsuarios.SelectedRows is null))
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuariosDesktop appABM = new UsuariosDesktop(ID, UsuariosDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ningun usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvUsuarios.SelectedRows is null))
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuariosDesktop appABM = new UsuariosDesktop(ID, UsuariosDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ningun usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
