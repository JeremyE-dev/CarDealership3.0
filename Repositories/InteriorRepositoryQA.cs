using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class InteriorRepositoryQA : IInteriorRepository
    {
        public static List<Interior> interiors { get; set; }

        public InteriorRepositoryQA()
        {
            interiors = new List<Interior>();
            
            Interior Black = new Interior { InteriorId = 1, InteriorName = "Black" };
            Interior White = new Interior { InteriorId = 2, InteriorName = "White" };
            Interior Red = new Interior { InteriorId = 3, InteriorName = "Red" };
            Interior Gray = new Interior { InteriorId = 4, InteriorName = "Gray" };
            Interior Blue = new Interior { InteriorId = 5, InteriorName = "Blue" };

            interiors.Add(Black);
            interiors.Add(White);
            interiors.Add(Red);
            interiors.Add(Gray);
            interiors.Add(Blue);
        }
        public IEnumerable<Interior> GetAll()
        {
            var m = from model in interiors
                    select model;

            return m;
        }
    }
}