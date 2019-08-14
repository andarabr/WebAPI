$(document).ready(function () {
    LoadIndexRole();
    $('#table').DataTable({
        "ajax": LoadIndexRole()
    });
})

function Save() {
    debugger;
    var role = new Object();
    role.name = $('#Name').val();
    $.ajax({
        url: "/Roles/InsertOrUpdate/",
        data: role,
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
            LoadIndexRole();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexRole() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Roles/LoadRole/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td style="width:20%">' + i + '</td>';
                html += '<td style="width:50%">' + val.Name + '</td>';
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
    debugger;
    var role = new Object();
    role.id = $('#Id').val();
    role.name = $('#Name').val();
    $.ajax({
        url: "/Roles/InsertOrUpdate/",
        data: role,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                $('#myModal').modal('hide');
            });
            LoadIndexRole();

            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Roles/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            //$('#Role').val(result.RoleId);

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
            url: "/Roles/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexRole();
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