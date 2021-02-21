using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ModelRepositoryQA : IModelRepository
    {
        public void Add(string modelname, string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}