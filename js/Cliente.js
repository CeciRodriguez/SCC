//Se declaran las variables de validación
//Esta validación sollo acepta letras
var expLetras = /^[a-zA-Z áéíóúÁÉÍÓÚñÑ\s]+$/;
//Esta validación sollo acepta letras y puntos
var expLetrasPuntos = /^[a-zA-Z áéíóúÁÉÍÓÚñÑ\s\.&\,]+$/;
//Acepta solo números
var expNumeros = /^[1-9]{1}[0-9]*$/;
//No acepta apostrofes
var expMotivo = /^[\']*$/;
//Acepta números y letras
var expNumerosLetras = /^[1-9]{1}[0-9]*^[a-bA-B]$/;

$(document).ready(function () {




    function verListado() {
        $.ajax({
            url: "ListaClientes.aspx/ConstruirListado", //este es le metodo que se invoca del cSS
            data: "{}",
            dataType: "json",
            type: "post",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                $("#lblListado").val(data.d);
                $("#ListadoCliente").dataTable({
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
                alert("Error al traer el historial")
            }
        });
    };

    $("#ListadoCliente").dataTable({
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

    function verListado() {
        $.ajax({
            url: "ListaClientesE.aspx/ConstruirListado", //este es le metodo que se invoca del cSS
            data: "{}",
            dataType: "json",
            type: "post",
            contentType: "application/json; charset=utf-8",
            dataFilter: function (data) { return data; },
            success: function (data) {
                $("#lblListado").val(data.d);
                $("#ListadoCliente").dataTable({
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
                alert("Error al traer el historial")
            }
        });
    };

    $("#ListadoCliente").dataTable({
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
