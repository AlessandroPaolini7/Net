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
    public partial class formCurso : Form
    {
        public formCurso()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;

        }

        private void formCurso_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            List<Business.Entities.Curso> cursos = cl.GetAll();
            foreach (Curso curso in cursos)
            {
                curso.ComisionDesc = curso.Comision.Descripcion;

            }
            foreach (Curso curso in cursos)
            {
                curso.MateriaDesc = curso.Materia.Descripcion;

            }
            this.dgvCursos.DataSource = cursos;
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
            CursosDesktop appABM = new CursosDesktop(CursosDesktop.ModoForm.Alta);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvCursos.SelectedRows is null))
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).IDCurso;
                CursosDesktop appABM = new CursosDesktop(ID, CursosDesktop.ModoForm.Modificacion);
                appABM.ShowDialog();
                this.Listar();
            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvCursos.SelectedRows is null))
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).IDCurso;
                CursosDesktop appABM = new CursosDesktop(ID, CursosDesktop.ModoForm.Baja);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
