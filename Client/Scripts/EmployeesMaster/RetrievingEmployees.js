$(document).ready(function () {
    LoadIndexEmployee();
    $('#table').DataTable({
        "ajax": LoadIndexEmployee(),
        "sScrollX": '100%'
})
    ClearScreen();
})

function LoadIndexEmployee() {
    $.ajax({
        type: "GET",
        url: "/Employees/LoadEmployee/",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var loadGender = "";
            var loadMarital = "";
            var i = 1;
            $.each(data, function (index, val) {
                var LoadManagerId = val.Manager.Id;

                LoadManager(LoadManagerId);

                managerName = managerFullName;

                if (val.Gender === true) {
                    loadGender = "Female";
                } else {
                    loadGender = "Male";
                }

                if (val.MaritalStatus === true) {
                    loadMarital = "Married";
                } else {
                    loadMarital = "Single";
                }

                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.FirstName + '</td>';
                html += '<td>' + val.LastName + '</td>';
                html += '<td>' + val.UserEmail + '</td>';
                html += '<td>' + val.PhoneNumber + '</td>';
                html += '<td>' + val.NumOfChildren + '</td>';
                html += '<td>' + loadGender + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.BankAccount + '</td>';
                html += '<td>' + val.Salary + '</td>';
                html += '<td>' + loadMarital + '</td>';
                html += '<td>' + managerName + '</td>';
                html += '<td>' + val.Religion.Name + '</td>';
                html += '<td>' + val.Role.Name + '</td>';
                html += '<td>' + val.Department.Name + '</td>';
                html += '<td>' + val.Village.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a> </td>';
                html += '</tr>';
                i++;
                $('.tbody').html(html);
            });
        }
    });
}

function LoadManager(Id) {
    $.ajax({
        type: "GET",
        data: { id: Id },
        url: "/Employees/GetById/" + Id,
        async: false,
        dataType: "json",
        success: function (result) {
            var managerFirstName = result.FirstName;
            var managerLastName = result.LastName;
            managerFullName = managerFirstName.concat(" ", managerLastName);
        }
    });
    return managerFullName;
}

function GetById(Id) {
    $.ajax({
        url: '/Employees/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#DepartmentName').val(result.Department.Id);
            $('#RoleName').val(result.Role.Id);


            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();

            console.log(result);
        }
    })
}

var Departments = []
function LoadDepartment(element) {
    if (Departments.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Departments/LoadDepartment/",
            success: function (data) {
                Departments = data;
                renderDepartment(element);
            }
        })
    }
    else {
        renderDepartment(element);
    }
}

function renderDepartment(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Department'));
    $.each(Departments, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadDepartment($('#DepartmentName'));

var Roles = []
function LoadRoles(element) {
    if (Roles.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Roles/LoadRole/",
            success: function (data) {
                Roles = data;
                renderRoles(element);
            }
        })
    }
    else {
        renderRoles(element);
    }
}

function renderRoles(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Role'));
    $.each(Roles, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadRoles($('#RoleName'));

function ClearScreen() {
    $('#Name').val('');
    $('#Department').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}