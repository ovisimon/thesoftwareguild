$(document).ready(function () {
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
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
                            '</div>' +
                        '</div>' +
                        '<div class="row">' +
                            '<div class="col-lg-offset-9 col-lg-3">' +
                                '<button onclick="ContactUsButton()">Contact Us</button>' +
                            '<div>' +
                        '</div>' +
                    '</div>';
              $('#detailsView').append(div);
        },
        error: function () {
            alert('Failure!');
        }
    })
})

function ContactUsButton() {
    window.location = "http://localhost:51045/Home/Contact"
}