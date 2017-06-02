$(document).ready(function () {
    getMakes();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/mdlreport',
        success: function (thing) {
            $.each(thing, function (index, data) {
                var div = '<tr><td>' + data.Make + '<td/>' +
                          '<td>' + data.Name + '<td/>' +
                          '<td>' + data.Date + '<td/>' +
                          '<td>' + data.User + '<td/><tr/>';
                $('#ModelsTable').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
})

$('#NewModelButton').click(function () {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/mdcreate',
        data: JSON.stringify({
            Name: $('#NewModelName').val(),
            User: $('#UserNewModel').val(),
            MakeID: $('#AddNewMake').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        success: function () {
            window.location = 'http://localhost:51045/admin/vehicles';
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
            $.each(thing, function (index, data) {
                var div = '<option value="' + data.MakeID + '">' + data.Name + '</option>';
                $('#AddNewMake').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
}