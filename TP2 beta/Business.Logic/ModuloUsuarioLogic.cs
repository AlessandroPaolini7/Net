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
            return ModuloUsuarioData.GetAll();
        }


        public ModuloUsuario GetOne(int ID)
        {
            return ModuloUsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ModuloUsuarioData.Delete(ID);
        }
        public void Save(ModuloUsuario moduloUsuario)
        {
            ModuloUsuarioData.Save(moduloUsuario);
        }
    }
}
