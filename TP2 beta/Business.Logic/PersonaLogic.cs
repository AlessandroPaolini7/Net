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
            try
            {
                return PersonaData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Personas GetOne(int ID)
        {
            try
            {
                return PersonaData.GetOne(ID);

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
                PersonaData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(Personas persona)
        {
            try
            {
                PersonaData.Save(persona);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
