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
        public static List<Transmission> transmissions { get; set; }

        public TransmissionRepositoryQA()
        {
            Transmission Manual = new Transmission { TransmissionId = 1, TransmissionName = "Manual" };
            Transmission Automatic = new Transmission { TransmissionId = 2, TransmissionName = "Automatic" };

        }
        public IEnumerable<Transmission> GetAll()
        {

            var m = from model in transmissions
                    select model;


            return m;

        }
    }
}
