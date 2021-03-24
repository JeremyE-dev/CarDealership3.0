using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Helpers
{
    public class Helper
    {
        public bool IsNumber (string x)
        {
            int myInt;
            bool result = int.TryParse(x, out myInt);

            return result;

        }
    }
}