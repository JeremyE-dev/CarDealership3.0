using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class SpecialRepositoryProd : ISpecialRepository
    {
        public void Add(AddSpecialVM viewmodel)
        {
            var repository = new CarDealership2DbContext();
            Special model = new Special();
          
            model.Title = viewmodel.special.Title;
            //sets new id

            model.Description = viewmodel.special.Description;

            if(!repository.Specials.Any())
            {
                model.SpecialId = 1;
            }

            else
            {
                model.SpecialId = repository.Specials.Max(m => m.SpecialId) + 1;
            }
            
            repository.Specials.Add(model);
            repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var repository = new CarDealership2DbContext();

            //find the special with this id

            var specialToDelete = repository.Specials.FirstOrDefault(s => s.SpecialId == id);

            repository.Specials.Remove(specialToDelete);
            repository.SaveChanges();
        }

        public IEnumerable<Special> GetAll()
        {
            var repository = new CarDealership2DbContext();

            var s = from special in repository.Specials
                    select special;

            return s;
        }
    }
}