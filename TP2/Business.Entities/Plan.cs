using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        public int IDPlan { get; set; }
        public string Descripcion { get; set; }
        public Especialidad Especialidad { get; set; }
        public string EspecialidadDesc { get; set; }
        public int IDEspecialidad { get; set; }
    }
}
