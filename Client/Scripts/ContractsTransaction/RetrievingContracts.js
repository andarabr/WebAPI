$(document).ready(function () {
    LoadIndexContract();
    $('#table').DataTable({
        "ajax": LoadIndexContract()
    })
    ClearScreen();
})

function LoadIndexContract() {
    $.ajax({
        type: "GET",
        url: "/Contracts/LoadContract/",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {

                ConvertJoinDate(val.JoinDate);
                ConvertEndDate(val.EndDate);


                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Employee.FirstName + " " + val.Employee.LastName + '</td>';
                html += '<td>' + NewJoinDate + '</td>';
                html += '<td>' + NewEndDate + '</td>';
                html += '<td>' + val.StatusContract + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += ' | <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a> </td>';
                html += '</tr>';
                i++;
                $('.tbody').html(html);
            });
        }
    });
}

function ConvertJoinDate(joindate) {
    var OldJoinDate = joindate
    var value = new Date(parseInt(OldJoinDate.replace(/(^.*\()|([+-].*$)/g, '')));
    NewJoinDate = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    return NewJoinDate;
}

function ConvertEndDate(enddate) {
    var OldEndDate = enddate
    var value = new Date(parseInt(OldEndDate.replace(/(^.*\()|([+-].*$)/g, '')));
    NewEndDate = value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
    return NewEndDate;
}

function Save() {
    debugger;
    var contract = new Object();
    contract.joindate = $('#JoinDate').val();
    contract.enddate = $('#EndDate').val();
    contract.statuscontract = $('input[name=group2]:checked').val();
    contract.employeeid = $('#Employee').val();
    console.log(contract);
    $.ajax({
        url: '/Contracts/InsertOrUpdate/',
        data: contract,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexContract();
            ClearScreen();
        }
    });
}

function Edit() {
    var contract = new Object();
    contract.id = $('#Id').val();
    contract.joindate = $('#JoinDate').val();
    contract.enddate = $('#EndDate').val();
    contract.statuscontract = $('input[name=group2]:checked').val();
    contract.employeeid = $('#Employee').val();
    $.ajax({
        url: '/Contracts/InsertOrUpdate/',
        data: contract,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexContract();
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: '/Contracts/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            ConvertJoinDate(result.JoinDate);
            ConvertEndDate(result.EndDate);

            var JoinYesterday = new Date(NewJoinDate);
            JoinYesterday.setDate(JoinYesterday.getDate() + 1);
            var JoinToday = JoinYesterday.toISOString().substr(0, 10);

            var EndYesterday = new Date(NewEndDate);
            EndYesterday.setDate(EndYesterday.getDate() + 1);
            var EndToday = EndYesterday.toISOString().substr(0, 10);

            if (result.ContractStatus === "Temporary") {
                $('#TemporaryRadio').prop('checked', true);
                $('#PermanentRadio').prop('checked', false);
            } else {
                $('#TemporaryRadio').prop('checked', false);
                $('#PermanentRadio').prop('checked', true);
            }

            $('#Id').val(result.Id);
            $('#Employee').val(result.Employee.Id);
            document.querySelector("#JoinDate").value = JoinToday;
            document.querySelector("#EndDate").value = EndToday;

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
            url: '/Contracts/Delete/',
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexContract();
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
    $('#Regency').val(0);
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

var Employees = []
function LoadEmployee(element) {
    if (Employees.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Employees/LoadEmployee/",
            success: function (data) {
                Employees = data;
                renderEmployee(element);
            }
        })
    }
    else {
        renderEmployee(element);
    }
}

function renderEmployee(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select Employee'));
    $.each(Employees, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.FirstName + " " + val.LastName));
    })
}
LoadEmployee($('#Employee'));
ClearScreen();

function Validate() {
    debugger;
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Regency').val() == 0) {
        swal("Oops", "Please Choose Regency", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}