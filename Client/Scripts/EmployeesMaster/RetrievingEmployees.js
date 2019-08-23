$(document).ready(function () {
    LoadIndexEmployee();
    $('#table').DataTable({
        "ajax": LoadIndexEmployee(),
        "scrollX": true
    });
    ToggleVillage();
    ToggleDistrict();
    ToggleRegency();

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

                background = "";
                foreground = 'style="color : black;"';
                message = "";

                if (typeof val.Login.ListApplications[0] === "undefined") {
                    $("td").addClass("intro");
                    //console.log("asasa");
                    background = 'style="background-color : #ffbbb7"'
                    foreground = 'style="color : red;"'
                    message = "Click to add application"
                    application = "";
                } else {
                    application = val.Login.ListApplications[0].Name;
                };

                LoadManager(LoadManagerId);

                managerName = managerFullName;

                if (val.Gender === true) {
                    loadGender = "Female";
                }
                else {
                    loadGender = "Male";
                }

                if (val.MaritalStatus === true) {
                    loadMarital = "Married";
                }
                else {
                    loadMarital = "Single";
                }


                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td ' + background +
                    '> <a href="#" ' + foreground + ' onclick="return GetLoginsById(' + val.Id + ')">' + val.FirstName + " " + val.LastName +
                    '<br> <span style="color: #007bff; font-size:13px;"><u>' + message + application +'</u></span></a> </td>';
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

            if (result.Gender == 0 && result.MaritalStatus == 0) {
                $('#MaleRadio').prop('checked', true);
                $('#FemaleRadio').prop('checked', false);
            } else {
                $('#MaleRadio').prop('checked', false);
                $('#FemaleRadio').prop('checked', true);
            }

            if (result.MaritalStatus == 0) {
                $('#SingleRadio').prop('checked', true);
                $('#MarriedRadio').prop('checked', false);
            } else {
                $('#SingleRadio').prop('checked', false);
                $('#MarriedRadio').prop('checked', true);
            }

            $('#Id').val(result.Id);
            $('#FirstName').val(result.FirstName);
            $('#LastName').val(result.LastName);
            $('#UserEmail').val(result.UserEmail);
            $('#PhoneNumber').val(result.PhoneNumber);
            $('#BankAccount').val(result.BankAccount);
            $('#Salary').val(result.Salary);
            $('#Address').val(result.Address);
            $('#NumOfChildren').val(result.NumOfChildren);
            $('#ManagerName').val(result.Manager.Id);
            $('#DepartmentName').val(result.Department.Id);
            $('#RoleName').val(result.Role.Id);
            $('#VillageName').val(result.Village.Id);
            $('#DistrictName').val(result.Village.District.Id);
            $('#RegencyName').val(result.Village.District.Regency.Id);
            $('#ProvinceName').val(result.Village.District.Regency.Province.Id);
            $('#ReligionName').val(result.Religion.Id);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();

            console.log(result.Village.District.Regency.Name);
            console.log(result.Village.District.Regency.Id);
            console.log(result.Manager.Id);
        }
    })
}

function Save() {
    debugger;
    var employee = new Object();
    employee.firstname = $('#FirstName').val();
    employee.lastname = $('#LastName').val();
    employee.useremail = $('#UserEmail').val();
    employee.firstname = $('#FirstName').val();
    employee.phonenumber = $('#PhoneNumber').val();
    employee.numofchildren = $('#NumOfChildren').val();
    employee.gender = $('input[name=group1]:checked').val();
    employee.address = $('textarea#Address').val();
    employee.bankaccount = $('#BankAccount').val();
    employee.salary = $('#Salary').val();
    employee.maritalstatus = $('input[name=group2]:checked').val();
    employee.managerid = $('#ManagerName').val();
    employee.departmentid = $('#DepartmentName').val();
    employee.roleid = $('#RoleName').val();
    employee.villageid = $('#VillageName').val();
    employee.religionid = $('#ReligionName').val();
    console.log(employee);
    SendEmail(employee.useremail, employee.firstname, employee.lastname, employee.useremail);
    $.ajax({
        url: '/Employees/InsertOrUpdate/',
        data: employee,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexEmployee();
            ClearScreen();
        }
    });
}


function Edit() {
    var employee = new Object();
    employee.id = $('#Id').val();
    employee.firstname = $('#FirstName').val();
    employee.lastname = $('#LastName').val();
    employee.useremail = $('#UserEmail').val();
    employee.firstname = $('#FirstName').val();
    employee.phonenumber = $('#PhoneNumber').val();
    employee.numofchildren = $('#NumOfChildren').val();
    employee.gender = $('input[name=group1]:checked').val();
    employee.address = $('textarea#Address').val();
    employee.bankaccount = $('#BankAccount').val();
    employee.salary = $('#Salary').val();
    employee.maritalstatus = $('input[name=group2]:checked').val();
    employee.managerid = $('#ManagerName').val();
    employee.departmentid = $('#DepartmentName').val();
    employee.roleid = $('#RoleName').val();
    employee.villageid = $('#VillageName').val();
    employee.religionid = $('#ReligionName').val();
    console.log(employee);
    $.ajax({
        url: '/Employees/InsertOrUpdate/',
        data: employee,
        success: function () {
            swal({
                title: "Updated!",
                text: "That data has been updated!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexEmployee();
            ClearScreen();
        }
    });
}

function EditLogin() {
    var login = new Object();
    login.id = $('#IdLogin').val();
    login.email = $('#WorkEmail').val();
    login.password = $('#Password').val();
    login.applicationid = $('#LoginApplication').val();
    console.log(login);
    $.ajax({
        url: '/Logins/InsertOrUpdate/',
        data: login,
        success: function () {
            swal({
                title: "Updated!",
                text: "That data has been updated!",
                type: "success"
            },
                function () {
                    $('#myModallogin').modal('hide');
                });
            LoadIndexEmployee();
            ClearScreen();
        }
    });
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
            url: '/Employees/Delete/',
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexEmployee();
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}


//--------------------------------------------------

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

//--------------------------------------------------

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

//--------------------------------------------------

var Villages = []
function LoadVillages(element) {
    if (Villages.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Villages/LoadVillage/",
            success: function (data) {
                Villages = data;
                renderVillages(element);
            }
        })
    }
    else {
        renderVillages(element);
    }
}

function renderVillages(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Village'));
    $.each(Villages, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadVillages($('#VillageName'));

//--------------------------------------------------

var Districts = []
function LoadDistricts(element) {
    if (Districts.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Districts/LoadDistrict/",
            success: function (data) {
                Districts = data;
                renderDistricts(element);
            }
        })
    }
    else {
        renderDistricts(element);
    }
}

function renderDistricts(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select District'));
    $.each(Districts, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadDistricts($('#DistrictName'));

//--------------------------------------------------

var Regencies = []
function LoadRegencies(element) {
    if (Regencies.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Regencies/LoadRegency/",
            success: function (data) {
                Regencies = data;
                renderRegencies(element);
            }
        })
    }
    else {
        renderRegencies(element);
    }
}

function renderRegencies(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Regency'));
    $.each(Regencies, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadRegencies($('#RegencyName'));

//--------------------------------------------------

var Provinces = []
function LoadProvinces(element) {
    if (Provinces.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Provinces/LoadProvince/",
            success: function (data) {
                Provinces = data;
                renderProvinces(element);
            }
        })
    }
    else {
        renderProvinces(element);
    }
}

function renderProvinces(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Province'));
    $.each(Provinces, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadProvinces($('#ProvinceName'));

//--------------------------------------------------

var Religions = []
function LoadReligions(element) {
    if (Religions.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Religions/LoadReligion/",
            success: function (data) {
                Religions = data;
                renderReligions(element);
            }
        })
    }
    else {
        renderReligions(element);
    }
}

function renderReligions(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Religion'));
    $.each(Religions, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadReligions($('#ReligionName'));

//--------------------------------------------------

var Managers = []
function LoadManagers(element) {
    if (Managers.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Employees/LoadEmployee/",
            success: function (data) {
                Managers = data;
                renderManagers(element);
            }
        })
    }
    else {
        renderManagers(element);
    }
}

function renderManagers(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Manager'));
    $.each(Managers, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.FirstName + " " + val.LastName));
    })
}
LoadManagers($('#ManagerName'));

//--------------------------------------------------

//--------------------------------------------------

var Applications = []
//debugger;
function LoadApplications(element) {
    if (Applications.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Applications/LoadApplication/",
            success: function (data) {
                Applications = data;
                renderApplications(element);
            }
        })
    }
    else {
        renderApplications(element);
    }
}

function renderApplications(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Application'));
    $.each(Applications, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadApplications($('#LoginApplication'));

//--------------------------------------------------

function GetLoginsById(Id) {
    $.ajax({
        url: '/Logins/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            ApplicationLoginStatus = result.ListApplications[0];

            $('#IdLogin').val(result.Id);
            $('#WorkEmail').val(result.Email);
            $('#Password').val(result.Password);
            if (typeof result.ListApplications[0] === "undefined") {
                $('#LoginApplication').val(0);
            }
            else {
                $('#LoginApplication').val(result.ListApplications[0].Id);
            }
            $('#myModallogin').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
    })
}

function ToggleVillage() {
    $('#DistrictName').on('change', function () {
        if ($('#DistrictName').val() == 0) {
            $('#VillageName').val(0);
            $('#VillageName').prop('disabled', true);
        } else {
            console.log($('#DistrictName').val());
            $('#VillageName').prop('disabled', false);
        }
    });
}

function ToggleDistrict() {
    $('#RegencyName').on('change', function () {
        if ($('#RegencyName').val() == 0) {
            $('#DistrictName').val(0);
            $('#DistrictName').prop('disabled', true);
            $('#VillageName').val(0);
            $('#VillageName').prop('disabled', true);
        } else {
            console.log($('#RegencyName').val());
            $('#DistrictName').prop('disabled', false);
        }
    });
}

function ToggleRegency() {
    $('#ProvinceName').on('change', function () {
        if ($('#ProvinceName').val() == 0) {
            $('#RegencyName').val(0);
            $('#RegencyName').prop('disabled', true);
            $('#DistrictName').val(0);
            $('#DistrictName').prop('disabled', true);
            $('#VillageName').val(0);
            $('#VillageName').prop('disabled', true);
        } else {
            console.log($('#ProvinceName').val());
            $('#RegencyName').prop('disabled', false);
        }
    });
}

function TogglePassword() {
    var PwdForm = document.getElementById("Password");
    if (PwdForm.type === "password") {
        PwdForm.type = "text";
        document.getElementById("togglepass").innerHTML = "<u>Click to hide password</u>"
    }
    else {
        PwdForm.type = "password";
        document.getElementById("togglepass").innerHTML = "<u>Click to show password</u>"
    }

}

function ClearScreen() {
    $('#FirstName').val('');
    $('#LastName').val('');
    $('#UserEmail').val('');
    $('#PhoneNumber').val('');
    $('#NumOfChildren').val('');
    $('#Address').val('');
    $('#BankAccount').val('');
    $('#Salary').val('');
    $('#DepartmentName').val(0);
    $('#ManagerName').val(0);
    $('#ProvinceName').val(0);
    $('#RegencyName').val(0);
    $('#DistrictName').val(0);
    $('#RoleName').val(0);
    $('#VillageName').val(0);
    $('#ReligionName').val(0);
    $('#MaleRadio').prop('checked', false);
    $('#FemaleRadio').prop('checked', false);
    $('#SingleRadio').prop('checked', false);
    $('#MarriedRadio').prop('checked', false);
    $('#VillageName').prop('disabled', true);
    $('#DistrictName').prop('disabled', true);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    debugger;
    if ($('#FirstName').val().trim() == "") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#LastName').val().trim() == "") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#UserEmail').val().trim() == "") {
        swal("Oops", "Please Insert Email", "error")
    } else if ($('#PhoneNumber').val().trim() == "") {
        swal("Oops", "Please Insert Phone Number", "error")
    } else if ($('#NumOfChildren').val().trim() == "") {
        swal("Oops", "Please Insert Children", "error")
    } else if ($('#Address').val().trim() == "") {
        swal("Oops", "Please Insert Address", "error")
    } else if ($('#BankAccount').val().trim() == "") {
        swal("Oops", "Please Insert Bank Account", "error")
    } else if ($('#Salary').val().trim() == "") {
        swal("Oops", "Please Insert Salary", "error")
    } else if ($('#ManagerName').val() == 0) {
        swal("Oops", "Please Choose Manager", "error")
    } else if ($('#DepartmentName').val() == 0) {
        swal("Oops", "Please Choose Department", "error")
    } else if ($('#RoleName').val() == 0) {
        swal("Oops", "Please Choose Role", "error")
    } else if ($('#RegencyName').val() == 0) {
        swal("Oops", "Please Choose Regency", "error")
    } else if ($('#DistrictName').val() == 0) {
        swal("Oops", "Please Choose District", "error")
    } else if ($('#VillageName').val() == 0) {
        swal("Oops", "Please Choose Village", "error")
    } else if ($('#ReligionName').val() == 0) {
        swal("Oops", "Please Choose Religion", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}

function ValidateLogin() {
    //debugger;
    if ($('#LoginApplication').val() == 0 || $('#LoginApplication').val() == " ") {
        swal("Oops", "Please Login Application", "error")
    } else {
        EditLogin();
    }
}

function SendEmail(useremail, firstname, lastname) {
    var WorkEmail = firstname.concat(lastname, '@mii.co.id');
    body_line = escape("\n");
    Email.send({
        Host: "smtp.gmail.com",
        Username: "usermanagement.bootcamp@gmail.com",
        Password: "bootcamp13",
        To: useremail,
        From: "usermanagement.bootcamp@gmail.com",
        Subject: "Metrodata Application Access",
        Body: "Hello " + firstname + " " + lastname + "," + "<br>" + "This is your Login Account : " + "<br>" + "Email : " + WorkEmail + "<br>" + "Password : " + "metrodata.1"
    })   
}