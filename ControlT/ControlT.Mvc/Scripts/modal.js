function btnModal(btnId, successFunction) {
    var btn = $("#" + btnId);
    btn.click(function () {
        $('#dialogContent').load(this.href, function() {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');
            bindForm(this, successFunction);
        });
        return false;
    });
}

function bindForm(dialog, successFunction) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#dialogDiv').modal('hide');
                    successFunction();
                } else {
                    $('#dialogContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}
