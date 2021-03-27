﻿using CarDealership2.Interfaces;
using CarDealership2.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarDealership2.Factories
{
    public class SalesReportRepositoryFactory
    {
        public static ISalesReportRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new SalesReportRepositoryQA();

                case "PROD":
                    return new SalesReportRepositoryProd();

                default:
                    throw new Exception("Mode in web config is not valid");

            }
        }
    }
}