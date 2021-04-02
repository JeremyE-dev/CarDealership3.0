using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ColorRepositoryQA : IColorRepository
    {
        public List<Color> colors { get; set; }

        public ColorRepositoryQA()
        {
            Color Black = new Color {ColorId = 1, ColorName = "Black" };
            Color White = new Color { ColorId = 2, ColorName = "White" };
            Color Red = new Color { ColorId = 3, ColorName = "Red" };
            Color Gray = new Color { ColorId = 4, ColorName = "Gray" };
            Color Blue = new Color { ColorId = 5, ColorName = "Blue" };
            colors.Add(Black);
            colors.Add(White);
            colors.Add(Red);
            colors.Add(Gray);
            colors.Add(Blue);
        }


        public IEnumerable<Color> GetAll()
        {
            var m = from model in colors
                    select model;

            return m;
        }
    }
}