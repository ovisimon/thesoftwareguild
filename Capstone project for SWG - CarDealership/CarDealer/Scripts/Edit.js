$(document).ready(function () {
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    getMakes();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/details/' + id,
        success: function (data) {
            $('#EditCarID').val(data.CarID);
            $('#EditMake').val(data.MakeID);
            if (data.Mileage == 0) {
                $('#EditType').val("New");
            }
            else {
                $('#EditType').val("Used");
            }
            var pic = '<img src="' + data.Picture + '" height="100px" width="100px">';
            $('#EditYear').val(data.Year);
            $('#EditColor').val(data.ColorID);
            $('#EditMileage').val(data.Mileage);
            $('#EditMSRP').val(data.MSRP);
            $('#EditModel').val(data.ModelID);
            $('#EditBodyStyle').val(data.BodyStyleID);
            $('#EditTransmission').val(data.TransmissionID);
            $('#EditInterior').val(data.InteriorID);
            $('#EditVIN').val(data.VIN);
            $('#EditPrice').val(data.Price);
            $('#EditDescription').val(data.Description);
            $('#EditOldImage').append(pic);
            $('#EditNewImage').val(data.Picture);
            $('#EditFeatured').prop('checked', data.Featured)
            $('#EditStock').val(data.Stock);
        },
        error: function () {
            alert("Failure!");
        }
    })
})


var url = window.location.pathname;
var id = url.substring(url.lastIndexOf('/') + 1);
var check = $("#EditFeature").is(":checked");

$('#EditSaveButton').click(function (event) {
    $.ajax({
        type: 'PUT',
        url: 'http://localhost:51045/edit/',
        data: JSON.stringify({
            CarID: $('#EditCarID').val(),
            MakeID: $('#EditMake').val(),
            ModelID: $('#EditModel').val(),
            Mileage: $('#EditMileage').val(),
            VIN: $('#EditVIN').val(),
            Price: $('#EditPrice').val(),
            Stock: $('#EditStock').val(),
            MSRP: $('#EditMSRP').val(),
            Year: $('#EditYear').val(),
            Picture: $('#EditNewImage').val(),
            Description: $('#EditDescription').val(),
            TransmissionID: $('#EditTransmission').val(),
            Transmission: $('#EditTransmission').val(),
            BodyStyleID: $('#EditBodyStyle').val(),
            ColorID: $('#EditColor').val(),
            InteriorID: $('#EditInterior').val(),
            Featured: $("#EditFeatured").is(":checked")
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            window.location = "http://localhost:51045/admin/vehicles";
        },
        error: function () {
            alert("Failure!");
        }
    })
})


function getMakes() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/makes',
        success: function (thing) {
            $.each(thing, function (index, data) {
                var div = '<option value="' + data.MakeID + '">' + data.Name + '<option/>';
                $('#EditMake').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
}

function getModels(id) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/mdls/' + id,
        success: function (thing) {
            $('#EditModel').empty();
            var select = '<option>--Select Model--<option/>';
            $('#EditModel').append(select);
            $.each(thing, function (index, data) {
                var div = '<option value="' + data.ModelID + '">' + data.Name + '<option/>';
                $('#EditModel').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
}

$('#DeleteButton').click(function (event) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:51045/delete/' + id,
        success: function (thing) {
            alert("Deleted!");
            window.location = "http://localhost:51045/admin/vehicles";
        },
        error: function () {
            alert('Failure!');
        }
    })
})