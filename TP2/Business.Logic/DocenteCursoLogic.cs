using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic: BusinessLogic
    {
        public Data.Database.DocenteCursoAdapter DocenteCursoData { get; set; }

        public DocenteCursoLogic()
        {
            DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            try
            {
                return DocenteCursoData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DocenteCurso GetOne(int ID)
        {
            try
            {
                return DocenteCursoData.GetOne(ID);

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
                DocenteCursoData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(DocenteCurso docenteCurso)
        {
            try
            {
                DocenteCursoData.Save(docenteCurso);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
