////$('.ViewDetails').on('click', function navigate(value) {

////    $.ajax({
////        type: 'GET',
////        url: 'Employee/ViewDetails' + this.value,
////        success: (
////            alert(value);
////        )
////});

//$('select').on('change', function () {


//    $.ajax({
//        url: 'Employee/ViewDetails/' + this.value,
//        dataType: "json",
//        type: "GET",
//        contentType: 'application/json; charset=utf-8',
//        async: true,
//        processData: false,
//        cache: false,
//        success: function (data) {
//            alert(data);
//        },
//        error: function (xhr) {
//            alert('error');
//        }
//    });

//});


$(document).ready(function () {
    $("#btnSave").click(function navigate(value) {
        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "Employee/ViewDetails" + this.value, // Controller/View 
            });

    });
});