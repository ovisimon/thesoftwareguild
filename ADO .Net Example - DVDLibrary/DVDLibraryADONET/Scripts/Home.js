$(document).ready(function () {
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
        url: 'http://localhost:52513/dvds',
        success: function (dvdArray) {
            var dvdTable = $('#content-rows');

            $.each(dvdArray, function (index, dvd) {
                var tableRow = "";
         
                tableRow = "<tr>" + "<td>" + '<a onclick="ViewDetails(' + dvd.DVDID + ')">' + dvd.Title + "</a>" + "</td>" + "<td>" + dvd.ReleaseDate + "</td>" + "<td>" + dvd.Director + "</td>" + "<td>" +
                    dvd.Rating + "</td>" + "<td>" + '<a onclick="EditDVDShow(' + dvd.DVDID + ')">Edit</a>' + " | " + "<a onclick='DeleteDVD(" + dvd.DVDID + ")'>Delete</a>" + "</td>" + "</tr>";

                dvdTable.append(tableRow);
            })
        },
        error: function () {
            alert('FAILURE!');
        }
    });
}

function clearDVDTable() {
    $('#content-rows').empty();
}

$('#create-DVD-button').on('click', function () {
    $('#create-DVD').show();
    $('#top-buttons').hide();
    $('#edit-DVD').hide();
    $('#view-container').hide();
    $('#DVD-table-div').hide();

});


$('#submit-create-button').on('click', function () {
    var haveValidationErrors = checkAndDisplayValidationErrorsCreate($('#create-form-id').find('input'));
    if (haveValidationErrors) {
        return false;
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:52513/dvds',
        data: JSON.stringify({
            Title: $('#DVD-title-create').val(),
            ReleaseDate: $('#release-year-create').val(),
            Director: $('#director-create').val(),
            Rating: $('#rating-create').val(),
            Notes: $('#notes-create').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            loadDVDS();
        },
        error: function () {
            $('#create-error-messages')
               .append($('<li>')
               .attr({ class: 'list-group-item list-group-item-danger' })
               .text('Please add the required fields'));
        }
    })
});

function EditDVDShow(dvdId) {
    $('#top-buttons').hide();
    $('#edit-DVD').show();
    $("#details-view").hide();
    $('#create-DVD').hide();
    $('#DVD-table').hide();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:52513/dvds/' + dvdId,
        success: function (data, status) {
            $('#DVD-title-edit').val(data.Title);
            $('#release-year-edit').val(data.ReleaseDate);
            $('#director-edit').val(data.Director);
            $('#rating-edit').val(data.Rating);
            $('#notes-edit').val(data.Notes);
            $('#edit-dvd-id').val(data.DVDID);
        },
        error: function () {
            allert('FAILURE');
        }
    })
}

function EditDVD(dvdId) {

    var haveValidationErrors = checkAndDisplayValidationErrorsEdit($('#edit-error-messages').find('input'));
    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'PUT',
        url: 'http://localhost:52513/dvds',
        data: JSON.stringify({
            Title: $('#DVD-title-edit').val(),
            ReleaseDate: $('#release-year-edit').val(),
            Director: $('#director-edit').val(),
            Rating: $('#rating-edit').val(),
            Notes: $('#notes-edit').val(),
            DVDID: $('#edit-dvd-id').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function () {
            loadDVDS();
        },
        error: function () {
            $('#edit-error-messages')
               .append($('<li>')
               .attr({ class: 'list-group-item list-group-item-danger' })
               .text('Please add the required fields'));
        }
    })
}

$('#submit-edit-button').on('click', function () {
    var myId = $('#edit-dvd-id').val();
    EditDVD(myId);
})

$('#cancel-edit-button').on('click', function () {
    loadDVDS();
})

$('#cancel-create-button').on('click', function () {
    loadDVDS();
});

function DeleteDVD(dvdId) {
    if (confirm("Are you sure you want to delete this DVD?") == true) {
        $.ajax({
            type: "DELETE",
            url: 'http://localhost:52513/dvd/' + dvdId,
            success: function () {
                loadDVDS();
            },
            error: function () {
                alert('FAILURE');
            }
        });
    }
    else {
        return;
    }

}

$('#search-button').on('click', function () {
    clearDVDTable();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:52513/dvds/' + $('#search-category').val() + '/' + $('#search-term').val(),
        success: function (results) {
            var dvdTable = $('#content-rows');

            $.each(results, function (index, dvd) {
                var tableRow = "";
                var tableData = "<td>";
                tableRow = "<tr>" + tableData + "<a>" + dvd.Title + "</a>" + "</td>" + tableData +
                dvd.ReleaseDate + "</td>" + tableData + dvd.Director + "</td>" +
                tableData + dvd.Rating + "</td>" + tableData + '<a onclick="EditDVDShow(' + dvd.DVDID + ')">Edit</a>' + " | " + "<a onclick='DeleteDVD(" + dvd.dvdId + ")'>Delete</a>" + "</td>" + "</tr>";

                dvdTable.append(tableRow);
            })
        },
        error: function () {
            alert('FAILURE!');
        }
    })
})

function ViewDetails(dvdId) {
    $('#details-view').empty();
    $('#top-buttons').hide();
    $('#edit-DVD').hide();
    $("#view-container").show();
    $('#details-view').show();
    $('#create-DVD').hide();
    $('#DVD-table').hide();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:52513/dvds/' + dvdId,
        success: function (data) {
            var Details = $('#details-view');
            var TitleDet = "<h1>" + data.Title + "</h1>";
            Details.append(TitleDet);
            var hrLine = "<hr><br>";
            Details.append(hrLine);
            var YearDet = "<h3>" + "Release Year: " + data.ReleaseDate + "</h3>";
            Details.append(YearDet);
            var DirDet = "<h3>" + "Director: " + data.Director + "</h3>";
            Details.append(DirDet);
            var RateDet = "<h3>" + "Rating: " + data.Rating + "</h3>";
            Details.append(RateDet);
            var NotesDet = "<h3>" + "Notes: " + data.Notes + "</h3>";
            Details.append(NotesDet);
        },
        error: function () {
            alert('FAILURE!');
        }
    })
}

$('#view-back').on('click', function () {
    $('#details-view').empty();
    loadDVDS();
})

function checkAndDisplayValidationErrorsCreate(input) {
    $('#create-error-messages').empty();
    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.dvdId + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#create-error-messages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true;
    } else {
        return false;
    }
}

function checkAndDisplayValidationErrorsEdit(input) {
    $('#edit-error-messages').empty();
    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.DVDID + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#edit-error-messages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        return true;
    } else {
        return false;
    }
}