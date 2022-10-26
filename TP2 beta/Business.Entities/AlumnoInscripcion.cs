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
        public Curso Curso { get; set; }
        public int Nota { get; set; }
    }
}
