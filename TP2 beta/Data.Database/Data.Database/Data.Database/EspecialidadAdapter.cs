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
    public class EspecialidadAdapter: Adapter
    {


        
        public List<Especialidad> GetAll()
        {   
        
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM Especialidades", sqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.IDEspecialidad = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];


                    especialidades.Add(esp);
                }

                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return especialidades;
           
        }

        
        public Business.Entities.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM Especialidades WHERE id_especialidad=@id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                if (drEspecialidades.Read())
                {
                    esp.IDEspecialidad = (int)drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                }
                drEspecialidades.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id",sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad=@descripcion "+
                    "WHERE id_especialidad=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.IDEspecialidad;
                cmdSave.Parameters.Add("@descripcion",SqlDbType.VarChar, 50).Value = esp.Descripcion;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Especialidades(desc_especialidad) "+
                    "values(@descripcion) "+
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = esp.Descripcion;
                esp.IDEspecialidad = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad esp)
        {
            try
            {
                if (esp.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(esp.IDEspecialidad);
                }
                else if (esp.State == BusinessEntity.States.New)
                {
                    this.Insert(esp);
                }
                else if (esp.State == BusinessEntity.States.Modified)
                {
                    this.Update(esp);
                }
                esp.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
