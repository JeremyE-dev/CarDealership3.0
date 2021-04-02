using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class SpecialRepositoryQA : ISpecialRepository
    {
        public static List<Special> specials;

        public SpecialRepositoryQA()
        {
            specials = new List<Special>();
        }


        public void Add(AddSpecialVM viewmodel)
        {
            
            Special model = new Special();

            model.Title = viewmodel.special.Title;
            //sets new id

            model.Description = viewmodel.special.Description;

            if (!specials.Any())
            {
                model.SpecialId = 1;
            }

            else
            {
                model.SpecialId = specials.Max(m => m.SpecialId) + 1;
            }

            specials.Add(model);
            
        }


        public void Delete(int id)
        {
           

            //find the special with this id

            var specialToDelete = specials.FirstOrDefault(s => s.SpecialId == id);

            specials.Remove(specialToDelete);
            
        }

    

        public IEnumerable<Special> GetAll()
        {
          

            var s = from special in specials
                    select special;

            return s;
        }
    }
}