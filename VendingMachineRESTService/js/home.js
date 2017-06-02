$(document).ready(function(){
    loadItems();
})

function loadItems(){
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(itemArray){

            for (var i = 0; i < 9; i++){
            var selector = "#product-";
    
            $(selector + (i+1)).empty();
            var product = $(selector + (i+1));
            var newProduct = 
            "<p id='product-id-'" + (i + 1) + ">" + itemArray[i].id + "</p>" +
            '<h4 class="text-center" id="product-brand-"' + (i+1) + ">" + itemArray[i].name +"</h4><br><br>" +
            '<h4 class="text-center" id="product-price-"' + (i+1) + '>' + "$" + itemArray[i].price +"</h4><br><br>" +
            '<h4 class="text-center" id="product-stock-"' + (i+1) + '>' + "Quantity Left: " + itemArray[i].quantity +"</h4>";
            product.append(newProduct);
            }
        },
        error: function(){
            allert("Failure!");
        }
    })
}
//Add Money Buttons
var total = 0;
$('#money-input').val(total.toFixed(2));
$('#add-dollar-button').on('click', function(){
    total+=1;
    $('#money-input').val(total.toFixed(2));
})
$('#add-quarter-button').on('click', function(){
    total+=0.25;
    $('#money-input').val(total.toFixed(2));
})
$('#add-dime-button').on('click', function(){
    total+=0.10;
    $('#money-input').val(total.toFixed(2));
})
$('#add-nickel-button').on('click', function(){
    total+=0.05;
    $('#money-input').val(total.toFixed(2));
})

//change button
var change = 0;
$('#change-return-button').on('click', function(){
    change = total;
    total = 0;
    $('#money-input').val(total.toFixed(2));
    $('#change-display').val(change.toFixed(2));
})

function addToCart(id){
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(data){
            $('#item-display').val(data[id-1].id);
            $('#hidden-value').val(data[id-1].price)
        },
        error: function(){
            alert('Failure!');
        }
    })
}

//mame purchase button
$('#make-purchase-button').on('click', function(){
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080//money/' + $('#money-input').val() + '/item/' + $('#item-display').val(),
        success: function(data){
            if($('#money-input').val() >= $('#hidden-value').val()){
                $('#message-display').empty();
                var myMessage = "Thank you! Please collect your change!";
                $('#message-display').append(myMessage);
                total = total - $('#hidden-value').val();
                change = total;
                total = 0;
                $('#money-input').val(total.toFixed(2));
                $('#change-display').val(change.toFixed(2));
                
                var coins = "<p>Quarters: " + data.quarters + "<br>" +
                        "Dimes: " + data.dimes + "<br>" +
                        "Nickels: " + data.nickels + "</p>" ;
                $('#change-coins').append(coins);

                loadItems();
            }
        },
        error: function(x){
            var message = x.responseJSON.message;
            $('#message-display').empty();
            $('#message-display').append(message);
        }
    })
})
