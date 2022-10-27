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
    public class MateriaAdapter: Adapter
    {
        public List<Materia> GetAll()
        {

            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM Materias", sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia materia = new Materia();

                    materia.IDMateria = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HorasSemanales = (int)drMaterias["hs_semanales"];
                    materia.HorasTotales = (int)drMaterias["hs_totales"];

                    PlanAdapter planData = new PlanAdapter();
                    materia.Plan = planData.GetOne((int)drMaterias["id_plan"]);
                    materias.Add(materia);
                }

                drMaterias.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;

        }


        public Business.Entities.Materia GetOne(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM Materias WHERE id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    materia.IDMateria = (int)drMaterias["id_materia"];
                    materia.Descripcion = (string)drMaterias["desc_materia"];
                    materia.HorasSemanales = (int)drMaterias["hs_semanales"];
                    materia.HorasTotales = (int)drMaterias["hs_totales"];
                    Plan plan = new Plan();
                    plan.IDPlan = (int)drMaterias["id_plan"];
                    materia.Plan = plan;
                }
                drMaterias.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE Materias WHERE id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE Materias SET desc_materia=@descripcion, hs_semanales=@hs_semanales, hs_totales=@hs_totales ,id_plan=@id_plan " +
                    "WHERE id_materia=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.IDMateria;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.Plan.IDPlan;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Materias(desc_materia, hs_semanales, hs_totales , id_plan) " +
                    "values(@descripcion, @hs_semanales, @hs_totales, @id_plan) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HorasSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HorasTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.Plan.IDPlan;

                materia.IDMateria = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Materia materia)
        {
            try
            {
                if (materia.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(materia.IDMateria);
                }
                else if (materia.State == BusinessEntity.States.New)
                {
                    this.Insert(materia);
                }
                else if (materia.State == BusinessEntity.States.Modified)
                {
                    this.Update(materia);
                }
                materia.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

