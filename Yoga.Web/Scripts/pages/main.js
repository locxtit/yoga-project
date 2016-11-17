function showModalCommon(title, content) {
    $('#modal-common .modal-title').html(title);
    $('#modal-common .modal-body').html(content);

    $('#modal-common').modal('show');
}

function showLoading() {
    $('#modal-loading').modal('show');
}

function hideLoading() {
    $('#modal-loading').modal('hide');
}

function hideModalCommon() {
    $('#modal-common').modal('hide');
}

    function showErrorMessage(error) {
        if (error == null || error == undefined || error == '')
            error = 'Chưa xác định được lỗi';
        alert(error);
    }

    function isBlank(text) {
        if (text == undefined || text == null || text == '')
            return true;
        return false;
    }

    function formateDate(data) {
        if (isBlank(data)) return '';
        return kendo.toString(new Date(parseInt(data)), "dd/MM/yyyy");
    }

    function formateDateTime(data) {
        if (isBlank(data)) return '';
        return kendo.toString(new Date(parseInt(data)), "dd/MM/yyyy HH:mm");
    }

    function parseJsonDate(jsonDateString) {
        if (isBlank(jsonDateString)) return '';
        return jsonDateString.replace('/Date(', '').replace(')/', '');
    }
