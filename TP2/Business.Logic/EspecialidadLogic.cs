using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic: BusinessLogic
    {
        public Data.Database.EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }

        
        public Especialidad GetOne(int ID)
        {
            try
            {
                return EspecialidadData.GetOne(ID);

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
                EspecialidadData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(Especialidad esp)
        {
            try
            {
                EspecialidadData.Save(esp);

            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
