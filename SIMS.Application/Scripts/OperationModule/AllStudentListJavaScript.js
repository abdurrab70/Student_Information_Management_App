$(document).ready(function () {
    loadDatatable();

});

// id dhore tule ane edit ar jonne
function loadDatatable() {

    $("#studentInformationList").DataTable().destroy();
    $("#studentInformationList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/StudentEntries",
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
                data: "phoneNo"
            },
            {
                data: "fatherName"
            },
            {
                data: "motherName"
            },
            {
                data: "department.name"
            },
            {
                data: "section"
            },
            {
                data: "gender"
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
                    return "<a class='btn btn-info btn-sm js-edit' data-id=" + data + " ><i class='fa fa-pencil-square fa-2x' aria-hidden='false'></i></a>";
                }
                //<button type="button" class="btn btn-cta"><a asp-page="/Inventory">Manage Inventory</a></button>
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
