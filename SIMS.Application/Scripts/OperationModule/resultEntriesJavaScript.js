$(document).ready(function () {
    loadDepartment();
    $("#findStudentId").autocomplete({
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
                    $("#StudentEntryId").val(data.id);
                    $("#findStudentId").val(data.studentId);
                    $("#SearchName").val(data.name);
                    $("#SearchPhoneNo").val(data.phoneNo);

                    loadDatatable(data.id);

                });
        }
    });

});
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
$(document.body).on("click", "#btnSubmit", function () {

    var vm = {};
    var id = $("#Id").val();
    vm.studentEntryId = $("#StudentEntryId").val();
    vm.departmentId = $("#DepartmentId").val();
    vm.boardRoll = $("#BoardRoll").val();
    vm.registrationNo = $("#RegistrationNo").val();
    vm.section = $("#Section").val();
    vm.result = $("#Result").val();
    vm.activeStatus = $("#ActiveStatus").val();
    vm.isActive = $("#IsActive").val();
    vm.session = $("#Session").val();
    vm.subjectId = $("#SubjectId").val();
    vm.remark = $("#Remark").val();


    if (id == 0 || id == "" || id == null) {
        $.ajax({
            url: "/api/ResultInformations",
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
            url: "/api/ResultInformations/" + id,
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

function loadDatatable(id) {

    $("#StudentResultList").DataTable().destroy();

    $("#StudentResultList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/ResultInformations/GetStudentInformations?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "studentEntryId"
            },
            {
                data: "boardRoll"
            },
            {
                data: "department.name"
            },
            {
                data: "subjectId"
            },
            {
                data: "result"
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
function refreshForm() {
    $("#Id").val('');
    $("#StudentEntryId").val('');
    $("#DepartmentId").val('');
    $("#SubjectId").val('');
    $("#BoardRoll").val('');
    $("#Result").val('');
    $("#RegistrationNo").val('');
    $("#Section").val('');
    $("#ActiveStatus").val('');
    $("#Remark").val('');
    $("#Session").val('');
}
$(document.body).on("click", "#btnRefresh", function () {
    refreshForm();

});
$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/ResultInformations/" + id,
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

$(document.body).on("click", ".js-edit", function () {
    refreshForm();
    var button = $(this);
    var id = button.attr("data-id");
    getData(id);
});

function getData(id) {
    $.get("/api/ResultInformations?id=" + id)
        .done(function (data) {
            $("#Id").val(id);
            $("#StudentEntryId").val(data.studentEntryId);
            $("#DepartmentId").val(data.departmentId);
            $("#SubjectId").val(data.subjectId);
            $("#BoardRoll").val(data.boardRoll);
            $("#Result").val(data.result);
            $("#RegistrationNo").val(data.registrationNo);
            $("#Section").val(data.section);
            $("#ActiveStatus").val(data.activeStatus);
            $("#Remark").val(data.remark);
            $("#Session").val(data.session);
        });
}
