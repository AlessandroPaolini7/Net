using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        public Data.Database.PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();

            }
            catch (Exception)
            {

                throw;
            }
        }


        public Plan GetOne(int ID)
        {
            try
            {
                return PlanData.GetOne(ID);

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
                PlanData.Delete(ID);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Save(Plan plan)
        {
            try
            {

                PlanData.Save(plan);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
