$(document).ready(function () {
    loadDepartment();
    //var counter = 0;
    var subjects = ["Science", "Physics", "Chemistry", "Biology", "HigherMath",
        "MathematicsStatistics", "Accountiong", "BusinessStudies", "FinanceBanking",
        "History", "Geography", "PoliticalScience", "Economics", "Sociology", "Bangla2", "Math", "English", "English2", "GeneralScience",
        "SocialScience", "BnagladeshWorld", "IslamicStudies", "ICT", "AgricultureStudies", "OptionalSubject"
        ];

    $('#add').css('text-align', 'left').on('click', function () {
        if (subjects.length > 0) {
            var currentSubject = subjects.shift(); // Remove the first subject from the array
            var newField = $('<div><input type="number" placeholder=" ' + currentSubject + '" class="form-control grade" style="padding: 8px;" min="0" max="100" id="input_' + currentSubject + '"/><button class="removeSubject" data-subject-name="' + currentSubject + '">Remove</button></div>');
            newField.appendTo($('#data'));
        } else {
            alert('All subjects added.');
        }
    });

    // Event delegation for dynamically added remove buttons
    $('#data').css('text-align', 'left').on('click', '.removeSubject', function () {
        var container = $(this).closest('div');
        var currentSubject = $(this).data('subject-name');
        container.remove();

        // Add the removed subject back to the subjects array
        subjects.push(currentSubject);
    });

        $('#reset').on('click', function () {
            window.location;
        });

        $('#calculate').on('click', function () {
            var grades = [];
            $('.grade').each(function () {
                if ($(this).val() == "") {
                    //toastr.error("Field Must Not Be Empty!", "Warning!!!");
                    return false;
                }
                grades.push($(this).val());
            });

            var sum = eval(grades.join('+')), avg = sum / grades.length;
            if (avg >= 80) {
                $('#Result').html("<center><b>Your Point is :</b> 5 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 79) {
                $('#Result').html("<center><b>Your Point is :</b> 4.50 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 69) {
                $('#Result').html("<center><b>Your Point is :</b> 4.00 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 59) {
                $('#Result').html("<center><b>Your Point is :</b> 3.50 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 49) {
                $('#Result').html("<center><b>Your Point is :</b> 3.00 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 39) {
                $('#Result').html("<center><b>Your Point is :</b> 2.50 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 36) {
                $('#Result').html("<center><b>Your Point is :</b> 2.00 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg > 33) {
                $('#Result').html("<center><b>Your Point is :</b> 1.00 <label class='text-primary'>" + "</label> <label class='text-success'>You passed!</label></center>");
            } else if (avg < 32) {
                $('#Result').html("<center><b>Your Grade is :</b> F <label class='text-primary'>" + "</label> <label class='text-warning'>You Failed!</label></center>");
            } 
            $('#checkFailure').on('click', function () {
                var failedSubjects = [];

                // Iterate through all input fields
                $('.grade').each(function () {
                    var avg = parseInt($(this).val(), 10);

                    // Check if the mark is less than 32
                    if (avg < 32) {
                        failedSubjects.push($(this).attr('id'));
                    }
                });

                // Display the result
                if (failedSubjects.length === 0) {
                    alert('No subjects with marks less than 32.');
                } else {
                    alert('Subjects with marks less than 32: ' + failedSubjects.join(', '));
                }
            });
        });
});
//Get Class id data
function loadDepartment() {
    $.get("/api/Departments", function (data) {
        var $el = $("#DepartmentId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });
}
$(document).ready(function () {
    loadDatatable();
});

$(document.body).on("click", "#calculate", function () {

    var vm = {};
    var id = $("#Id").val();
    vm.classId = $("#ClassId").val();
    vm.departmentId = $("#DepartmentId").val();
    vm.section = $("#Section").val();
    vm.session = $("#Session").val();
    vm.grade = $("#Grade").val();
    vm.checkFailure = $("#CheckFailure").val();
    vm.pointResult = $("#PointResult").val();
    vm.totalMarks = $("#TotalMarks").val();
    vm.Science = $("#input_Science").val();
    vm.Physics = $("#input_Physics").val();
    vm.Chemistry = $("#input_Chemistry").val();
    vm.Biology = $("#input_Biology").val();
    vm.HigherMath = $("#input_HigherMath").val();
    vm.MathematicsStatistics = $("#input_MathematicsStatistics").val();
    vm.Accountiong = $("#input_Accountiong").val();
    vm.BusinessStudies = $("#input_BusinessStudies").val();
    vm.FinanceBanking = $("#input_FinanceBanking").val();
    vm.History = $("#input_History").val();
    vm.Geography = $("#input_Geography").val();
    vm.PoliticalScience = $("#input_PoliticalScience").val();
    vm.Economics = $("#input_Economics").val();
    vm.Sociology = $("#input_Sociology").val();
    vm.Bangla2 = $("#input_Bangla2").val();
    vm.Bangla = $("#input_Bangla").val();
    vm.Math = $("#input_Math").val();
    vm.English = $("#input_English").val();
    vm.English2 = $("#input_English2").val();
    vm.GeneralScience = $("#input_GeneralScience").val();
    vm.SocialScience = $("#input_SocialScience").val();
    vm.BnagladeshWorld = $("#input_BnagladeshWorld").val();
    vm.IslamicStudies = $("#input_IslamicStudies").val();
    vm.ICT = $("#input_ICT").val();
    vm.AgricultureStudies = $("#input_AgricultureStudies").val();
    vm.OptionalSubject = $("#input_OptionalSubject").val();

    if (vm.ClassId == "") {
        toastr.warning("Class Roll Must Not Be Empty", "Warning!!!");
        return;
    }

    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/StudentResults",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    loadDatatable();

                } else {
                    toastr.warning("Save Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
    else {
        vm.id = id;
        $.ajax({
            url: "/api/StudentResults/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    loadDatatable();
                    
                } else {
                    toastr.warning("Update Fail", "Warning!!!");
                }
            },
            error: function (request, status, error) {
                var response = jQuery.parseJSON(request.responseText);
                toastr.error(response.message, "Error");
            }
        });
    }
});
function loadDatatable() {

    $("#studentResultList").DataTable().destroy();

    $("#studentResultList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/StudentResults",
            dataSrc: ""
        },
        columns: [
            {
                data: "classId"
            },
            {
                data: "department.name"
            },
            {
                data: "section"
            },
            {
                data: "session"
            },
            {
                data: "grade"
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn btn-info btn-sm js-edit' data-id=" + data + " ><i class='fa fa-pencil-square fa-2x ' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete'  data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color: #d9534f;'></i></a>";
                }
            }
        ]
    });
}
// From ar edit icon js code
$(document.body).on("click", ".js-edit", function () {
    var button = $(this);
    var id = button.attr("data-id");

    getData(id);

});
function getData(id) {
    $.get("/api/StudentResults?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#ClassId").val(data.classId);
            $("#DepartmentId").val(data.departmentId);
            $("#Section").val(data.section);
            $("#Session").val(data.session);
            $("#Grade").val(data.grade);
            $("#PointResult").val(data.pointResult);
            $("#TotalMarks").val(data.totalMarks);
            $("#input_Science").val(data.Science);
            $("#input_Physics").val(data.Physics);
            $("#input_Chemistry").val(data.Chemistry);
            $("#input_Biology").val(data.Biology);
            $("#input_HigherMath").val(data.HigherMath);
            $("#input_MathematicsStatistics").val(data.MathematicsStatistics);
            $("#input_Accountiong").val(data.Accountiong);
            $("#input_BusinessStudies").val(data.BusinessStudies);
            $("#input_FinanceBanking").val(data.FinanceBanking);
            $("#input_History").val(data.History);
            $("#input_Geography").val(data.Geography);
            $("#input_PoliticalScience").val(data.PoliticalScience);
            $("#input_Economics").val(data.Economics);
            $("#input_Sociology").val(data.Sociology);
            $("#input_Bangla2").val(data.Bangla2);
            $("#input_Bangla").val(data.Bangla);
            $("#input_Math").val(data.Math);
            $("#input_English").val(data.English);
            $("#input_English2").val(data.English2);
            $("#input_GeneralScience").val(data.GeneralScience);
            $("#input_SocialScience").val(data.SocialScience);
            $("#input_BnagladeshWorld").val(data.BnagladeshWorld);
            $("#input_IslamicStudies").val(data.IslamicStudies);
            $("#input_ICT").val(data.ICT);
            $("#input_OptionalSubject").val(data.OptionalSubject);

        });
}
$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/StudentResults/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
});