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
    public partial class formModulo : Form
    {
        public formModulo()
        {
            InitializeComponent();
            this.dgvModulos.AutoGenerateColumns = false;
        }

        private void formModulo_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            ModuloLogic moduloLogic = new ModuloLogic();
            this.dgvModulos.DataSource = moduloLogic.GetAll();
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
            ModulosDesktop appABM = new ModulosDesktop(ModulosDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvModulos.SelectedRows is null))
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).IDModulo;
                ModulosDesktop appABM = new ModulosDesktop(ID, ModulosDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvModulos.SelectedRows is null))
            {
                int ID = ((Business.Entities.Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).IDModulo;
                ModulosDesktop appABM = new ModulosDesktop(ID, ModulosDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
