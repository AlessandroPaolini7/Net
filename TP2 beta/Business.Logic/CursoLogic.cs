using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic: BusinessLogic
    {
        public Data.Database.CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);

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
                CursoData.Delete(ID);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
