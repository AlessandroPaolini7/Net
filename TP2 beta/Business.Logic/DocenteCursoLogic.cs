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
            return DocenteCursoData.GetAll();
        }


        public DocenteCurso GetOne(int ID)
        {
            return DocenteCursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }
        public void Save(DocenteCurso docenteCurso)
        {
            DocenteCursoData.Save(docenteCurso);
        }
    }
}
