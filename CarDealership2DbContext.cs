using CarDealership2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarDealership2
{
    public class CarDealership2DbContext : IdentityDbContext<AppUser>
    {
        public CarDealership2DbContext() : base("CarDealership2")
        {

        }

        public DbSet<Make> Makes { get; set; }
       
        public DbSet<Model> Models { get; set; }

        public DbSet<Special> Specials { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<BodyStyle> BodyStyles { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Interior> Interiors { get; set;}

        public DbSet<Vehicle> Vehicles { get; set; }




    }
}