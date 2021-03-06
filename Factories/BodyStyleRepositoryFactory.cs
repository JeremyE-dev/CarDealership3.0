using CarDealership2.Interfaces;
using CarDealership2.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarDealership2.Factories
{
    public class BodyStyleRepositoryFactory
    {
        public static IBodyStyleRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new BodyStyleRepositoryQA();

                case "PROD":
                    return new BodyStyleRepositoryProd();

                default:
                    throw new Exception("Mode in web config is not valid");

            }

        }
    }
}