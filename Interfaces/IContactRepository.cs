using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership2.Interfaces
{
    public interface IContactRepository
    {
        void Add(ContactVM viewModel);
    }
}
