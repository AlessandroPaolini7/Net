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
    public class ComisionAdapter: Adapter
    {
        public List<Comision> GetAll()
        {

            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM Comisiones", sqlConn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision comision = new Comision();

                    comision.IDComision = (int)drComisiones["id_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.IDPlan = (int)drComisiones["id_plan"];



                    comisiones.Add(comision);
                }

                drComisiones.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            Comision comision = new Comision();
            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM Comisiones WHERE id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    comision.IDComision = (int)drComisiones["id_comision"];
                    comision.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comision.Descripcion = (string)drComisiones["desc_comision"];
                    comision.IDPlan = (int)drComisiones["id_plan"];
                }
                drComisiones.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comision;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE Comisiones WHERE id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision=@descripcion, id_plan=@id_plan, anio_especialidad=@anio " +
                    "WHERE id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.IDComision;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = comision.Descripcion;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Comisiones(desc_comision, id_plan, anio_especialidad) " +
                    "values(@descripcion, @id_plan, @anio) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = comision.Descripcion;

                comision.IDComision = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            try
            {
                if (comision.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(comision.IDComision);
                }
                else if (comision.State == BusinessEntity.States.New)
                {
                    this.Insert(comision);
                }
                else if (comision.State == BusinessEntity.States.Modified)
                {
                    this.Update(comision);
                }
                comision.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
