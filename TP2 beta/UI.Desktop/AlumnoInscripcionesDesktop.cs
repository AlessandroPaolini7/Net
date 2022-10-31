using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoInscripcionesDesktop : UI.Desktop.ApplicationForm
    {
        Business.Entities.AlumnoInscripcion InscripcionActual = new Business.Entities.AlumnoInscripcion();
        public AlumnoInscripcionesDesktop()
        {
            InitializeComponent();
        }
        public AlumnoInscripcionesDesktop(ModoForm modo)
        {
            Modo = modo;
            InitializeComponent();

            CursoLogic cursoLogic = new CursoLogic();
            this.cmbCurso.DataSource = cursoLogic.GetAll();
            PersonaLogic personaLogic = new PersonaLogic();
            List<Business.Entities.Personas> personas = personaLogic.GetAll();
            List<Business.Entities.Personas> alumnos = new List<Business.Entities.Personas>();
            foreach (Business.Entities.Personas persona in personas)
            {
                if (persona.TipoPersona == Personas.TipoPersonas.Alumno)
                {
                    alumnos.Add(persona);
                }
            }
            this.cmbAlumno.DataSource = alumnos;
        }

        public AlumnoInscripcionesDesktop(int ID, ModoForm modo)
        {
            Modo = modo;
            AlumnoInscripcionLogic inscripcion = new AlumnoInscripcionLogic();
            InscripcionActual = inscripcion.GetOne(ID);
            InitializeComponent();

            this.MapearDeDatos();
        }

        private void AlumnoInscripcionesDesktop_Load(object sender, EventArgs e)
        {

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.InscripcionActual.IDInscripcion.ToString();
            this.txtCondicion.Text = this.InscripcionActual.Condicion;
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();

            CursoLogic cursoLogic = new CursoLogic();
            this.cmbCurso.DataSource = cursoLogic.GetAll();
            this.cmbCurso.SelectedItem = (Business.Entities.Curso)cursoLogic.GetOne(this.InscripcionActual.Curso.IDCurso);

            PersonaLogic personaLogic = new PersonaLogic();
            List<Business.Entities.Personas> personas = personaLogic.GetAll();
            List<Business.Entities.Personas> alumnos = new List<Business.Entities.Personas>();
            foreach (Business.Entities.Personas persona in personas)
            {
                if (persona.TipoPersona == Personas.TipoPersonas.Alumno)
                {
                    alumnos.Add(persona);
                }
            }
            this.cmbAlumno.DataSource = alumnos;
            this.cmbAlumno.SelectedItem = (Business.Entities.Personas)personaLogic.GetOne(this.InscripcionActual.Alumno.IDPersona);


            if (Modo == ModoForm.Alta | Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtCondicion.ReadOnly = true;
                txtNota.ReadOnly = true;

                cmbCurso.Enabled = false;
                cmbAlumno.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }


        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                InscripcionActual = new Business.Entities.AlumnoInscripcion();
                InscripcionActual.Condicion = this.txtCondicion.Text;
                InscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);

                CursoLogic cursoLogic = new CursoLogic();
                InscripcionActual.Curso = cursoLogic.GetOne(Convert.ToInt32(this.cmbCurso.SelectedValue));

                PersonaLogic personaLogic = new PersonaLogic();
                InscripcionActual.Alumno = personaLogic.GetOne(Convert.ToInt32(this.cmbAlumno.SelectedValue));

                InscripcionActual.State = BusinessEntity.States.New;
            }
            if (Modo == ModoForm.Modificacion)
            {
                InscripcionActual.Condicion = this.txtCondicion.Text;
                InscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);

                CursoLogic cursoLogic = new CursoLogic();
                InscripcionActual.Curso = cursoLogic.GetOne(Convert.ToInt32(this.cmbCurso.SelectedValue));

                PersonaLogic personaLogic = new PersonaLogic();
                InscripcionActual.Alumno = personaLogic.GetOne(Convert.ToInt32(this.cmbAlumno.SelectedValue));

                InscripcionActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                InscripcionActual.State = BusinessEntity.States.Deleted;
            }
        }


        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();

                AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                ail.Save(InscripcionActual);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override bool Validar()
        {
            if ((this.txtCondicion.Text == "") | (this.txtNota.Text == "")) return false;
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            else
            {
                this.Notificar("Datos Invalidos", "Los datos ingresados no son correctos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
