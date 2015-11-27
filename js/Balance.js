$(document).ready(function () {
    verBalanceTotal();
});

function verBalanceTotal() {
    $.ajax({
        url: "Balance.aspx/balanceTotal",
        dataType: "json",
        type: "post",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        success: function (data) {
            alert(data.d[1]);
            $("#txt_balance").val(data.d[1]);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}