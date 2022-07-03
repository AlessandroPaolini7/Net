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
    public partial class formEspecialidad : Form
    {
        public formEspecialidad()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void formEspecialidad_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop appABM = new EspecialidadesDesktop(EspecialidadesDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvEspecialidades.SelectedRows is null))
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IDEspecialidad;
                EspecialidadesDesktop appABM = new EspecialidadesDesktop(ID, EspecialidadesDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvEspecialidades.SelectedRows is null))
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).IDEspecialidad;
                EspecialidadesDesktop appABM = new EspecialidadesDesktop(ID, EspecialidadesDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
