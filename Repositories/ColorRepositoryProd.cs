﻿using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ColorRepositoryProd : IColorRepository
    {
        public IEnumerable<Color> GetAll()
        {
            var repository = new CarDealership2DbContext(); //this repo has access to everything in the context

            var m = from model in repository.Colors
                    select model;

            return m;
        }
    }
}