$(document).ready(function () {


    $('#incrementButton').click(function () {
        $.ajax({
            type: 'POST',
            url: '/Home/IncrementButton',
            success: function (data) {
                $('#buttonClickCounter').text(data.value);
            },
            error: function () {
                alert('Error occurred');
            }
        });
    });

    $('#ReverseLiterally').click(function () {

        var text = $('#TextToSwap').val();

        $.ajax({
            type: 'POST',
            url: '/Home/ChangeText',
            data: {
                textToChange : text,
                butID : 0,
            },
            success: function (data) {
                $('#SentanceReversal').text(data.value);
            },
            error: function () {
                alert('Error occurred');
            }
        });
    });

    $('#ReverseWords').click(function () {

        var text = $('#TextToSwap').val();

        $.ajax({
            type: 'POST',
            url: '/Home/ChangeText',
            data: {
                textToChange : text,
                butID : 1,
            },
            success: function (data) {
                $('#SentanceReversal').text(data.value);
            },
            error: function () {
                alert('Error occurred');
            }
        });
    });


});