$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/newreports',
        success: function (thing) {
            $.each(thing, function (index, data) {
                $('#NewVehiclesInventoryReport').empty();
                var div = '<tr><td>' + data.Year + '</td><td>' + data.Make + '</td><td>' + data.Model + '</td><td>'
                    + data.Count + '</td><td>' + '$ ' + data.StockValue + '</td></tr>';
                $('#NewVehiclesInventoryReport').append(div);
            }
        )
        },
        error: function () {
            alert('Failure!');
        }
    })

    $.ajax({
        type: 'GET',
        url: 'http://localhost:51045/usedreports',
        success: function (thing) {
            $('#UsedVehiclesInventoryReport').empty();
            $.each(thing, function (index, data) {
                var div = '<tr><td>' + data.Year + '</td><td>' + data.Make + '</td><td>' + data.Model + '</td><td>'
                    + data.Count + '</td><td>' + '$ ' + data.StockValue + '</td></tr>';
                $('#UsedVehiclesInventoryReport').append(div);
            }
        )
        },
        error: function () {
            alert('Failure!');
        }
    })
})