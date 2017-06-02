$(document).ready(function () {
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var carID;
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/details/' + id,
        success: function (data) {
            var div = '<div class="container well">' +
                        '<div class="row">' +
                            '<div class="col-lg-3">' +
                                '<p>' + data.Year + " " + data.Make + " " + data.Model + '</p>' +
                                '<img src="' + data.Picture + '" height="100" width="100"/>' +
                            '</div>' +
                            '<div class="col-lg-3">' +
                                '<p>Body Style:' + " " + data.BodyStyle + '</p>' +
                                '<p>Trans:' + " " + data.Transmission + '</p>' +
                                '<p>Color:' + " " + data.Color + '</p>' +
                            '</div>' +
                            '<div class="col-lg-3">' +
                                '<p>Interior:' + " " + data.Color + '</p>' +
                                '<p>Mileage:' + " " + data.Mileage + '</p>' +
                                '<p>VIN:' + " " + data.VIN + '</p>' +
                            '</div>' +
                            '<div class="col-lg-3">' +
                                '<p>Sale Price:' + " " + data.Price + '</p>' +
                                '<p>MSRP:' + " " + data.MSRP + '</p>' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-lg-offset-3 col-lg-8">' +
                                '<p>Description:' + " " + data.Description + '<p/>' +
                                '<input type="hidden" id="HiddenCarID" value="' + data.CarID + '">' +
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-lg-offset-9 col-lg-3">' +
                            '<div>' +
                        '</div>' +
                    '</div>';
            $('#purchaseDetailsView').append(div);
            carID = data.CarID;
        },
        error: function () {
            alert('Failure!');
        }
    })
})

$('#PurchaseButton').click(function (event) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/purchase',
        data: JSON.stringify({
            CarID: $('#HiddenCarID').val(),
            Name: $('#PurchaseVehicleName').val(),
            Email: $('#PurchaseVehicleEmail').val(),
            Street1: $('#PurchaseVehicleStreet1').val(),
            City: $('#PurchaseVehicleCity').val(),
            Zipcode: $('#PurchaseVehicleZipcode').val(),
            Phone: $('#PurchaseVehiclePhone').val(),
            Street2: $('#PurchaseVehicleStreet2').val(),
            State: $('#PurchaseVehicleState').val(),
            PurchasePrice: $('#PurchaseVehiclePrice').val(),
            PurchaseType: $('#PurchaseVehicleType').val(),
            User: $('#SalesUser').val(),
            PiecesSold: 1
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            alert("You just bought a car!");
            window.location = "http://localhost:51045/sales";
        },
        error: function () {
            alert('Failure!');
        }
    })
})