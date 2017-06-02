$(document).ready(function () {
    getMakes();
})


$.ajax({
    type: 'POST',
    url: 'http://localhost:51045/',
    success: function (data) {
        $('#EditMake').val(data.Make);
        if (data.Mileage == 0) {
            $('#EditType').val("New");
        }
        else {
            $('#EditType').val("Used");
        }
        var pic = '<img src="' + data.Picture + '" height="100px" width="100px">';
        $('#EditYear').val(data.Year);
        $('#EditColor').val(data.Color);
        $('#EditMileage').val(data.Mileage);
        $('#EditMSRP').val(data.MSRP);
        $('#EditModel').val(data.Model);
        $('#EditBodyStyle').val(data.BodyStyle);
        $('#EditTransmission').val(data.Transmission);
        $('#EditInterior').val(data.Interior);
        $('#EditVIN').val(data.VIN);
        $('#EditSalePrice').val(data.Price);
        $('#EditDescription').val(data.Description);
        $('#EditOldImage').append(pic);
        $('#EditNewImage').val(data.Picture);
        $('#EditFeatured').val(data.Featured);
    },
    error: function () {
        alert("Failure!");
    }
})

$('#AddSaveButton').click(function (event) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/add',
        data: JSON.stringify({
            MakeID: $('#AddMake').val(),
            ModelID: $('#AddModel').val(),
            Mileage: $('#AddMileage').val(),
            VIN: $('#AddVIN').val(),
            Price: $('#AddPrice').val(),
            MSRP: $('#AddMSRP').val(),
            Year: $('#AddYear').val(),
            Picture: $('#AddPicture').val(),
            Description: $('#AddDescription').val(),
            Stock: 1,
            TransmissionID: $('#AddTransmission').val(),
            Transmission: $('#AddTransmission').val(),
            BodyStyleID: $('#AddBodyStyle').val(),
            ColorID: $('#AddColor').val(),
            InteriorID: $('#AddInterior').val(),
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            window.location = 'http://localhost:51045/admin/vehicles'
        },
        error: function () {
            alert('Failure!');
        }
    })
})

function getMakes() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/makes',
        success: function (thing) {
            $.each(thing, function(index, data){
                var div = '<option value="' + data.MakeID + '">' + data.Name + '<option/>';
                $('#AddMake').append(div);
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
        url: 'http://localhost:51045/models/' + id,
        success: function (thing) {
            $('#AddModel').empty();
            var select = '<option>--Select Model--<option/>';
            $('#AddModel').append(select);
            $.each(thing, function (index, data) {
                var div = '<option value="' + data.ModelID + '">' + data.Name + '<option/>';
                $('#AddModel').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
}