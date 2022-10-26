using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        public int IDDictado { get; set; }
        public TipoCargos Cargo { get; set; }
        public Curso Curso { get; set; }
        public Personas Docente { get; set; }

        public enum TipoCargos
        {
            Profesor,
            Auxiliar
        }
    }
}
