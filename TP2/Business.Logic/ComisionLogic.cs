using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic: BusinessLogic
    {
        public Data.Database.ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Comision GetOne(int ID)
        {
            try
            {
                return ComisionData.GetOne(ID);

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
                ComisionData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(Comision comision)
        {
            try
            {
                ComisionData.Save(comision);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
