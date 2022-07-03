using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        public int IDEspecialidad { get; set; }
        public string Descripcion { get; set; }
    }
}
