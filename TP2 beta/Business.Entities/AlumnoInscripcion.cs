using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion:BusinessEntity
    {
        public int IDInscripcion { get; set; }
        public string Condicion { get; set; }
        public Personas Alumno { get; set; }
        public string AlumnoDesc { get; set; }
        
        public Curso Curso { get; set; }
        public int CursoID { get; set; }
        public int Nota { get; set; }

        #region datos_reporte
        public string MateriaCurso { get; set; }
        public string ComisionCurso { get; set; }

        #endregion
    }
}
