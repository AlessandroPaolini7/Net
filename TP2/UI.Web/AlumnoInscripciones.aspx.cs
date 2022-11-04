using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class AlumnoInscripciones : formApplication
    {

        Business.Entities.Usuario usuarioActual;
        AlumnoInscripcionLogic _AlumnoInscripcionLogic;

        private AlumnoInscripcionLogic AlumnoInscripcionLogic
        {
            get
            {
                if (_AlumnoInscripcionLogic == null)
                {
                    _AlumnoInscripcionLogic = new AlumnoInscripcionLogic();
                }
                return _AlumnoInscripcionLogic;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set { this.ViewState["SelectedID"] = value; }
        }

        protected bool IsEntitySelected
        {
            get { return (this.SelectedID != 0); }
        }

        private Business.Entities.AlumnoInscripcion Entity
        {
            get;
            set;
        }

        private void LoadGrid()
        {
            List<Business.Entities.AlumnoInscripcion> inscripcionesUsuario = new List<AlumnoInscripcion>();
            if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                List<Business.Entities.AlumnoInscripcion> inscripciones = this.AlumnoInscripcionLogic.GetAll();
                foreach (AlumnoInscripcion inscripcion in inscripciones)
                {
                    if (inscripcion.Alumno.IDPersona == usuarioActual.ID)
                    {
                        inscripcionesUsuario.Add(inscripcion);
                    }
                }
            }
            else if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Docente)
            {
                inscripcionesUsuario = this.AlumnoInscripcionLogic.GetAll();
            }
            else {
                inscripcionesUsuario = this.AlumnoInscripcionLogic.GetAll();
            }

            
            
            this.gridView.DataSource = inscripcionesUsuario;
            this.gridView.DataBind();


        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            usuarioActual = usuarioLogic.GetOne(Convert.ToInt32(this.Session["UserID"]));
            if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                this.editarButton.Visible = false;
            }
            else if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Docente)
            {
                this.eliminarButton.Visible = false;
                this.nuevoButton.Visible = false;

            }
            if (!this.IsPostBack)
            {

                this.LoadGrid();
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gridView.SelectedRow;
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            try
            {
                
                this.Entity = this.AlumnoInscripcionLogic.GetOne(id);
                this.condicionTextBox.Text = this.Entity.Condicion;
                this.notaTextBox.Text = this.Entity.Nota.ToString();

                this.AlumnoDDLInscripcion.Items.Clear();
                PersonaLogic alumnoLogic = new PersonaLogic();
                List<Business.Entities.Personas> alumnos = alumnoLogic.GetAll();
                foreach (Business.Entities.Personas alumno in alumnos)
                {
                    ListItem i = new ListItem(alumno.Nombre, alumno.IDPersona.ToString());
                    if (!AlumnoDDLInscripcion.Items.Contains(i)) //& alumno.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
                    {
                        AlumnoDDLInscripcion.Items.Add(i);
                    }
                }
                AlumnoDDLInscripcion.SelectedValue = Entity.Alumno.IDPersona.ToString();

                this.CursoDLLInscripcion.Items.Clear();
                CursoLogic cursoLogic = new CursoLogic();
                List<Business.Entities.Curso> cursos = cursoLogic.GetAll();
                foreach (Business.Entities.Curso curso in cursos)
                {
                    ListItem i = new ListItem(curso.IDCurso.ToString(), curso.IDCurso.ToString());
                    if (!CursoDLLInscripcion.Items.Contains(i))
                    {
                        CursoDLLInscripcion.Items.Add(i);
                    }
                }
                CursoDLLInscripcion.SelectedValue = Entity.Curso.IDCurso.ToString();
            }
            catch (Exception ex)
            {

                this.Response.Write(ex.Message);
            }
            
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void LoadEntity()
        {
            if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                Entity.Condicion = "Inscripto";
            }
            else if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Docente)
            {
                Entity.Condicion = this.condicionTextBox.Text;
                Entity.Nota = Convert.ToInt32(this.notaTextBox.Text);
            }
            else
            {
                Entity.Condicion = this.condicionTextBox.Text;
                Entity.Nota = Convert.ToInt32(this.notaTextBox.Text);
            }

            CursoLogic cursoLogic = new CursoLogic();
            Entity.Curso = cursoLogic.GetOne(Convert.ToInt32(this.CursoDLLInscripcion.SelectedValue));
            PersonaLogic alumnoLogic = new PersonaLogic();
            Entity.Alumno = alumnoLogic.GetOne(Convert.ToInt32(this.AlumnoDDLInscripcion.SelectedValue));
        }

        private void SaveEntity()
        {
            this.AlumnoInscripcionLogic.Save(this.Entity);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void EnableForm(bool enable)
        {
            this.condicionTextBox.Enabled = enable;
            this.notaTextBox.Enabled = enable;
            this.AlumnoDDLInscripcion.Enabled = enable;
            this.CursoDLLInscripcion.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.AlumnoInscripcionLogic.Delete(id);

            }
            catch (Exception ex)
            {

                this.Response.Write(ex.Message);
            }

        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            if(usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                this.condicionTextBox.Visible = false;
                this.notaTextBox.Visible = false;
                this.condicionLabel.Visible = false;
                this.notaLabel.Visible = false;

            }
            this.condicionTextBox.Text = string.Empty;
            this.notaTextBox.Text = string.Empty;


            this.AlumnoDDLInscripcion.Items.Clear();
            PersonaLogic alumnoLogic = new PersonaLogic();
            List<Business.Entities.Personas> alumnos = alumnoLogic.GetAll();
            foreach (Business.Entities.Personas alumno in alumnos)
            {
                ListItem i = new ListItem(alumno.Nombre, alumno.IDPersona.ToString());
                if (!AlumnoDDLInscripcion.Items.Contains(i)) // & alumno.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
                {
                    AlumnoDDLInscripcion.Items.Add(i);
                }
            }

            this.CursoDLLInscripcion.Items.Clear();
            CursoLogic cursoLogic = new CursoLogic();
            List<Business.Entities.Curso> cursos = cursoLogic.GetAll();
            foreach (Business.Entities.Curso curso in cursos)
            {
                ListItem i = new ListItem(curso.IDCurso.ToString(), curso.IDCurso.ToString());
                if (!CursoDLLInscripcion.Items.Contains(i))
                {
                    CursoDLLInscripcion.Items.Add(i);
                }
            }
            if (usuarioActual.Persona.TipoPersona == Business.Entities.Personas.TipoPersonas.Alumno)
            {
                this.condicionTextBox.Visible = false;
                this.notaTextBox.Visible = false;
                this.condicionLabel.Visible = false;
                this.notaLabel.Visible = false;
                AlumnoDDLInscripcion.SelectedValue = usuarioActual.Persona.IDPersona.ToString();


            }
        }

        protected void editarButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.AlumnoDDLInscripcion.Enabled = false;
        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    {
                        this.Entity = new AlumnoInscripcion();
                        this.Entity.State = BusinessEntity.States.New;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        this.Entity = new AlumnoInscripcion();
                        this.Entity.IDInscripcion = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity();
                        this.SaveEntity();
                        this.LoadGrid();
                        break;
                    }
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    }
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        protected void cancelarButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void PlanDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}