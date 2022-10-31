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
    public partial class Reporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic inscripcionLogic = new AlumnoInscripcionLogic();
            Microsoft.Reporting.WebForms.ReportDataSource dataSource = new Microsoft.Reporting.WebForms.ReportDataSource("dataSet", inscripcionLogic.GetAll());
            this.reportViewer.LocalReport.DataSources.Add(dataSource);
        }
    }
}