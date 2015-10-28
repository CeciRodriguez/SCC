$(document).ready(function () {

    function verListado() {
        $.ajax({
            url: "Aceptadas.aspx/ConstruirListado", //este es le metodo que se invoca del cSS
            data: "{}",
            dataType: "json",
            type: "post",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                $("#lblListado").val(data.d);
                $("#ListadoAceptadas").dataTable({
                    "bJQueryUI": true,
                    "sPaginationType": "full_numbers",
                    "iDisplayLength": 10,
                    "iDisplayStart": 0,
                    "bSort": true,
                    "bLengthChange": true,
                    "bSort": false, //true
                    "bPaginate": true,
                    "bAutoWidth": true,
                    "aLengthMenu": [[1, 10, 100, 1000, -1], [1, 10, 100, 1000, "Todos"]],
                    "bProcessing": false,
                    "bServerSide": false,
                    "sServerMethod": "POST"

                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Error al traer el listado")
            }
        });
    };

    $("#ListadoAceptadas").dataTable({
        "bJQueryUI": true,
        "sPaginationType": "full_numbers",
        "iDisplayLength": 10,
        "iDisplayStart": 0,
        "bSort": true,
        "bLengthChange": true,
        "bSort": false, //true
        "bPaginate": true,
        "bAutoWidth": true,
        "aLengthMenu": [[1, 10, 100, 1000, -1], [1, 10, 100, 1000, "Todos"]],
        "bProcessing": false,
        "bServerSide": false,
        "sServerMethod": "POST"


    });


});
