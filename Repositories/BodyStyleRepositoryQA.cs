using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{

      public class BodyStyleRepositoryQA : IBodyStyleRepository
    {


        public List<BodyStyle> bodyStyles { get; set; }

        public BodyStyleRepositoryQA()       
        {
            BodyStyle Car = new BodyStyle { BodyStyleId = 1, BodyStyleName = "Car"};
            BodyStyle Truck = new BodyStyle { BodyStyleId = 2, BodyStyleName = "Truck" };
            BodyStyle Van = new BodyStyle { BodyStyleId = 2, BodyStyleName = "Van" };
            BodyStyle SUV = new BodyStyle { BodyStyleId = 2, BodyStyleName = "SUV" };

            bodyStyles.Add(Car);
            bodyStyles.Add(Truck);
            bodyStyles.Add(Van);
            bodyStyles.Add(SUV);
        }

        public IEnumerable<BodyStyle> GetAll()
        {
            var m = from model in bodyStyles
                    select model;

            return m;
        }
    }
}