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
    public partial class formMateria : Form
    {
        public formMateria()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        private void formMateria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Business.Entities.Materia> materias = ml.GetAll();
            foreach (Materia mat in materias)
            {
                PlanLogic pl = new PlanLogic();
                mat.PlanDesc = mat.Plan.Descripcion;

            }
            this.dgvMaterias.DataSource = materias;
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
            MateriasDesktop appABM = new MateriasDesktop(MateriasDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvMaterias.SelectedRows is null))
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).IDMateria;
                MateriasDesktop appABM = new MateriasDesktop(ID, MateriasDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvMaterias.SelectedRows is null))
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).IDMateria;
                MateriasDesktop appABM = new MateriasDesktop(ID, MateriasDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
