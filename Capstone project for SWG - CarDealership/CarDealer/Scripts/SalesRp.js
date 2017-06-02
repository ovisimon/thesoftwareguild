$(document).ready(function () {

})

$('#SalesReportButton').click(function (event) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/salesrep',
        data: JSON.stringify({
            User: $('#UserSalesReport').val(),
            StartDate: $('#StartDateReport').val(),
            EndDate: $('#EndDateReport').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (thing) {
            $('#SalesReportTable').empty();
            $.each(thing, function (index, data) {
                var div = '<tr><td>' + data.User + '</td><td>' + data.TotalSales + '</td><td>' + data.TotalVehicles + '</td></tr>';
                $('#SalesReportTable').append(div);
            })
        },
        error: function () {
            alert('Failure!');
        }
    })
})