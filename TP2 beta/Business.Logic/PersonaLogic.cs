using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic: BusinessLogic
    {
        public Data.Database.PersonaAdapter PersonaData { get; set; }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }


        public Personas GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }
        public void Save(Personas persona)
        {
            PersonaData.Save(persona);
        }
    }
}
