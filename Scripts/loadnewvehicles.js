$(document).ready(function () {

    // could just do on search click only display results if there is a search and not auot load them
    //getAllVehicles();

    $('#SearchButton').on('click', function () {
        getSearchResults();
    });


})

function getAllVehicles() {
   
    $.ajax({
        type: 'GET',
        url: 'http://localhost:50347/Inventory/New',
        
        success: function (data, status) {
            $.each(data, function (index, vehicle) {
               
                var VehicleId = vehicle.VehicleId;
                var Year = vehicle.Year;
                var Make = vehicle.MakeName;
                var Model = vehicle.VehicleModelName;
                var BodyStyle = vehicle.BodyStyle.BodyStyleName;
                var Interior = vehicle.Interior.InteriorName;
                var SalePrice = vehicle.SalePrice;
                var Transmission = vehicle.Transmission.TransmissionName;
                var Mileage = vehicle.Mileage;
                var MRSP = vehicle.MRSP;

                var Color = vehicle.Color.ColorName;
                var VIN = vehicle.VIN;

                var count = index;


                var divrowyearmakemodel = "divrowyearmakemodel" + count;
                var tableyearmakemodel = "tableyearmakemodel" + count;
                var colgroupyearmakemodel = "colgroupyearmakemodel" + count;
                var tbodyyearmakemodel = "tbodyyearmakemodel" + count;
                var tryearmakemodel = "tryearmakemodel" + count;

                var divrowimageandvehicledata = "divrowimageandvehicledata" + count;
                var divimage = "divimage" + count;

                var divvehicledata = "divvehicledata" + count;
                var tablevehicledata = "tablevehicledata" + count;
                var colgroupvehicledata = "colgroupvehicledata" + count;
                var tbodyvehicledata = "tbodyvehicledata" + count;
                var trbodyinteriorsaleprice = "trbodyinteriorsaleprice" + count;
                var trtransmileagemrsp = "trtransmileagemrsp" + count;
                var trcolorvinbutton = "trcolorvinbutton" + count;



                $containerDiv = $("<div></div>");
                $containerDiv.addClass('container');
                $containerDiv.css('border-style', 'groove');
                $containerDiv.css('margin-top', '5px');
                $containerDiv.css('padding-top', '5px'); // rendering corerctly

                $('body').append($containerDiv);

                //begin experiment
                //add year make model row to container
                $containerDiv.append('<div class ="row" id =' + divrowyearmakemodel + '> </div>');

                //add table to divrow
                $("#" + divrowyearmakemodel).append('<table style="width: 15%;" id =' + tableyearmakemodel + '></table>');

                //add colgroup to table
                $("#" + tableyearmakemodel).append('<colgroup id =' + colgroupyearmakemodel + '></colgroup>');
                //add colums to colgroup
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');

                //add tbody to table
                $("#" + tableyearmakemodel).append('<tbody id =' + tbodyyearmakemodel + '></tbody>');

                //add table row to table
                $("#" + tbodyyearmakemodel).append('<tr style="height: 40px;" id =' + tryearmakemodel + '></tr>');

                //add table data to table row
                $("#" + tryearmakemodel).append('<td>' + Year + '</td>');
                $("#" + tryearmakemodel).append('<td>' + Make + '</td>');
                $("#" + tryearmakemodel).append('<td>' + Model + '</td>');

                //add image row to container
                $containerDiv.append('<div class ="row" id =' + divrowimageandvehicledata + '> </div>');
                //add image div to row
                $("#" + divrowimageandvehicledata).append('<div class= "col-md-2" id =' + divimage + '></div>');
                //add image to image div
                $("#" + divimage).append('<img src="/images/dollar.png" alt="dollar sign" style="width:100px; class="center">');

                //add divvehicledata to divrowimage and vehicledata
                $("#" + divrowimageandvehicledata).append('<div class="col-md-10" id=' + divvehicledata + '></div>');
                //add tablevehicledata to divvehicledata
                $("#" + divvehicledata).append('<table style="width: 100%;" id=' + tablevehicledata + '></table>');
                //add colgoup to table
                $("#" + tablevehicledata).append('<colgroup id=' + colgroupvehicledata + '></colgroup>');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 8%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');

                //add tbody to table
                $("#" + tablevehicledata).append('<tbody id=' + tbodyvehicledata + '></tbody>');

                // add three table rows to t body
                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trbodyinteriorsaleprice + '></tr>');
                $("#" + trbodyinteriorsaleprice).append('<td ><b>Body Style:</b></td>');
                $("#" + trbodyinteriorsaleprice).append('<td style="text-align: left;">' + BodyStyle + '</td>');
                $("#" + trbodyinteriorsaleprice).append('<td><b>Interior:</b> </td>');
                $("#" + trbodyinteriorsaleprice).append('<td>' + Interior + '</td>');
                $("#" + trbodyinteriorsaleprice).append('<td><b>Sale Price:</b></td>');
                $("#" + trbodyinteriorsaleprice).append('<td>' + SalePrice + '</td>');

                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trtransmileagemrsp + '></tr>');
                $("#" + trtransmileagemrsp).append('<td ><b>Trans:</b></td>');
                $("#" + trtransmileagemrsp).append('<td style="text-align: left;">' + Transmission + '</td>');
                $("#" + trtransmileagemrsp).append('<td><b>Mileage:</b></td>');
                $("#" + trtransmileagemrsp).append('<td>' + Mileage + '</td>');
                $("#" + trtransmileagemrsp).append('<td><b>MRSP:</b></td>');
                $("#" + trtransmileagemrsp).append('<td>' + MRSP + '</td>');


                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trcolorvinbutton + '></tr>');
                $("#" + trcolorvinbutton).append('<td ><b>Color:</b></td>');
                $("#" + trcolorvinbutton).append('<td style="text-align: left;">' + Color + '</td>');
                $("#" + trcolorvinbutton).append('<td><b>VIN:</b></td>');
                $("#" + trcolorvinbutton).append('<td>' + VIN + '</td>');
                //$("#" + trcolorvinbutton).append('<td><button type="button" class="btn btn-primary">Details</button></td>'); // add edit button with vehicleid in it
                //$("#" + trcolorvinbutton).append('<td>@Html.ActionLink("edit","EditVehicle","Admin", new {id ='  + VehicleId  +' }, null) </td>');
                //$("#" + trcolorvinbutton).append('<td><a href='@Url.Action("EditVehicle", "Admin", new { id = "<id>" }) ' class="btn btn-primary">Click Me</a></td>');
                $("#" + trcolorvinbutton).append('<a href="/Inventory/Details/' + VehicleId + '"><button class="btn btn-primary">Details</button></a>');

            //@Html.ActionLink("edit","EditUser","Admin", new {id = @user.Id.ToString() }, null) 
            //<a href='@Url.Action("Action", "Controller")' class="btn btn-primary">Click Me</a>


            }); // end success:function
        },
        error: function () {
            alert('failure');
            //$('#errorMessages')
            //    .append($('<li>')
            //        .attr({ class: 'list-group-item list-group-item-danger' })
            //        .text('Error calling web service. Please try again later.'));
        }

    }); //end ajax call
}

function getSearchResults() {
    //clear the display
    var searchTerm = $('#search-term').val().toString(); //string
    if (searchTerm === "") {
        searchTerm = "0";
    }
    var minPrice = $('#MinPrice').val();//int
    var maxPrice = $('#MaxPrice').val();//int
    var minYear = $('#MinYear').val();//int
    var maxYear = $('#MaxYear').val();//int
    alert('made it inside method - search term is : ' + searchTerm);
    //change url to action that gets searched for vehicles
    $.ajax({
        type: 'GET',
        url: 'http://localhost:50347/Inventory/GetNewVehicleSearchResults/' + searchTerm + '/' + minPrice + '/' + maxPrice +'/'+ minYear +'/' + maxYear,

        success: function (data, status) {
            $.each(data, function (index, vehicle) {

                var VehicleId = vehicle.VehicleId;
                var Year = vehicle.Year;
                var Make = vehicle.MakeName;
                var Model = vehicle.VehicleModelName;
                var BodyStyle = vehicle.BodyStyle.BodyStyleName;
                var Interior = vehicle.Interior.InteriorName;
                var SalePrice = vehicle.SalePrice;
                var Transmission = vehicle.Transmission.TransmissionName;
                var Mileage = vehicle.Mileage;
                var MRSP = vehicle.MRSP;

                var Color = vehicle.Color.ColorName;
                var VIN = vehicle.VIN;

                var count = index;


                var divrowyearmakemodel = "divrowyearmakemodel" + count;
                var tableyearmakemodel = "tableyearmakemodel" + count;
                var colgroupyearmakemodel = "colgroupyearmakemodel" + count;
                var tbodyyearmakemodel = "tbodyyearmakemodel" + count;
                var tryearmakemodel = "tryearmakemodel" + count;

                var divrowimageandvehicledata = "divrowimageandvehicledata" + count;
                var divimage = "divimage" + count;

                var divvehicledata = "divvehicledata" + count;
                var tablevehicledata = "tablevehicledata" + count;
                var colgroupvehicledata = "colgroupvehicledata" + count;
                var tbodyvehicledata = "tbodyvehicledata" + count;
                var trbodyinteriorsaleprice = "trbodyinteriorsaleprice" + count;
                var trtransmileagemrsp = "trtransmileagemrsp" + count;
                var trcolorvinbutton = "trcolorvinbutton" + count;



                $containerDiv = $("<div></div>");
                $containerDiv.addClass('container');
                $containerDiv.css('border-style', 'groove');
                $containerDiv.css('margin-top', '5px');
                $containerDiv.css('padding-top', '5px'); // rendering corerctly

                $('body').append($containerDiv);

                //begin experiment
                //add year make model row to container
                $containerDiv.append('<div class ="row" id =' + divrowyearmakemodel + '> </div>');

                //add table to divrow
                $("#" + divrowyearmakemodel).append('<table style="width: 15%;" id =' + tableyearmakemodel + '></table>');

                //add colgroup to table
                $("#" + tableyearmakemodel).append('<colgroup id =' + colgroupyearmakemodel + '></colgroup>');
                //add colums to colgroup
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupyearmakemodel).append('<col span="1" style="width: 5%;">');

                //add tbody to table
                $("#" + tableyearmakemodel).append('<tbody id =' + tbodyyearmakemodel + '></tbody>');

                //add table row to table
                $("#" + tbodyyearmakemodel).append('<tr style="height: 40px;" id =' + tryearmakemodel + '></tr>');

                //add table data to table row
                $("#" + tryearmakemodel).append('<td>' + Year + '</td>');
                $("#" + tryearmakemodel).append('<td>' + Make + '</td>');
                $("#" + tryearmakemodel).append('<td>' + Model + '</td>');

                //add image row to container
                $containerDiv.append('<div class ="row" id =' + divrowimageandvehicledata + '> </div>');
                //add image div to row
                $("#" + divrowimageandvehicledata).append('<div class= "col-md-2" id =' + divimage + '></div>');
                //add image to image div
                $("#" + divimage).append('<img src="/images/dollar.png" alt="dollar sign" style="width:100px; class="center">');

                //add divvehicledata to divrowimage and vehicledata
                $("#" + divrowimageandvehicledata).append('<div class="col-md-10" id=' + divvehicledata + '></div>');
                //add tablevehicledata to divvehicledata
                $("#" + divvehicledata).append('<table style="width: 100%;" id=' + tablevehicledata + '></table>');
                //add colgoup to table
                $("#" + tablevehicledata).append('<colgroup id=' + colgroupvehicledata + '></colgroup>');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 8%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 5%;">');
                $("#" + colgroupvehicledata).append('<col span="1" style="width: 15%;">');

                //add tbody to table
                $("#" + tablevehicledata).append('<tbody id=' + tbodyvehicledata + '></tbody>');

                // add three table rows to t body
                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trbodyinteriorsaleprice + '></tr>');
                $("#" + trbodyinteriorsaleprice).append('<td ><b>Body Style:</b></td>');
                $("#" + trbodyinteriorsaleprice).append('<td style="text-align: left;">' + BodyStyle + '</td>');
                $("#" + trbodyinteriorsaleprice).append('<td><b>Interior:</b> </td>');
                $("#" + trbodyinteriorsaleprice).append('<td>' + Interior + '</td>');
                $("#" + trbodyinteriorsaleprice).append('<td><b>Sale Price:</b></td>');
                $("#" + trbodyinteriorsaleprice).append('<td>' + SalePrice + '</td>');

                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trtransmileagemrsp + '></tr>');
                $("#" + trtransmileagemrsp).append('<td ><b>Trans:</b></td>');
                $("#" + trtransmileagemrsp).append('<td style="text-align: left;">' + Transmission + '</td>');
                $("#" + trtransmileagemrsp).append('<td><b>Mileage:</b></td>');
                $("#" + trtransmileagemrsp).append('<td>' + Mileage + '</td>');
                $("#" + trtransmileagemrsp).append('<td><b>MRSP:</b></td>');
                $("#" + trtransmileagemrsp).append('<td>' + MRSP + '</td>');


                $("#" + tbodyvehicledata).append('<tr style="height: 40px;" id=' + trcolorvinbutton + '></tr>');
                $("#" + trcolorvinbutton).append('<td ><b>Color:</b></td>');
                $("#" + trcolorvinbutton).append('<td style="text-align: left;">' + Color + '</td>');
                $("#" + trcolorvinbutton).append('<td><b>VIN:</b></td>');
                $("#" + trcolorvinbutton).append('<td>' + VIN + '</td>');
                //$("#" + trcolorvinbutton).append('<td><button type="button" class="btn btn-primary">Details</button></td>');
                //$("#" + trcolorvinbutton).append('<td>@Html.ActionLink("edit","EditVehicle","Admin", new {id =' + VehicleId + ' }, null) </td>');
                $("#" + trcolorvinbutton).append('<a href="/Inventory/Details/' + VehicleId + '"><button class="btn btn-primary">Details</button></a>');
            }); // end success:function
        },
        error: function () {
            alert('failure');
            //$('#errorMessages')
            //    .append($('<li>')
            //        .attr({ class: 'list-group-item list-group-item-danger' })
            //        .text('Error calling web service. Please try again later.'));
        }

    }); //end ajax call


}