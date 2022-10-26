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
    public class DocenteCursoAdapter: Adapter
    {

        public List<DocenteCurso> GetAll()
        {

            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("SELECT * FROM docentes_cursos", sqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso docenteCurso = new DocenteCurso();

                    docenteCurso.IDDictado = (int)drDocenteCursos["id_dictado"];
                    docenteCurso.Cargo = (DocenteCurso.TipoCargos)drDocenteCursos["cargo"];

                    CursoAdapter cursoData = new CursoAdapter();
                    docenteCurso.Curso = cursoData.GetOne((int)drDocenteCursos["id_curso"]);
                    PersonaAdapter personaData = new PersonaAdapter();
                    docenteCurso.Docente = personaData.GetOne((int)drDocenteCursos["id_docente"]);

                    docenteCursos.Add(docenteCurso);
                }

                drDocenteCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de dictados", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCursos;

        }


        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso = new DocenteCurso();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id", sqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                if (drDocenteCursos.Read())
                {
                    docenteCurso.IDDictado = (int)drDocenteCursos["id_dictado"];
                    docenteCurso.Cargo = (DocenteCurso.TipoCargos)drDocenteCursos["cargo"];

                    CursoAdapter cursoData = new CursoAdapter();
                    docenteCurso.Curso = cursoData.GetOne((int)drDocenteCursos["id_curso"]);
                    PersonaAdapter personaData = new PersonaAdapter();
                    docenteCurso.Docente = personaData.GetOne((int)drDocenteCursos["id_docente"]);
                }
                drDocenteCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCurso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;


                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso=@id_curso, id_docente=@id_docente, cargo=@cargo" +
                    "WHERE id_dictado=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.IDDictado;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.Curso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.Docente.IDPersona;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = Convert.ToInt32(docenteCurso.Cargo);



                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos(id_curso, id_docente, cargo) " +
                    "values(@id_curso, @id_docente, @cargo) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.Curso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.Docente.IDPersona;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = Convert.ToInt32(docenteCurso.Cargo);

                docenteCurso.IDDictado = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el dictado", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.IDDictado);
            }
            else if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }
    }
}
