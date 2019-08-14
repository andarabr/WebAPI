﻿$(document).ready(function () {
    LoadIndexApplication();
    $('#table').DataTable({
        "ajax": LoadIndexApplication()
    });
})

function Save() {
    debugger;
    var application = new Object();
    application.name = $('#Name').val();
    $.ajax({
        url: "/Applications/InsertOrUpdate/",
        data: application,
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
            LoadIndexApplication();
            $('#myModal').modal('hide');
            ClearScreen();
        }
    });
};

function LoadIndexApplication() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Applications/LoadApplication/",
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
    var application = new Object();
    application.id = $('#Id').val();
    application.name = $('#Name').val();
    $.ajax({
        url: "/Applications/InsertOrUpdate/",
        data: application,
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
            function () {
                $('#myModal').modal('hide');
            });
            LoadIndexApplication();

            ClearScreen();
        }
    });
};

function GetById(Id) {
    $.ajax({
        url: "/Applications/GetById/",
        type: "GET",
        dataType: "json",
        data: { id: Id },
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            //$('#Application').val(result.ApplicationId);

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
            url: "/Applications/Delete/",
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexApplication();
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