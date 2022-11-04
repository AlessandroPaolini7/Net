using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloUsuarioLogic: BusinessLogic
    {
        public Data.Database.ModuloUsuarioAdapter ModuloUsuarioData { get; set; }

        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new Data.Database.ModuloUsuarioAdapter();
        }

        public List<ModuloUsuario> GetAll()
        {
            try
            {

                return ModuloUsuarioData.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ModuloUsuario GetOne(int ID)
        {
            try
            {
                return ModuloUsuarioData.GetOne(ID);

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
                ModuloUsuarioData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(ModuloUsuario moduloUsuario)
        {
            try
            {
                ModuloUsuarioData.Save(moduloUsuario);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
