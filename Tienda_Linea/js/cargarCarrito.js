function cargarCarrito() {
    let idUsuario = document.getElementById("IdUsuario").value;
    fetch('https://localhost:44306/api/Carrito/GetCarrito/?id=' + idUsuario, {
        method: "GET",
        headers: headers,
    })
    .then((response) => response.json())
    .then(function (response) {
        let cantidad = 0
        let product = ""
        if (response.respuestaLista != null) {
            response.respuestaLista.forEach(element => {
                cantidad += element.Cantidad
                fetch('https://localhost:44306/api/Producto/?id=' + element.IdProducto, {
                    method: "GET",
                    headers: headers,
                })
                .then((response) => response.json())
                .then(function (producto) {
                    product += "<li class='list-item d-flex justify-content-between'>"+
                                    "<p>"+producto.respuestaObj.Nombre+"</p>"+
                                    "<p>"+element.Cantidad+"</p>"+
                                    "<p>"+
                                        "<button class='btn btn-primary' onClick=aumentarCarrito("+producto.respuestaObj.IdProducto+")>+</button>"+
                                        "<button class='btn btn-danger ms-3' onClick=disminuirCarrito("+producto.respuestaObj.IdProducto+")>-</button>"+
                                    "</p>"+
                                "</li>"
                    document.getElementById("cart_list").innerHTML = product;
                })
            })
        }
        else {
            product = "<li><p class='text-center'>¡El carrito esta vacio!</p></li>"
            document.getElementById("cart_list").innerHTML = product;
        }
        document.getElementById("art_cart").innerHTML = cantidad;
    })
}

function aumentarCarrito(idProducto) {
    idUsuario = document.getElementById("IdUsuario").value;
    console.log(idProducto)
    fetch('https://localhost:44306/api/Carrito/AddCart', {
        method: "POST",
        headers: headers,
        body: JSON.stringify({ IdUsuario: idUsuario, IdProducto: idProducto })
    })
    .then((response) => response.json())
    .then((response) => cargarCarrito())
}

function disminuirCarrito(idProducto) {
    idUsuario = document.getElementById("IdUsuario").value;
    console.log(idProducto)
    fetch('https://localhost:44306/api/Carrito/RestCart', {
        method: "POST",
        headers: headers,
        body: JSON.stringify({ IdUsuario: idUsuario, IdProducto: idProducto })
    })
        .then((response) => response.json())
        .then((response) => cargarCarrito())
}