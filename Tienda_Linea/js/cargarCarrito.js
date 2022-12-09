function cargarCarrito() {
    $.ajax({
        type: 'GET',
        url: '/Home/GetCarrito',
        data: {},
        success: function (data) {
            let cantidad = 0
            let product = ""
            if (data.respuestaLista != null) {
                data.respuestaLista.forEach(element => {
                    cantidad += element.Cantidad
                    product += "<li class='list-item d-flex justify-content-between' style='display: flex; justify-content: space-between;'>" +
                        "<p class='text-center'>" + element.NombreProducto + "</p>" +
                        "<p>" + element.Cantidad + "</p>" +
                        "<p>" +
                        "</p>" +
                        "</li>"
                })
                document.getElementById("cart_list").innerHTML = product;
            }
            else {
                product = "<li><p class='text-center'>¡El carrito esta vacio!</p></li>"
                document.getElementById("cart_list").innerHTML = product;
            }
            document.getElementById("art_cart").innerHTML = cantidad;
        },
        error: function (data) {
            console.log('Error')
        }
    });
}

function aumentarCarrito(id) {
    $.ajax({
        type: 'POST',
        url: '/Home/AddCarrito',
        data: {
            "idProducto": id
        },
        dataType: 'json',
        success: function (data) {
            cargarCarrito()
        },
        error: function (data) {
            console.log('Error')
        }
    });
}

function disminuirCarrito(id) {
    $.ajax({
        type: 'POST',
        url: '/Home/DeleteCarrito',
        data: {
            "idProducto": id
        },
        dataType: 'json',
        success: function (data) {
            cargarCarrito()
        },
        error: function (data) {
            console.log('Error')
        }
    });
}