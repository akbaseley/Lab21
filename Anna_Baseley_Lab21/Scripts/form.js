$(document).ready(
    $('#regFirstName').change(function () {
        var fnRegex = /^[a-zA-Z]{1,}$/g;
        var fnValue = $('#regFirstName').val();
        if (fin.fnRegex.test(fnValue)) {
            $('#regFirstName').css('border', 'red');
        }
    }
    ));




function testFormInput() {
    var stringArray = ['', '', '', '', ''];

    stringArray[0] = $('#regFirstName').val();
    stringArray[1] = $('#reLastName').val();
    stringArray[2] = $('#regEmail').val();
    stringArray[3] = $('#regPhoneNumber').val();
    stringArray[4] = $('#regPassord').val();

    var regexArray = [0, 0, 0, 0, 0,];
    regexArray[0] = /regexpressions here

}