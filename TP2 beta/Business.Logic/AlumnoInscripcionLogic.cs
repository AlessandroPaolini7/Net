using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic: BusinessLogic
    {
        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData { get; set; }

        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return AlumnoInscripcionData.GetAll();
        }


        public AlumnoInscripcion GetOne(int ID)
        {
            return AlumnoInscripcionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            AlumnoInscripcionData.Delete(ID);
        }
        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            AlumnoInscripcionData.Save(alumnoInscripcion);
        }
    }
}
