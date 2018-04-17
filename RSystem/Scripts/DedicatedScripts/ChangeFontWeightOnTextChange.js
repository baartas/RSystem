$('#user-input').keyup(function (e) {
    
    switch (e.keyCode) {
        case 8: {
            if ($(this).val().length === 0) {
                $(this).css("font-weight", "300");
            }
            break;
        }
        default:{
            $(this).css("font-weight", "400");
        }
    }
});

$(document).ready(function () {
    if ($('#user-input').val().length > 0) {
        $('#user-input').css("font-weight", "400");
    }
})