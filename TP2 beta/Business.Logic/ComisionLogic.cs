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
            return ComisionData.GetAll();
        }


        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }
        public void Save(Comision comision)
        {
            ComisionData.Save(comision);
        }

    }
}
