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
    public class ModuloAdapter: Adapter
    {
        public List<Modulo> GetAll()
        {

            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("SELECT * FROM modulos", sqlConn);

                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo modulo = new Modulo();

                    modulo.IDModulo = (int)drModulos["id_modulo"];
                    modulo.Descripcion = (string)drModulos["desc_modulo"];

                    modulos.Add(modulo);
                }

                drModulos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;

        }


        public Business.Entities.Modulo GetOne(int ID)
        {
            Modulo modulo = new Modulo();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("SELECT * FROM Modulos WHERE id_modulo=@id", sqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    modulo.IDModulo = (int)drModulos["id_modulo"];
                    modulo.Descripcion = (string)drModulos["desc_modulo"];
                }
                drModulos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del modulo", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulo;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE modulos WHERE id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo=@descripcion " +
                    "WHERE id_modulo=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.IDModulo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = modulo.Descripcion;


                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del modulo", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Modulos(desc_modulo) " +
                    "values(@descripcion) " +
                    "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = modulo.Descripcion;

                modulo.IDModulo = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el modulo", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Modulo modulo)
        {
            try
            {
                if (modulo.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(modulo.IDModulo);
                }
                else if (modulo.State == BusinessEntity.States.New)
                {
                    this.Insert(modulo);
                }
                else if (modulo.State == BusinessEntity.States.Modified)
                {
                    this.Update(modulo);
                }
                modulo.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
