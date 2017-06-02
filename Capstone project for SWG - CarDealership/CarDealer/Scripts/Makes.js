$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/mkreport',
        success: function (thing) {
            $.each(thing, function (index, data) {
                var div = '<tr><td>' + data.Name + '<td/>' +
                          '<td>' + data.Date + '<td/>' +
                          '<td>' + data.User + '<td/><tr/>';
                $('#MakeTable').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
})

$('#NewMakeButton').click(function () {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/mkcreate',
        data: JSON.stringify({
            Name: $('#NewMakeName').val(),
            User: $('#UserMakeName').val(),
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
