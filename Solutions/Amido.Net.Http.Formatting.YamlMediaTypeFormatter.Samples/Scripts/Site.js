function updateStatus(method, cssClass, message) {
    jQuery('#status' + method).removeClass();
    jQuery('#status' + method).addClass(cssClass);
    jQuery('#status' + method).text(message);
}

function getData(method, url, accept, codelang) {
    updateStatus(method, 'working', 'In Progress');
    var settings = {
        dataType: 'text',
        method: method,
        headers: {
            Accept: accept + '; charset=utf-8'
        }
    }

    if (method === 'Post') {
        settings.data = jQuery('#bodyPost').val();
        settings.contentType = accept;
    }

    jQuery.ajax(url, settings)
        .done(function (data) {
            jQuery('#data' + method).text(data);
            jQuery('#dataWrapper' + method).removeClass();
            jQuery('#dataWrapper' + method + ' code').removeClass();
            jQuery('#dataWrapper' + method).addClass('language-' + codelang);
            Prism.highlightElement(document.getElementById('data' + method));
            updateStatus(method, 'idle', 'Completed');
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            updateStatus(method, 'error', textStatus + ': ' + errorThrown);
        });
}

function refresh(method) {
    getData(method, jQuery('#url' + method).val(), jQuery('#contentType' + method).val(), jQuery('#contentType' + method + ' option:selected').data('codelang'));
}
