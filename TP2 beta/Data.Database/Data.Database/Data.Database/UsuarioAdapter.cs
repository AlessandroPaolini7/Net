using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM Usuarios", sqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario user = new Usuario();

                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["Clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];

                    usuarios.Add(user);
                }

                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            Usuario user = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM Usuarios WHERE id_usuario=@id", sqlConn);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["Clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario=@id",sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE usuarios SET nombre_usuario=@nombre_usuario, clave=@clave, "+
                    "habilitado=@habilitado, nombre=@nombre, apellido=@apellido, email=@email "+
                    "WHERE id_usuario=@id", sqlConn);

                cmdSave.Parameters.Add("@id",SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario",SqlDbType.VarChar,50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;

                cmdSave.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,nombre,apellido,email) "+
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email) "+
                    "select @@identity", sqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            try
            {
                if (usuario.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(usuario.ID);
                }
                else if (usuario.State == BusinessEntity.States.New)
                {
                    this.Insert(usuario);
                }
                else if (usuario.State == BusinessEntity.States.Modified)
                {
                    this.Update(usuario);
                }
                usuario.State = BusinessEntity.States.Unmodified;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorNombre(string nombre)
        {
            Usuario user = new Usuario();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM Usuarios WHERE nombre_usuario=@nombre", sqlConn);
                cmdUsuarios.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = nombre;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if (drUsuarios.Read())
                {
                    user.ID = (int)drUsuarios["id_usuario"];
                    user.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    user.Clave = (string)drUsuarios["Clave"];
                    user.Habilitado = (bool)drUsuarios["habilitado"];
                    user.Nombre = (string)drUsuarios["nombre"];
                    user.Apellido = (string)drUsuarios["apellido"];
                    user.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return user;
        }
    }
}
