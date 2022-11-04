using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter: Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {

            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdALumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);

                SqlDataReader drALumnoInscripciones = cmdALumnoInscripciones.ExecuteReader();

                while (drALumnoInscripciones.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();

                    alumnoInscripcion.IDInscripcion = (int)drALumnoInscripciones["id_inscripcion"];
                    alumnoInscripcion.Condicion = (string)drALumnoInscripciones["condicion"];
                    if(drALumnoInscripciones["nota"] != null)
                    {
                        alumnoInscripcion.Nota = (int)drALumnoInscripciones["nota"];
                    }
                    

                    PersonaAdapter personaData = new PersonaAdapter();
                    alumnoInscripcion.Alumno = personaData.GetOne((int)drALumnoInscripciones["id_alumno"]);

                    CursoAdapter cursoData = new CursoAdapter();
                    alumnoInscripcion.Curso = cursoData.GetOne((int)drALumnoInscripciones["id_curso"]);


                    alumnoInscripciones.Add(alumnoInscripcion);
                }

                drALumnoInscripciones.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista inscripciones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripciones;

        }


        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();

                SqlCommand cmdALumnoInscripciones = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion=@id", sqlConn);
                cmdALumnoInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drALumnoInscripciones = cmdALumnoInscripciones.ExecuteReader();

                if (drALumnoInscripciones.Read())
                {
                    alumnoInscripcion.IDInscripcion = (int)drALumnoInscripciones["id_inscripcion"];
                    alumnoInscripcion.Condicion = (string)drALumnoInscripciones["condicion"];
                    alumnoInscripcion.Nota = (int)drALumnoInscripciones["nota"];

                    PersonaAdapter personaData = new PersonaAdapter();
                    alumnoInscripcion.Alumno = personaData.GetOne((int)drALumnoInscripciones["id_alumno"]);

                    CursoAdapter cursoData = new CursoAdapter();
                    alumnoInscripcion.Curso = cursoData.GetOne((int)drALumnoInscripciones["id_curso"]);
                }
                drALumnoInscripciones.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnoInscripcion;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE alumnos_inscripciones WHERE id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@id_alumno, id_curso=@id_curso, condicion=@condicion, nota=@nota " +
                    "WHERE id_inscripcion=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = alumnoInscripcion.IDInscripcion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.Alumno.IDPersona;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.Curso.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion alumnoInscripcion)
        {

            try { 
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones(condicion, nota, id_alumno, id_curso) " +
                    "values(@condicion, @nota, @id_alumno, @id_curso) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.Alumno.IDPersona;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.Curso.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = alumnoInscripcion.Condicion;

                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;

                alumnoInscripcion.IDInscripcion = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la inscripcion", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(alumnoInscripcion.IDInscripcion);
                }
                else if (alumnoInscripcion.State == BusinessEntity.States.New)
                {
                    this.Insert(alumnoInscripcion);
                }
                else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
                {
                    this.Update(alumnoInscripcion);
                }
                alumnoInscripcion.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

               throw;
            }
            
        }

    }
}
