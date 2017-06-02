$(document).ready(function () {

})

$('#SpecialButtonAdd').click(function () {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51045/specialadd',
        data: JSON.stringify({
            Title: $('#SpecialTitleAdd').val(),
            Message: $('#SpecialDescriptionAdd').val(),
            ImagePath: $('#SpecialPictureAdd').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        },
        success: function () {
            window.location = 'http://localhost:51045/admin/specialsad';
        },
        error: function () {
            alert('Failure!');
        }
    })
})

function deleteSpecial(id) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:51045/specialdelete/' + id,
        success: function () {
            window.location = 'http://localhost:51045/admin/specialsad';
        },
        error: function () {
            alert('Failure!');
        }
    })
}