using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CarDealership2.Models
{
    public enum PurchaseTypes
    {
        [Description("Cash")]
        Cash,
        [Description("Bank Finance")]
        BankFinance,
        [Description("Dealer Finance")]
        DealerFinance

    }
}