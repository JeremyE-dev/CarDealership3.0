using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class EditVehicleVM
    {
        public Vehicle Vehicle { get; set; }

        //list and id pairs for dropdowns
        //Make
        public int SelectedMakeId { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        //Model
        public int SelectedVehicleModelId { get; set; }
        public IEnumerable<SelectListItem> VehicleModels { get; set; }

        //VehicleType
        public int SelectedVehicleTypeId { get; set; }
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        //BodyStyle
        public int SelectedBodyStyleId { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }

        //Transmission
        public int SelectedTransmissionId { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }

        //Color
        public int SelectedColorId { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }

        //Interior
        public int SelectedInteriorId { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }
    }
}