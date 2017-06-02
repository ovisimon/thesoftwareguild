$(document).ready(function () {
    loadItems();
})

function loadItems() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57400/items',
        success: function (itemArray) {
            $('#mainView').empty();
            for (var i = 0; i < 9; i++) {
                var productDiv = "<div id='product-" + (i + 1) + "' style='width:30%; display:inline-block; border:solid; margin:5px; height:250px'" + 'onclick="addToCart(' + "'" + (i + 1) + "')" + '"></div>';
                $('#mainView').append(productDiv);
            }

            for (var i = 0; i < 9; i++) {
                var selector = "#product-";

                $(selector + (i + 1)).empty();
                var product = $(selector + (i + 1));
                var newProduct =
                "<p id='product-id-" + (i + 1) + "'>" + itemArray[i].ProductID + "</p>" +
                "<h4 class='text-center'" + "id='product-brand-" + (i + 1) + "'" + ">" + itemArray[i].Name + "</h4><br><br>" +
                "<h4 class='text-center'" + "id='product-price-" + (i + 1) + "'" + ">" + "$" + itemArray[i].Price + "</h4><br><br>" +
                "<h4 class='text-center'" + "id='product-stock-" + (i + 1) + "'" + ">" + "Quantity Left: " + itemArray[i].Quantity + "</h4>";
                product.append(newProduct);
            }
        },
        error: function () {
            allert("Failure!");
        }
    })
}
//Add Money Buttons
var total = 0;
$('#money-input').val(total.toFixed(2));
$('#add-dollar-button').on('click', function () {
    total += 1;
    $('#money-input').val(total.toFixed(2));
})
$('#add-quarter-button').on('click', function () {
    total += 0.25;
    $('#money-input').val(total.toFixed(2));
})
$('#add-dime-button').on('click', function () {
    total += 0.10;
    $('#money-input').val(total.toFixed(2));
})
$('#add-nickel-button').on('click', function () {
    total += 0.05;
    $('#money-input').val(total.toFixed(2));
})

//change button
var change = 0;
$('#change-return-button').on('click', function () {
    change = total;
    total = 0;
    $('#money-input').val(total.toFixed(2));
    $('#change-display').val(change.toFixed(2));
})

function addToCart(id) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57400/items',
        success: function(data) {
            $('#item-display').val(data[id - 1].ProductID);
            $('#hidden-value').val(data[id - 1].Price)
        },
        error: function () {
            alert('Failure!');
        }
    })
}

//mame purchase button
$('#make-purchase-button').on('click', function () {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:57400/money/' + $('#money-input').val() + '/item/' + $('#item-display').val(),
        success: function (data) {
            if ($('#money-input').val() >= $('#hidden-value').val()) {
                
                total = total - $('#hidden-value').val();
                change = total;
                total = 0;
                $('#money-input').val(total.toFixed(2));
                $('#change-display').val(change.toFixed(2));

                $('#change-coins').empty();
                var coins = "<p>Quarters: " + data.Quarters + "<br>" +
                        "Dimes: " + data.Dimes + "<br>" +
                        "Nickels: " + data.Nickels + "</p>";
                $('#change-coins').append(coins);

                
            }
            var message = data.Message;
            $('#message-display').empty();
            $('#message-display').append(message);

            loadItems();
        },
        error: function (x) {
            alert('Failure!');
        }
    })
})
