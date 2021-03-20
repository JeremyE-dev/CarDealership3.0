using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Interfaces
{
    public interface IPurchaseRepository
    {
        void Add(PurchaseVM viewmodel);
    }
}