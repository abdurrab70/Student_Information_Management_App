$(document).ready(function () {
    GenerateStudentId();
    loadDepartment();
    //loadDatatable();
    //search name or id
    $("#SearchStudentName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/api/StudentEntries/StudentSearch",
                data: { query: request.term },
                type: "GET"
            }).done(function (data) {
                response($.map(data, function (item) {
                    return { label: item.studentId + " " + item.name, value: item.id }
                }));
            });
        },
        minLength: 2,
        select: function (e, ui) {

            $.get("/api/StudentEntries/StudentIdAutoComplete", { id: ui.item.value })
                .done(function (data) {
                    $("#Id").val(data.id);
                    $("#SearchStudentName").val(data.studentId);
                    $("#SearchName").val(data.name);
                    $("#SearchPhoneNo").val(data.phoneNo);
                    $("#SearchEmailId").val(data.email);

                    loadDatatable(data.id);

                });
        }
    });
});

//generate emp id
function GenerateStudentId() {
    $.get("/api/StudentEntries/GetStudentId",
        function (data) {
            $("#StudentId").val(data);
        });
}
//Get Department id data
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

//Data save
$(document.body).on("click", "#btnSubmit", function () {

    var vm = {};
    var id = $("#Id").val();
    vm.studentId = $("#StudentId").val();
    vm.name = $("#Name").val();
    vm.fatherName = $("#FatherName").val();
    vm.motherName = $("#MotherName").val();
    vm.birthDate = $("#BirthDate").val();
    vm.phoneNo = $("#PhoneNo").val();
    vm.email = $("#Email").val();
    vm.permanantAddress = $("#PermanantAddress").val();
    vm.presentAddress = $("#PresentAddress").val();
    vm.gender = $("#Gender").val();
    vm.bloodGroup = $("#BloodGroup").val();
    vm.religion = $("#Religion").val();
    vm.nationality = $("#Nationality").val();
    vm.departmentId = $("#DepartmentId").val();
    vm.nidBirthCertificate = $("#NidBirthCertificate").val();
    vm.section = $("#Section").val();
    vm.fatherPhoneNo = $("#FatherPhoneNo").val();
    vm.motherPhoneNo = $("#MotherPhoneNo").val();
    vm.fatherEmail = $("#FatherEmail").val();
    vm.remark = $("#Remark").val();
    vm.isActive = $("#IsActive").val();


    if ($("#IsActive:checked").length > 0) {
        vm.isActive = true;
    } else {
        vm.isActive = false;
    }

    if (vm.departmentId == "") {
        toastr.warning("Required Must Not Be Empty!", "Warning!!!");
        return;
    }
    //data save
    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/StudentEntries",
            data: vm,
            type: "POST",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Save Success", "Success!!!");
                    loadDatatable(e);

                    refreshForm();

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
            url: "/api/StudentEntries/" + id,
            data: vm,
            type: "PUT",
            success: function (e) {
                if (e > 0) {
                    toastr.success("Update Success", "Success!!!");
                    loadDatatable(e);

                    refreshForm();

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

//save howar pore sudu jar data save kora hobe sudu tar data info list a tar data show hobe
// id dhore tule ane edit ar jonne
function loadDatatable(id) {

    $("#studentListTable").DataTable().destroy();
    $("#studentListTable").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/StudentEntries/GetStudentInformation?Id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "studentId"
            },
            {
                data: "name"
            },
            {
                data: "department.name"
            },
            {
                data: "fatherName"
            },
            {
                data: "motherName"
            },
            {
                data: "isActive",
                render: function (data) {
                    if (data) {
                        return "Active";
                    } else {
                        return "DeActive";
                    }
                }
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

// page refresh
function refreshForm() {
    $("#Id").val('');
    $("#StudentId").val('');
    $("#Name").val('');
    $("#FatherName").val('');
    $("#MotherName").val('');
    $("#PhoneNo").val('');
    $("#Email").val('');
    $("#BirthDate").val('');
    $("#PresentAddress").val('');
    $("#PermanantAddress").val('');
    $("#Nationality").val('');
    $("#Gender").val('');
    $("#BloodGroup").val('');
    $("#Religion").val('');
    $("#DepartmentId").val('');
    $("#Section").val('');
    $("#FatherPhoneNo").val('');
    $("#MotherPhoneNo").val('');
    $("#FatherEmail").val('');
    $("#NidBirthCertificate").val('');
    $("#Remark").val('');
    $("#IsActive").val('');

    if (!($("#IsActive:checked").length > 0)) {
        $("#IsActive").prop('checked', true);
        $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
    } else {
        $("#IsActive").prop('checked', false);
        $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'false');
    }
}


// From ar edit icon js code
$(document.body).on("click", ".js-edit", function () {
    refreshForm();
    var button = $(this);
    var id = button.attr("data-id");

    getData(id);

});

// data get kora id dhore individuals
function getData(id) {
    $.get("/api/StudentEntries?id=" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#StudentId").val(data.studentId);
            $("#Name").val(data.name);
            $("#FatherName").val(data.fatherName);
            $("#MotherName").val(data.motherName);
            $("#PhoneNo").val(data.phoneNo);
            $("#Email").val(data.email);
            $("#BirthDate").val(data.birthDate);
            $("#PermanantAddress").val(data.permanantAddress);
            $("#PresentAddress").val(data.presentAddress);
            $("#Nationality").val(data.nationality);
            $("#Gender").val(data.gender);
            $("#BloodGroup").val(data.bloodGroup);
            $("#Religion").val(data.religion);
            $("#DepartmentId").val(data.departmentId);
            $("#Section").val(data.section);
            $("#Remark").val(data.remark);
            $("#IsActive").val(data.isActive);
            $("#FatherPhoneNo").val(data.fatherPhoneNo);
            $("#MotherPhoneNo").val(data.motherPhoneNo);
            $("#FatherEmail").val(data.fatherEmail);
            $("#NidBirthCertificate").val(data.nidBirthCertificate);

            if (data.isActive == 1) {
                $("#IsActive").prop('checked', true);
                $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
            }
            else {
                $("#IsActive").prop('checked', false);
                $(".icheckbox_minimal-blue").removeClass('checked').attr('aria-checked', 'false');
            }

        });
}
//page refresh From ar edit icon js code
$(document.body).on("click", "#btnRefresh", function () {
    refreshForm();
    location.reload()

});
// data delete icon js code 
$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/StudentEntries/" + id,
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