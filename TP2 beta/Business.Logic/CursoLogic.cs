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
            return CursoData.GetAll();
        }


        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
        public void Save(Curso curso)
        {
            CursoData.Save(curso);
        }
    }
}
