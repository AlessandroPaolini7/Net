using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic: BusinessLogic
    {
        public Data.Database.ModuloAdapter ModuloData { get; set; }

        public ModuloLogic()
        {
            ModuloData = new Data.Database.ModuloAdapter();
        }

        public List<Modulo> GetAll()
        {
            try
            {
                return ModuloData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Modulo GetOne(int ID)
        {
            try
            {
                return ModuloData.GetOne(ID);

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

                ModuloData.Delete(ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(Modulo modulo)
        {
            try
            {
                ModuloData.Save(modulo);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
