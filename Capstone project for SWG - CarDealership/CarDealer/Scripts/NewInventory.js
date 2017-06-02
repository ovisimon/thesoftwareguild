$('#newSearchButton').click(function (event) {
    $('#newSearchResults').empty();
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/new',
        data: JSON.stringify({
            Term: $('#NewSearchTerm').val(),
            MinPrice: $('#NewSearchMinPrice').val(),
            MaxPrice: $('#NewSearchMaxPrice').val(),
            MinYear: $('#NewSearchMinYear').val(),
            MaxYear: $('#NewSearchMaxYear').val(),
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
                                                     '<button onclick="seeDetails(' + data.CarID + ')">Details</button>' +
                                                 '</div>' +
                                            '</div>';
                $('#newSearchResults').append(div);
            })
            
        },
        error: function () {
            alert('Failure!');
        }
    })
})

function seeDetails(id) {
    window.location = "http://localhost:51045/inventory/details/" + id;

}