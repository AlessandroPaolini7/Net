using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic: BusinessLogic
    {
        public Data.Database.MateriaAdapter MateriaData { get; set; }

        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Materia GetOne(int ID)
        {
            try
            {
                return MateriaData.GetOne(ID);

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
                MateriaData.Delete(ID);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
