﻿using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ModelRepositoryQA : IModelRepository
    {
        public void Add(AddModelVM viewmodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}