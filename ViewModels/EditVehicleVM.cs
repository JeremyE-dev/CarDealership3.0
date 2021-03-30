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
        public string SelectedMakeId { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        //Model
        public string SelectedVehicleModelId { get; set; }
        public IEnumerable<SelectListItem> VehicleModels { get; set; }

        //VehicleType
        public string SelectedVehicleTypeId { get; set; }
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

        //BodyStyle
        public string SelectedBodyStyleId { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }

        //Transmission
        public string SelectedTransmissionId { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }

        //Color
        public string SelectedColorId { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }

        //Interior
        public string SelectedInteriorId { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }

        public string selectedColorName { get; set; }

        public string selectedInteriorName { get; set; }

        public string selectedTransmissionName { get; set; }

        public string selectedBodyStyleName { get; set; }

        public string selectedVehicleTypeName { get; set; }

        public string selectedMakeName { get; set; }

        public string selectedModelName { get; set; }

        public HttpPostedFileBase UploadedFile { get; set; }
    }
}