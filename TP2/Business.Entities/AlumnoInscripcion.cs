using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {

        public string Condicion { get; set; }
        public int IDAlumno { get; set; }
        public string IDCurso { get; set; }
        public string Nota { get; set; }

    }
}