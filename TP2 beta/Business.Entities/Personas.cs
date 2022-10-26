using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Personas: BusinessEntity
    {
        public int IDPersona { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Plan Plan { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public TipoPersonas TipoPersona { get; set; }

        public enum TipoPersonas
        {
            Docente, 
            Alumno,
            Administrador
        }




    }
}
