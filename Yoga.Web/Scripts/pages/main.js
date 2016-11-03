function showModalCommon(title, content) {
    $('#modal-common .modal-title').html(title);
    $('#modal-common .modal-body').html(content);

    $('#modal-common').modal('show');
}

function hideModalCommon() {
    $('#modal-common').modal('hide');
}

function showErrorMessage(error) {
    if (error == null || error == undefined || error == '')
        error = 'Chưa xác định được lỗi';
    alert(error);
}