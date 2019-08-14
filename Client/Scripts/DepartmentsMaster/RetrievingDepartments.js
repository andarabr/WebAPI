$(document).ready(function () {
    LoadIndexDepartment();
    $('#table').DataTable({
        "ajax": LoadIndexDepartment()
    })
    ClearScreen();
})

function LoadIndexDepartment() {
    $.ajax({
        type: "GET",
        url: "/Departments/LoadDepartment/",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Division.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a> </td>';
                html += '</tr>';
                i++;
                $('.tbody').html(html);
            });
        }
    });
}

function Save() {
    debugger;
    var department = new Object();
    department.name = $('#Name').val();
    department.DivisionId = $('#Division').val();
    console.log(department);
    $.ajax({
        url: '/Departments/InsertOrUpdate/',
        data: department,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexDepartment();
            ClearScreen();
        }
    });
}

function Edit() {
    var department = new Object();
    department.id = $('#Id').val();
    department.name = $('#Name').val();
    department.DivisionId = $('#Division').val();
    console.log(department);
    $.ajax({
        url: '/Departments/InsertOrUpdate/',
        data: department,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexDepartment();
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: '/Departments/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Division').val(result.Division.Id);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: '/Departments/Delete/',
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexDepartment();
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#Name').val('');
    $('#Division').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

var Divisions = []
function LoadDivision(element) {
    if (Divisions.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Divisions/LoadDivision/",
            success: function (data) {
                Divisions = data;
                renderDivision(element);
            }
        })
    }
    else {
        renderDivision(element);
    }
}

function renderDivision(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Division'));
    $.each(Divisions, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadDivision($('#Division'));
ClearScreen();

function Validate() {
    debugger;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Division').val() == 0) {
        swal("Oops", "Please Choose Division", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}