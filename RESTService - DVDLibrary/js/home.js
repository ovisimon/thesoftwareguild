$(document).ready(function(){
    loadDVDS();
})

function loadDVDS() {
    clearDVDTable();
    $('#create-DVD').hide();
    $('#edit-DVD').hide();
    $("#view-container").hide();
    $('#top-buttons').show();
    $('#DVD-table-div').show();
    $('#DVD-table').show();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function(dvdArray){
            var dvdTable = $('#content-rows');

            $.each(dvdArray, function(index, dvd){
                var tableRow = "";
                var tableData = "<td>";
                tableRow = "<tr>" + tableData +  '<a onclick="ViewDetails('+ dvd.dvdId +')">' + dvd.title + "</a>" + "</td>" + tableData +
                dvd.realeaseYear + "</td>" + tableData + dvd.director + "</td>" +
                tableData + dvd.rating + "</td>" + tableData + '<a onclick="EditDVDShow('+ dvd.dvdId +')">Edit</a>' +" | " + "<a onclick='DeleteDVD("+ dvd.dvdId +")'>Delete</a>" + "</td>"+ "</tr>";

                dvdTable.append(tableRow);
            })
        },
        error: function() {
            alert('FAILURE!');
        }
    });
}

function clearDVDTable(){
    $('#content-rows').empty();
}

    $('#create-DVD-button').on('click', function(){
         $('#create-DVD').show();
         $('#top-buttons').hide();
         $('#edit-DVD').hide();
         $('#view-container').hide();
         $('#DVD-table-div').hide();
         
    });


    $('#submit-create-button').on('click', function(){
        var haveValidationErrors = checkAndDisplayValidationErrorsCreate($('#create-form-id').find('input'));
        if (haveValidationErrors) {
            return false;
        }
        $.ajax({
            type: 'POST',
            url: 'http://localhost:8080/dvd',
            data: JSON.stringify({
                title: $('#DVD-title-create').val(),
                realeaseYear: $('#release-year-create').val(),
                director: $('#director-create').val(),
                rating: $('#rating-create').val(),
                notes: $('#notes-create').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function(){
                loadDVDS();
            },
            error: function() {
                $('#create-error-messages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Please add the required fields'));
            }
        })
    });

function EditDVDShow(dvdId){
         $('#top-buttons').hide();
         $('#edit-DVD').show();
         $("#details-view").hide();
         $('#create-DVD').hide();
         $('#DVD-table').hide();

         $.ajax({
             type: 'GET',
             url: 'http://localhost:8080/dvd/' + dvdId,
             success: function(data, status){
                 $('#DVD-title-edit').val(data.title);
                 $('#release-year-edit').val(data.realeaseYear);
                 $('#director-edit').val(data.director);
                 $('#rating-edit').val(data.rating);
                 $('#notes-edit').val(data.notes);
                 $('#edit-dvd-id').val(data.dvdId);
             },
             error: function(){
                 allert('FAILURE');
             }
         })
}

function EditDVD(dvdId){

    var haveValidationErrors = checkAndDisplayValidationErrorsEdit($('#edit-error-messages').find('input'));
        if (haveValidationErrors) {
            return false;
        }

        $.ajax({
            type: 'PUT',
            url: 'http://localhost:8080/dvd/' + dvdId,
            data: JSON.stringify({
                title: $('#DVD-title-edit').val(),
                realeaseYear: $('#release-year-edit').val(),
                director: $('#director-edit').val(),
                rating: $('#rating-edit').val(),
                notes: $('#notes-edit').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function(){
                loadDVDS();
            },
             error: function() {
                $('#edit-error-messages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Please add the required fields'));
            }
        })
}

$('#submit-edit-button').on('click', function(){
    var myId = $('#edit-dvd-id').val();
    EditDVD(myId);
})

$('#cancel-edit-button').on('click', function(){
    loadDVDS();
})

$('#cancel-create-button').on('click', function(){
 loadDVDS();
});

function DeleteDVD(dvdId){
    if(confirm("Are you sure you want to delete this DVD?") == true){
        $.ajax({
            type: "DELETE",
            url: 'http://localhost:8080/dvd/' + dvdId,
            success: loadDVDS(),
            error: function(){
                alert('FAILURE');
            }
        });
    }
    else {
        return;
    }
     
}

$('#search-button').on('click', function(){
    clearDVDTable();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds/' + $('#search-category').val() + '/' + $('#search-term').val(),
        success: function(results){
            var dvdTable = $('#content-rows');

            $.each(results, function(index, dvd){
                var tableRow = "";
                var tableData = "<td>";
                tableRow = "<tr>" + tableData +  "<a>" + dvd.title + "</a>" + "</td>" + tableData +
                dvd.realeaseYear + "</td>" + tableData + dvd.director + "</td>" +
                tableData + dvd.rating + "</td>" + tableData + '<a onclick="EditDVDShow('+ dvd.dvdId +')">Edit</a>' +" | " + "<a onclick='DeleteDVD("+ dvd.dvdId +")'>Delete</a>" + "</td>"+ "</tr>";

                dvdTable.append(tableRow);
            })
        },
        error: function() {
            alert('FAILURE!');
        }
    })
})

function ViewDetails(dvdId){
         $('#details-view').empty();
         $('#top-buttons').hide();
         $('#edit-DVD').hide();
         $("#view-container").show();
         $('#details-view').show();
         $('#create-DVD').hide();
         $('#DVD-table').hide();

         $.ajax({
             type: 'GET',
             url: 'http://localhost:8080/dvd/' + dvdId,
             success: function(data){
                 var Details = $('#details-view');
                 var TitleDet = "<h1>" + data.title + "</h1>";
                 Details.append(TitleDet);
                 var hrLine = "<hr><br>";
                 Details.append(hrLine);
                 var YearDet = "<h3>" + "Release Year: " + data.realeaseYear + "</h3>";
                 Details.append(YearDet);
                 var DirDet = "<h3>"+ "Director: " + data.director + "</h3>";
                 Details.append(DirDet);
                 var RateDet = "<h3>"+ "Rating: " + data.rating + "</h3>";
                 Details.append(RateDet);
                 var NotesDet = "<h3>"+ "Notes: " + data.notes + "</h3>";
                 Details.append(NotesDet);
             }
         })
}

$('#view-back').on('click', function(){
    $('#details-view').empty();
    loadDVDS();
})

function checkAndDisplayValidationErrorsCreate(input) {
    $('#create-error-messages').empty();
    var errorMessages = [];

    input.each(function() {
        if(!this.validity.valid)
        {
            var errorField = $('label[for='+this.dvdId+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message){
            $('#create-error-messages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        return true;
    } else {
        return false;
    }
}

function checkAndDisplayValidationErrorsEdit(input) {
    $('#edit-error-messages').empty();
    var errorMessages = [];

    input.each(function() {
        if(!this.validity.valid)
        {
            var errorField = $('label[for='+this.dvdId+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message){
            $('#edit-error-messages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        return true;
    } else {
        return false;
    }
}