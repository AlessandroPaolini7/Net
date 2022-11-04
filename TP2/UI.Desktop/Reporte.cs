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
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> inscripciones = alumnoInscripcionLogic.GetAll();
            foreach(AlumnoInscripcion inscripcion in inscripciones)
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                Materia materia = materiaLogic.GetOne(inscripcion.Curso.Materia.IDMateria);
                inscripcion.MateriaCurso = materia.Descripcion;

                ComisionLogic comisionLogic = new ComisionLogic();
                Comision comision = comisionLogic.GetOne(inscripcion.Curso.Comision.IDComision);
                inscripcion.ComisionCurso = comision.Descripcion;
                inscripcion.AlumnoDesc = inscripcion.Alumno.Nombre + " " + inscripcion.Alumno.Apellido;
            }
            ReportDataSource rds = new ReportDataSource("AlumnoInscripcion", inscripciones);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
