$(document).ready(function () {
    LoadIndexLogin();
    $('#table').DataTable({
        "ajax": LoadIndexLogin()
    });
})

function Save() {
    debugger;
    var login = new Object();
    login.email = $('#Email').val();
    login.password = $('#Password').val();
    login.applicationid = $('#ApplicationId').val();
    $.ajax({
        url: "/Logins/InsertOrUpdate/",
        data: login,
        success: function (result) {
            swal({
                toast: true,
                title: "Saved!",
                text: "That data has been saved!",
                type: "success"
            },
            function () {
                $('#myModal').modal('hide');
            });
            LoadIndexLogin();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexLogin() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Logins/LoadLogin/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td style="width:20%">' + i + '</td>';
                html += '<td style="width:50%">' + val.Email + '</td>';
                html += '<td style="width:50%">' + val.Password + '</td>';
                html += '<td style="width:30%"> <a href="#" style="color : orange" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" style="color : red" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Edit() {
    var login = new Object();
    login.id = $('#Id').val();
    login.name = $('#Name').val();
    $.ajax({
        url: "/Logins/InsertOrUpdate/",
        data: login,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                $('#myModal').modal('hide');
            });
            LoadIndexLogin();

            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Logins/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            //$('#Login').val(result.LoginId);

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
            url: "/Logins/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexLogin();
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
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    if ($('#Name').val() == "" || $('#Name').val() == " ") {
        swal("Oops", "Please Insert Name", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}