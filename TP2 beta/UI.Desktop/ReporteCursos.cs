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
    public partial class ReporteCursos : Form
    {
        public ReporteCursos()
        {
            InitializeComponent();
        }

        private void ReporteCursos_Load(object sender, EventArgs e)
        {
            CursoLogic cursoLogic = new CursoLogic();
            List<Curso> cursos = cursoLogic.GetAll();
            foreach (Curso curso in cursos)
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                Materia materia = materiaLogic.GetOne(curso.Materia.IDMateria);
                curso.MateriaDesc = materia.Descripcion;

                ComisionLogic comisionLogic = new ComisionLogic();
                Comision comision = comisionLogic.GetOne(curso.Comision.IDComision);
                curso.ComisionDesc = comision.Descripcion;
            }
            ReportDataSource rds = new ReportDataSource("Curso", cursos);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportCursos.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
