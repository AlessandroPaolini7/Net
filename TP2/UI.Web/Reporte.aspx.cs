using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;


namespace UI.Web
{
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            //List<Business.Entities.AlumnoInscripcion> inscripciones = alumnoInscripcionLogic.GetAll();
            //foreach (Business.Entities.AlumnoInscripcion inscripcion in inscripciones)
            //{
            //    MateriaLogic materiaLogic = new MateriaLogic();
            //    Materia materia = materiaLogic.GetOne(inscripcion.Curso.Materia.IDMateria);
            //    inscripcion.MateriaCurso = materia.Descripcion;

            //    ComisionLogic comisionLogic = new ComisionLogic();
            //    Comision comision = comisionLogic.GetOne(inscripcion.Curso.Comision.IDComision);
            //    inscripcion.ComisionCurso = comision.Descripcion;
            //    inscripcion.AlumnoDesc = inscripcion.Alumno.Nombre + " " + inscripcion.Alumno.Apellido;
            //}
            //Microsoft.Reporting.WebForms.ReportDataSource dataSource = new Microsoft.Reporting.WebForms.ReportDataSource("AlumnoInscripcion", inscripciones);
            
            this.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Web.ReporteNotas.rdlc";
            this.ReportViewer1.ShowPrintButton = true;
            //this.ReportViewer1.LocalReport.DataSources.Clear();
            //this.ReportViewer1.LocalReport.DataSources.Add(dataSource);


        }
    }
}