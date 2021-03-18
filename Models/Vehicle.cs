using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public Make Make { get; set; }

        public string MakeName { get; set; }

        public Model VehicleModel { get; set; }
        public string VehicleModelName { get; set; }

        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }

        public int Year{ get; set; }

        public int TransmissionId { get; set; }
        public string TransmissionName { get; set; }


        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int InteriorId { get; set; }

        public string InteriorName { get; set; }

        //just added

        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }



        public int Mileage { get; set; }

        public string VIN { get; set; }

        public int MRSP { get; set; }

        public int SalePrice { get; set; }

        public string Description { get; set; }

        public bool IsFeatured { get; set; }

        public string PhotoPath { get; set; }


        //transition models
        public virtual VehicleType Type { get; set; }
        public virtual BodyStyle BodyStyle { get; set; }
        public virtual Transmission Transmission { get; set; }

        public virtual Color Color { get; set; }

        public virtual Interior Interior { get; set; }

    }
}