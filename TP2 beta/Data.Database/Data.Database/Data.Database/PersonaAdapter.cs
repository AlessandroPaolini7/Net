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
    public class PersonaAdapter: Adapter
    {
        public List<Personas> GetAll()
        {

            List<Personas> personas = new List<Personas>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM Personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Personas persona = new Personas();

                    persona.IDPersona = (int)drPersonas["id_persona"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (Personas.TipoPersonas)drPersonas["tipo_persona"];

                    PlanAdapter planData = new PlanAdapter();
                    persona.Plan = planData.GetOne((int)drPersonas["id_plan"]);
                    personas.Add(persona);
                }

                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;

        }


        public Business.Entities.Personas GetOne(int ID)
        {
            Personas persona = new Personas();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM Personas WHERE id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    persona.IDPersona = (int)drPersonas["id_persona"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.TipoPersona = (Personas.TipoPersonas)drPersonas["tipo_persona"];

                    PlanAdapter planData = new PlanAdapter();
                    persona.Plan = planData.GetOne((int)drPersonas["id_plan"]);
                }
                drPersonas.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE Personas WHERE id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Personas persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE Personas SET apellido=@apellido, nombre=@nombre, direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan" +
                    "WHERE id_persona=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.IDPersona;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.IDPlan;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Personas persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO Personas(apellido, nombre, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
                    "values(@apellido, @nombre, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.Plan.IDPlan;

                persona.IDPersona = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Personas persona)
        {
            try
            {
                if (persona.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(persona.IDPersona);
                }
                else if (persona.State == BusinessEntity.States.New)
                {
                    this.Insert(persona);
                }
                else if (persona.State == BusinessEntity.States.Modified)
                {
                    this.Update(persona);
                }
                persona.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
