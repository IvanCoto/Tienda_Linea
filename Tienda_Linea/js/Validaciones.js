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
            console.log(pass)
            console.log(error)
        }

        inputField.addEventListener("change", () => execute())
        execute(true);
    }
}

const frmLogin = new FormValidator("#frmLogin")
const frmRegister = new FormValidator("#frmRegister")

function validationID(value, inputField) {
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

function validationNombre(value, inputField) {
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

//Valida que la contraseña contenga
//2 minusculas
//1 caracter especial
//2 numeros
//3 mayusculas
//Minimo 8 caracteres
function validationStrongPassword(value, inputField) {
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

function validationContraseñasIguales(value, inputField) {
    const passw1 = document.querySelector("#rPassw").value;
    console.log(passw1+" : "+value)
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

frmLogin.registerValidation("identificacion", validationID)

frmRegister.registerValidation("rIdentificacion", validationID)
frmRegister.registerValidation("rName", validationNombre)
frmRegister.registerValidation("rPassw", validationStrongPassword)
frmRegister.registerValidation("rPassw2", validationContraseñasIguales)