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
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {

            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM Cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso curso = new Curso();

                    curso.IDCurso = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                    MateriaAdapter materiaData = new MateriaAdapter();
                    curso.Materia = materiaData.GetOne((int)drCursos["id_materia"]);

                    ComisionAdapter comisionData = new ComisionAdapter();
                    curso.Comision = comisionData.GetOne((int)drCursos["id_comision"]);

                    cursos.Add(curso);
                }

                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return cursos;

        }


        public Business.Entities.Curso GetOne(int ID)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("SELECT * FROM Cursos WHERE id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.IDCurso = (int)drCursos["id_curso"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.Cupo = (int)drCursos["cupo"];

                    Materia materia = new Materia();
                    materia.IDMateria = (int)drCursos["id_materia"];
                    curso.Materia = materia;

                    Comision comision = new Comision();
                    comision.IDComision = (int)drCursos["id_comision"];
                    curso.Comision = comision;
                }
                drCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE Cursos WHERE id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE Cursos SET anio_calendario=@anio_calendario, cupo=@cupo, id_materia=@id_materia, id_comision=@id_comision " +
                    "WHERE id_curso=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.IDCurso;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.Materia.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.Comision.IDComision;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Cursos(anio_calendario, cupo, id_materia, id_comision) " +
                    "values(@anio_calendario, @cupo, @id_materia, @id_comision) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.Materia.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.Comision.IDComision;

                curso.IDCurso = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Curso curso)
        {

            try
            {
                if (curso.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(curso.IDCurso);
                }
                else if (curso.State == BusinessEntity.States.New)
                {
                    this.Insert(curso);
                }
                else if (curso.State == BusinessEntity.States.Modified)
                {
                    this.Update(curso);
                }
                curso.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
