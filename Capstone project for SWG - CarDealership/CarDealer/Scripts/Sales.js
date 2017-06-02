$('#salesSearchButton').click(function (event) {
    $('#salesSearchResults').empty();
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/sale',
        data: JSON.stringify({
            Term: $('#SalesSearchTerm').val(),
            MinPrice: $('#SalesSearchMinPrice').val(),
            MaxPrice: $('#SalesSearchMaxPrice').val(),
            MinYear: $('#SalesSearchMinYear').val(),
            MaxYear: $('#SalesSearchMaxYear').val(),
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (thing) {
            $.each(thing, function (index, data) {
                var div = '<div class="well" style="height:200px">' +
                                             '<div class="col-lg-3">' +
                                                 '<p>' + data.Year + " " + data.Make + " " + data.Model + '</p>' +
                                                 '<img src="' + data.Picture + '" height="100" width="100" />' +
                                             '</div>' +
                                             '<div class="col-lg-3">' +
                                                 '<p>Body Style:' + " " + data.BodyStyle + '</p>' +
                                                 '<p>Trans:' + " " + data.Transmission + '</p>' +
                                                 '<p>Color:' + " " + data.Color + '</p>' +
                                             '</div>' +
                                             '<div class="col-lg-3">' +
                                                 '<p>Interior:' + " " + data.Interior + '</p>' +
                                                 '<p>Mileage:' + " " + data.Mileage + '</p>' +
                                                 '<p>VIN:' + " " + data.VIN + '</p>' +
                                                 '</div>' + " " +
                                                 '<div class="col-lg-3">' +
                                                     '<p>Sale Price:' + " " + data.Price + '</p>' +
                                                     '<p>MSRP:' + " " + data.MSRP + '</p>' +
                                                     '<button onclick="purchaseButton(' + data.CarID + ')">Purchase</button>' +
                                                 '</div>' +
                                            '</div>';
                $('#salesSearchResults').append(div);
            })

        },
        error: function () {
            alert('Failure!');
        }
    })
})

function purchaseButton(id) {
    window.location = "http://localhost:51045/Sales/Purchase/" + id;
}