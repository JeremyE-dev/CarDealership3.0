$(document).ready(function () {
    // make ajax call to dvdv display table here
    getDVDInfo();
    $('#add-form').hide();
    $('#edit-form').hide();
    $('#display-dvd-details-form').hide();

    $('#nav-create-dvd-button').on('click', function () {
        showCreateDVDWindow();
    });
})

function getDVDInfo() {
    //clearDVDDisplay();

    
    //var DVDdisplaytable = $('#DVDdisplaycontentRows');
    var VEHICLEdisplaytable = $('#VEHICLEdisplaycontentRows');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:50347/Admin/GetAllVehicles',
        //url: 'http://localhost:62394/dvds/all',
        success: function (data, status) {
            $.each(data, function (index, vehicle) {
                //var title = dvd.Title;
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
             
                var row = '<tr>';
                
                row += '<td>' + Year + '</td>';
                row += '<td>' + Make + '</td>';
                row += '<td>' + Model + '</td>';
                row += '<td>' + BodyStyle + '</td>';
                row += '<td>' + Interior + '</td>';
                row += '<td>' + SalePrice + '</td>';
                row += '<td>' + Transmission + '</td>';
                row += '<td>' + Mileage + '</td>';
                row += '<td>' + MRSP + '</td>';
                row += '<td>' + Color + '</td>';
                row += '<td>' + VIN + '</td>';

                //row += '<td><a onclick = "getDVDToEdit(' + dvdID + ')">Edit + "|"</a></td>'; // "|" '<td><a onclick = "deleteDVD(' + dvdID + ')">Delete</a></td>';
                //row += '<td><a onclick = "confirmDelete(' + dvdID + ')">Delete</a></td>';
                //row += '<td><a onclick="getDVDToEdit(' + dvdID + ')"> <u> Edit</u> </a>' + " | " + '<a onclick="deleteDVD(' + dvdID + ')"> <u> Delete</u></a></td>';

                VEHICLEdisplaytable.append(row);

                //$form = $("<form></form>");
                //$form.append('<div class="form-group">');
                //$form.append('<label for="exampleInputEmail1">Email address</label>');
                //$form.append('<input type="email" class="form-horizontal no-outline" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">');
                //$form.append('<label for="Year">Year: </label>');
                //$form.append('<input type="text" class="form-horizontal no-outline" id="Year" aria-describedby="emailHelp" value= Year>');

                //$form.append('<input type="button" value="button">');
                //$form.append('</div">');
                //$('body').append($form);

                $containerDiv = $("<div></div>");
                $containerDiv.addClass('container');
                $containerDiv.css('border-style', 'groove');
                $containerDiv.css('margin-top', '25px');
                $containerDiv.css('padding-top', '25px');

                $containerDiv.append('<div class="row">');
                $containerDiv.append('<table style="width: 15%;">');
                $containerDiv.append('<colgroup>');
                $containerDiv.append('<col span="1" style="width: 5%;">');
                $containerDiv.append('<col span="1" style="width: 5%;">');
                $containerDiv.append('<col span="1" style="width: 5%;">');
                $containerDiv.append('</colgroup>');

                $containerDiv.append('<tbody id="tbody1">');
                $containerDiv.append('<tr style="height: 40px;">');
                $containerDiv.append('<td>' + 2016 + '</td>');
                $containerDiv.append('<td>' + Make + '</td>');
                $containerDiv.append('<td>' + Model + '</td>');
                $containerDiv.append('</tr>');
                $containerDiv.append('</tbody>');

                $containerDiv.append('</table>');
                $containerDiv.append('</div>');



                $containerDiv.append('<div class="row">');
                $containerDiv.append('<div class="col-md-1">');
                $containerDiv.append('<img src="/images/dollar.png" alt="dollar sign" style="width:100px; class="center">');
                $containerDiv.append('</div>');

                $containerDiv.append('<div class="col-md-10">');

                $containerDiv.append('<table style="width: 100%;">');
                $containerDiv.append('<colgroup>');
                $containerDiv.append('<col span="1" style="width: 8%;">');
                $containerDiv.append('<col span="1" style="width: 15%;">');
                $containerDiv.append('<col span="1" style="width: 5%;">');
                $containerDiv.append('<col span="1" style="width: 15%;">');
                $containerDiv.append('<col span="1" style="width: 5%;">');
                $containerDiv.append('<col span="1" style="width: 15%;">');
                $containerDiv.append('</colgroup>');

                $containerDiv.append('<tbody id="tbody2">');

                $containerDiv.append('<tr style="height: 40px;">');
                $containerDiv.append('<td ><b>Body Style:</b></td>');
                $containerDiv.append('<td style="text-align: left;">' + BodyStyle + '</td>');
                $containerDiv.append('<td><b>Interior:</b> </td>');
                $containerDiv.append('<td>' + Interior + '</td>');
                $containerDiv.append('<td><b>Sale Price:</b></td>');
                $containerDiv.append('<td>' + SalePrice +'</td>');
                $containerDiv.append(' </tr>');

                $containerDiv.append('<tr style="height: 40px;">');
                $containerDiv.append('<td ><b>Trans:</b></td>');
                $containerDiv.append('<td style="text-align: left;">' + Transmission +'</td>');
                $containerDiv.append('<td><b>Mileage:</b></td>');
                $containerDiv.append('<td>' + Mileage + '</td>');
                $containerDiv.append('<td><b>MRSP:</b></td>');
                $containerDiv.append('<td>' + MRSP + '</td>');
                $containerDiv.append('</tr>');

                $containerDiv.append('<tr style="height: 40px;">');
                $containerDiv.append('<td ><b>Color:</b></td>');
                $containerDiv.append('<td style="text-align: left;">' + Color + '</td>');
                $containerDiv.append('<td><b>VIN:</b></td>');
                $containerDiv.append('<td>' +VIN+'</td>');
                $containerDiv.append(' <td><button type="button" class="btn btn-primary">Details</button></td>  ');
                $containerDiv.append('</tr>');


                $containerDiv.append('</tbody>');
                $containerDiv.append('</table>');
                $containerDiv.append('</div>');
                $containerDiv.append('</div>');

                $('body').append($containerDiv);

                //var MakeModelYearTable = $('#tbody1');

                //var tbody1row = '<tr style="height: 40px;">';
                //tbody1row += '<td style="text-align: left;">' + Year + '</td>';
                //tbody1row += '<td style="text-align: left;">' + Make + '</td>';
                //tbody1row += '<td style="text-align: left;">' + Model + '</td>';

                //MakeModelYearTable.append(tbody1row);


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