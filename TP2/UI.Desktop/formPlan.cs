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
    public partial class formPlan : Form
    {
        public formPlan()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        private void formPlan_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            List<Business.Entities.Plan> planes = pl.GetAll();
            foreach (Plan plan in planes)
            {
                EspecialidadLogic especialidadLogic = new EspecialidadLogic();
                plan.EspecialidadDesc = plan.Especialidad.Descripcion;

            }
            this.dgvPlanes.DataSource = planes;

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
            PlanesDesktop appABM = new PlanesDesktop(PlanesDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvPlanes.SelectedRows is null))
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IDPlan;
                PlanesDesktop appABM = new PlanesDesktop(ID, PlanesDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ningun plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvPlanes.SelectedRows is null))
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).IDPlan;
                PlanesDesktop appABM = new PlanesDesktop(ID, PlanesDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ningun plan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tcPlanes_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
