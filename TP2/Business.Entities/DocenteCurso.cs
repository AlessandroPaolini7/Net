using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        public TipoCargos Cargo { get; set; }
        public int IDCurso { get; set; }
        public int IDdocente { get; set; }

        public enum TipoCargos
        {
            Profesor,
            Auxiliar
        }
    }
}
