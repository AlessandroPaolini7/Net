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
    public class ModuloUsuarioAdapter: Adapter
    {
        public List<ModuloUsuario> GetAll()
        {

            List<ModuloUsuario> moduloUsuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuarios = new SqlCommand("SELECT * FROM modulos_usuarios", sqlConn);

                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                while (drModuloUsuarios.Read())
                {
                    ModuloUsuario moduloUsuario = new ModuloUsuario();

                    moduloUsuario.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    moduloUsuario.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    moduloUsuario.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    moduloUsuario.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];

                    ModuloAdapter moduloData = new ModuloAdapter();
                    moduloUsuario.Modulo = moduloData.GetOne((int)drModuloUsuarios["id_modulo"]);
                    UsuarioAdapter usuarioData = new UsuarioAdapter();
                    moduloUsuario.Usuario = usuarioData.GetOne((int)drModuloUsuarios["id_usuario"]);

                    moduloUsuarios.Add(moduloUsuario);
                }

                drModuloUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos de usuarios", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return moduloUsuarios;

        }


        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario moduloUsuario = new ModuloUsuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModuloUsuarios = new SqlCommand("SELECT * FROM modulos_usuarios WHERE id_modulo_usuario=@id", sqlConn);
                cmdModuloUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModuloUsuarios = cmdModuloUsuarios.ExecuteReader();

                if (drModuloUsuarios.Read())
                {
                    moduloUsuario.PermiteAlta = (bool)drModuloUsuarios["alta"];
                    moduloUsuario.PermiteBaja = (bool)drModuloUsuarios["baja"];
                    moduloUsuario.PermiteConsulta = (bool)drModuloUsuarios["consulta"];
                    moduloUsuario.PermiteModificacion = (bool)drModuloUsuarios["modificacion"];

                    ModuloAdapter moduloData = new ModuloAdapter();
                    moduloUsuario.Modulo = moduloData.GetOne((int)drModuloUsuarios["id_modulo"]);
                    UsuarioAdapter usuarioData = new UsuarioAdapter();
                    moduloUsuario.Usuario = usuarioData.GetOne((int)drModuloUsuarios["id_usuario"]);
                }
                drModuloUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de los modulos de los usuarios", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return moduloUsuario;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE modulos_usuarios WHERE id_modulo_usuario=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo del usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET alta=@alta, baja=@baja, consulta=@consulta, modificacion=@modificacion, id_modulo=@id_modulo, id_usuario=@id_usuario" +
                    "WHERE id_modulo_usuario=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = moduloUsuario.IDModuloUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteAlta);
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteBaja);
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteConsulta);
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteModificacion);
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.Modulo.IDModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.Usuario.ID;


                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del modulo del usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO modulos_usuarios(alta, baja, consulta, modificacion, id_modulo, id_usuario) " +
                    "values(@alta, @baja, @consulta, @modificacion, @id_modulo, @id_usuario) " +
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteAlta);
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteBaja);
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteConsulta);
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = Convert.ToInt32(moduloUsuario.PermiteModificacion);
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = moduloUsuario.Modulo.IDModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = moduloUsuario.Usuario.ID;

                moduloUsuario.IDModuloUsuario = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el modulo del usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(ModuloUsuario moduloUsuario)
        {
            try
            {
                if (moduloUsuario.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(moduloUsuario.IDModuloUsuario);
                }
                else if (moduloUsuario.State == BusinessEntity.States.New)
                {
                    this.Insert(moduloUsuario);
                }
                else if (moduloUsuario.State == BusinessEntity.States.Modified)
                {
                    this.Update(moduloUsuario);
                }
                moduloUsuario.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
