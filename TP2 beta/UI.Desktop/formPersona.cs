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
    public partial class formPersona : Form
    {
        public formPersona()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }

        private void formPersona_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            List<Business.Entities.Personas> personas = pl.GetAll();
            foreach (Personas persona in personas)
            {

                persona.PlanDesc = persona.Plan.Descripcion;

            }
            this.dgvPersonas.DataSource = personas;
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
            PersonasDesktop appABM = new PersonasDesktop(PersonasDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvPersonas.SelectedRows is null))
            {
                int ID = ((Business.Entities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).IDPersona;
                PersonasDesktop appABM = new PersonasDesktop(ID, PersonasDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvPersonas.SelectedRows is null))
            {
                int ID = ((Business.Entities.Personas)this.dgvPersonas.SelectedRows[0].DataBoundItem).IDPersona;
                PersonasDesktop appABM = new PersonasDesktop(ID, PersonasDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


    }
}
