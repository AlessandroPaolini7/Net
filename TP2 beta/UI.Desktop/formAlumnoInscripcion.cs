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
    public partial class formAlumnoInscripcion : Form
    {
        public formAlumnoInscripcion()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void formAlumnoInscripcion_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<Business.Entities.AlumnoInscripcion> inscripciones = ail.GetAll();
            foreach (Business.Entities.AlumnoInscripcion ins in inscripciones)
            {

                ins.AlumnoDesc = ins.Alumno.Nombre + " " + ins.Alumno.Apellido;
                ins.CursoID = ins.Curso.IDCurso;

            }
            this.dgvInscripciones.DataSource = inscripciones;
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
            AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(AlumnoInscripcionesDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvInscripciones.SelectedRows is null))
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).IDInscripcion;
                AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(ID, AlumnoInscripcionesDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvInscripciones.SelectedRows is null))
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).IDInscripcion;
                AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(ID, AlumnoInscripcionesDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
