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
            List<Business.Entities.AlumnoInscripcion> inscripciones = AlumnoInscripcionData.GetAll();
            foreach (Business.Entities.AlumnoInscripcion inscripcion in inscripciones)
            {
                MateriaLogic materiaLogic = new MateriaLogic();
                Materia materia = materiaLogic.GetOne(inscripcion.Curso.Materia.IDMateria);
                inscripcion.MateriaCurso = materia.Descripcion;

                ComisionLogic comisionLogic = new ComisionLogic();
                Comision comision = comisionLogic.GetOne(inscripcion.Curso.Comision.IDComision);
                inscripcion.ComisionCurso = comision.Descripcion;
                inscripcion.AlumnoDesc = inscripcion.Alumno.Nombre + " " + inscripcion.Alumno.Apellido;
            }
            return inscripciones;
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
