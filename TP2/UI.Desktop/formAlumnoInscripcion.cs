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
        Business.Entities.Usuario UsuarioActual;
        public formAlumnoInscripcion(Business.Entities.Usuario user)
        {
            UsuarioActual = user;
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void formAlumnoInscripcion_Load(object sender, EventArgs e)
        {
            if(UsuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                this.tsbEditar.Visible = false;
            }
            else if(UsuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Docente)
            {
                this.tsbEliminar.Visible = false;
                this.tsbNuevo.Visible = false;
            }
            this.Listar();
            
        }

        public void Listar()
        {
            List<AlumnoInscripcion> inscripcionesUsuario = new List<AlumnoInscripcion>();
            if(UsuarioActual.Persona.TipoPersona == Personas.TipoPersonas.Alumno)
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                List<Business.Entities.AlumnoInscripcion> inscripciones = ail.GetAll();
                foreach (Business.Entities.AlumnoInscripcion ins in inscripciones)
                {
                    if(ins.Alumno.IDPersona == UsuarioActual.Persona.IDPersona)
                    {
                        ins.AlumnoDesc = ins.Alumno.Nombre + " " + ins.Alumno.Apellido;
                        ins.CursoID = ins.Curso.IDCurso;
                        inscripcionesUsuario.Add(ins);
                    }


                }
            }
            else
            {
                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                List<Business.Entities.AlumnoInscripcion> inscripciones = ail.GetAll();
                foreach (Business.Entities.AlumnoInscripcion ins in inscripciones)
                {
                        ins.AlumnoDesc = ins.Alumno.Nombre + " " + ins.Alumno.Apellido;
                        ins.CursoID = ins.Curso.IDCurso;
                }
                inscripcionesUsuario = inscripciones;
            }
            
            this.dgvInscripciones.DataSource = inscripcionesUsuario;
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
            AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(AlumnoInscripcionesDesktop.ModoForm.Alta, UsuarioActual);
            appABM.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (!(this.dgvInscripciones.SelectedRows is null))
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).IDInscripcion;
                AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(ID, AlumnoInscripcionesDesktop.ModoForm.Modificacion, UsuarioActual);
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
                AlumnoInscripcionesDesktop appABM = new AlumnoInscripcionesDesktop(ID, AlumnoInscripcionesDesktop.ModoForm.Baja, UsuarioActual);
                appABM.ShowDialog();
                this.Listar();

            }
            else MessageBox.Show("Error", "No ha seleccionado ninguna comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
