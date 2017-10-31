$(document).ready(function () {
    $("#carticon").click(function () {
        $("#cartContent").slideToggle("2000");
    });

    $("button").click(function () {
        var id = $(this).attr('name');
        alert(id);
    });


    
});
