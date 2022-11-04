using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario GetOne(int ID)
        {
            try
            {
                return UsuarioData.GetOne(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                UsuarioData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Save(Usuario user)
        {
            try
            {

                UsuarioData.Save(user);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public Usuario BuscarPorNombre(string nombre)
        {
            try
            {
                return UsuarioData.BuscarPorNombre(nombre);

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
