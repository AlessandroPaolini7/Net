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
    public partial class formComision : Form
    {
        public formComision()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }

        private void formComision_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            List<Business.Entities.Comision> comisiones = cl.GetAll();
            foreach(Comision com in comisiones)
            {
                com.PlanDesc = com.Plan.Descripcion;

            }
            this.dgvComisiones.DataSource = comisiones;
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
            ComisionesDesktop appABM = new ComisionesDesktop(ComisionesDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvComisiones.SelectedRows is null))
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).IDComision;
                ComisionesDesktop appABM = new ComisionesDesktop(ID, ComisionesDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvComisiones.SelectedRows is null))
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).IDComision;
                ComisionesDesktop appABM = new ComisionesDesktop(ID, ComisionesDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
