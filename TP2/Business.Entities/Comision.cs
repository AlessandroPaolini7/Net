using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Comision: BusinessEntity
    {
        public int IDComision { get; set; }
        public int AnioEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public Plan Plan { get; set; }
        public string PlanDesc { get; set; }
    }
}
