$(document).ready(function () {
    LoadIndexDistrict();
    $('#table').DataTable({
        "ajax": LoadIndexDistrict()
    })
    ClearScreen();
})

function LoadIndexDistrict() {
    $.ajax({
        type: "GET",
        url: "/Villages/LoadVillage/",
        async: false,
        dataType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.District.Name + '</td>';
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
    var village = new Object();
    village.name = $('#Name').val();
    village.DistrictId = $('#District').val();
    console.log(village);
    $.ajax({
        url: '/Villages/InsertOrUpdate/',
        data: village,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexDistrict();
            ClearScreen();
        }
    });
}

function Edit() {
    debugger;
    var village = new Object();
    village.id = $('#Id').val();
    village.name = $('#Name').val();
    village.DistrictId = $('#District').val();
    console.log(village);
    $.ajax({
        url: '/Villages/InsertOrUpdate/',
        data: village,
        success: function () {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexDistrict();
            ClearScreen();
        }
    });
}

function GetById(Id) {
    $.ajax({
        url: '/Villages/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#District').val(result.District.Id);

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
            url: '/Villages/Delete/',
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexDistrict();
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

var Districts = []
function LoadDistrict(element) {
    if (Districts.length == 0) {
        $.ajax({
            type: "GET",
            url: "/Districts/LoadDistrict/",
            success: function (data) {
                Districts = data;
                renderDistrict(element);
            }
        })
    }
    else {
        renderDistrict(element);
    }
}

function renderDistrict(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select District'));
    $.each(Districts, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
    })
}
LoadDistrict($('#District'));
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