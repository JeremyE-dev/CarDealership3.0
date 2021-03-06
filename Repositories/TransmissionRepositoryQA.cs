using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership2.Repositories
{
    public class TransmissionRepositoryQA : ITransmissionRepository
    {
        public IEnumerable<Transmission> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
