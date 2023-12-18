
$(document.body).on("click",
    "#btnSimsReport",
    function () {

        var radioValue = $("input[name='SimsReport']:checked").val();



        //AllStudent
        if (radioValue === "AllStudent") {

            $.ajax({
                url: "/AllStudentReports/GetAllStudent",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data != "" && data != null) {
                        setTimeout(function () {
                            $("#pdf").attr("href", data);
                            var reportBox = $("#pdf").fancybox({
                                'frameWidth': 85,
                                'frameHeight': 495,
                                'overlayShow': true,
                                'hideOnContentClick': false,
                                'type': 'iframe',
                                helpers: {
                                    // prevents closing when clicking OUTSIDE fancybox
                                    overlay: { closeClick: false }
                                }
                            }).trigger('click');
                        }, 1000);
                    }
                }
            });
        }

        //Individual 

    });
