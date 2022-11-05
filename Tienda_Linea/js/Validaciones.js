//Clase para asignar validadores a los form
class FormValidator {
    constructor(selector) {
        //Obtiene el elemento del documento
        this.form = document.querySelector(selector)
        //Crea un Set de errores
        this.inputsWithErrors = new Set();

        this.form.addEventListener("submit", e => {
            e.preventDefault();

            //Solo permite enviar el form si no tiene errores
            if (!this.hasErrors) {
                this.form.submit()
            }
        })
    }

    //Get para comprobar si tiene o no errores
    get hasErrors() {
        return this.inputsWithErrors.size > 0
    }

    registerValidation(selector, check) {
        //
        const inputField = this.form.querySelector("#" + selector)
        const errorElement = inputField.closest("." + selector).querySelector(".input_error")
        const execute = (hideErrors) => {
            const { pass, error } = check(inputField.value, inputField)

            if (!hideErrors) {
                errorElement.textContent = error || "";
            }

            if (!pass) {
                this.inputsWithErrors.add(inputField);
            } else {
                this.inputsWithErrors.delete(inputField);
            }
        }

        inputField.addEventListener("change", () => execute())
        execute(true);
    }
}

function validationID(value) {
    const pattern =  /^[1-9]-\d{4}-\d{4}$/;
    if (!pattern.test(value)) {
        return {
            pass: false,
            error: "La informacion ingresada no tiene formato de cedula."
        }
    }
    return {
        pass: true
    };
};

function validationNombre(value) {
    let pattern = /^([a-zA-Z]+) ([a-zA-Z]+)$/;
    if (!pattern.test(value)) {
        return {
            pass: false,
            error: "Debe tener formato de nombre y apellido."
        }
    }

    return {
        pass: true
    };
};

function validationCorreo(value) {
    let pattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/;
    if (!pattern.test(value)) {
        return {
            pass: false,
            error: "Debe tener formato correo."
        }
    }

    return {
        pass: true
    };
};

//Valida que la contraseña contenga
//2 minusculas
//1 caracter especial
//2 numeros
//3 mayusculas
//Minimo 8 caracteres
function validationStrongPassword(value) {
    let pattern = /^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}$/;
    if (!pattern.test(value)) {
        return {
            pass: false,
            error: "La contraseña debe ser de minimo 8 caracteres y debe contener 3 minusculas, 1 caracter especial, 2 numeros, 2 mayusculas."
        }
    }

    return {
        pass: true
    };
};

function validationContraseñasIguales(value) {
    const passw1 = document.querySelector("#rPassw").value;
    if (value != passw1) {
        return {
            pass: false,
            error: "Las contraseñas no coinciden"
        }
    }

    return {
        pass: true
    };
};