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
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {

            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM Planes", sqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan plan = new Plan();

                    plan.IDPlan = (int)drPlanes["id_plan"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];



                    planes.Add(plan);
                }

                drPlanes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;

        }


        public Business.Entities.Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM Planes WHERE id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    plan.IDPlan = (int)drPlanes["id_plan"];
                    plan.IDEspecialidad = (int)drPlanes["id_especialidad"];
                    plan.Descripcion = (string)drPlanes["desc_plan"];
                }
                drPlanes.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE planes WHERE id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan=@descripcion, id_especialidad=@id_esp " +
                    "WHERE id_plan=@id", sqlConn);
                cmdSave.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.IDPlan;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Planes(desc_plan, id_especialidad) " +
                    "values(@descripcion, @id_esp) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;

                plan.IDPlan = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.IDPlan);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
