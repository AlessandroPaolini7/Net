using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        Business.Entities.Usuario UsuarioActual;
        public formMain(Business.Entities.Usuario user)
        {
            UsuarioActual = user;
            InitializeComponent();
            switch (user.Persona.TipoPersona)
            {
                case Business.Entities.Personas.TipoPersonas.Docente:
                    this.mnuUsuario.Visible = false;
                    this.mnuEspecialidad.Visible = false;
                    this.mnuPlan.Visible = false;
                    this.mnuCurso.Visible = false;
                    this.mnuPersona.Visible = false;
                    this.mnuModulo.Visible = false;
                    this.mnuModuloUsuario.Visible = false;
                    break;
                case Business.Entities.Personas.TipoPersonas.Alumno:
                    this.mnuUsuario.Visible = false;
                    this.mnuEspecialidad.Visible = false;
                    this.mnuPlan.Visible = false;
                    this.mnuCurso.Visible = false;
                    this.mnuPersona.Visible = false;
                    this.mnuModulo.Visible = false;
                    this.mnuModuloUsuario.Visible = false;
                    this.mnuReporte.Visible = false;
                    break;
                default:
                    break;
            }
        }

        public void SetearUsuario(Business.Entities.Usuario user)
        {
            UsuarioActual = user;
        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Load(object sender, EventArgs e)
        {

        }

        private void formMain_Shown(object sender, EventArgs e)
        {

        }
        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLista appLista = new formLista();
            appLista.ShowDialog();
        }

        private void mnsPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void mnuArchivo_Click(object sender, EventArgs e)
        {

        }

        private void especialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formEspecialidad appEspecialidad = new formEspecialidad();
            appEspecialidad.ShowDialog();
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPlan appPlan = new formPlan();
            appPlan.ShowDialog();
        }

        private void comisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formComision appComision = new formComision();
            appComision.ShowDialog();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formMateria appMateria = new formMateria();
            appMateria.ShowDialog();
        }

        private void cursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formCurso appCurso = new formCurso();
            appCurso.ShowDialog();
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formPersona appPersona = new formPersona();
            appPersona.ShowDialog();
        }

        private void inscripcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAlumnoInscripcion appInscripcion = new formAlumnoInscripcion();
            appInscripcion.ShowDialog();
        }

        private void moduloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formModulo appModulo = new formModulo();
            appModulo.ShowDialog();
        }

        private void moduloUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formModuloUsuario appModuloUsuario = new formModuloUsuario();
            appModuloUsuario.ShowDialog();
        }

        private void mnsPrincipal_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tsmnuNotas_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCursos reporteCursos = new ReporteCursos();
            reporteCursos.ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportePlanes reportePlanes = new ReportePlanes();
            reportePlanes.ShowDialog();
        }
    }
}
