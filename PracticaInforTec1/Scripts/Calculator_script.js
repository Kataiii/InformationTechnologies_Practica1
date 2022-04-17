let str_input = "";
let str_oper = [ '+', '-', '/', '*', '(', ')'];

function prioritetOper(oper) {
    switch (oper) {
        case '(':
            return 0;
        case '*':
        case '/':
            return 1;
        case '+':
        case '-':
            return 2;
    }
}
/*
function exec(num1,num2,oper)
{
    let res;
    switch (oper) {
        case '+':
            res = Number(num1) + Number(num2);
            break;
        case '-':
            res = Number(num1) - Number(num2);
            break;
        case '*':
            res = Number(num1) * Number(num2);
            break;
        case '/':
            res = Number(num1) / Number(num2);
            break;
    }
    return res;
}

operation = function (operator,priorit) {
    this.oper = operator;
    this.prior = priorit; 
}

function parser(formula){
    let lem = [] ;
    let oper = [];
    let tmp = "";
    let flag = 0;

    for (let i = 0; i < formula.length; i++) {
        for (let j = 0; j < str_oper.length; j++) {
            if (formula[i] == str_oper[j]) {
                flag = 1;
            }
        }
        if (flag == 1) {
            if (tmp != "") {
                lem.push(Number(tmp));
            }
            lem.push(new operation(formula[i], prioritetOper(formula[i])));
            tmp = "";
        } else {
            tmp += formula[i];
        }
        flag = 0;
    }
    if (tmp != "") lem.push(Number(tmp));

    for (let i = 0; i < lem.length; i++) {
        console.log(lem[i]);
    }

    let res = 0;

}*/


function readValueButton() {
    let button_number = document.querySelectorAll('.button_number');
    let button_operation = document.querySelectorAll('.button_operations');
    let input = document.getElementById('calculator_textField');

    for (let i = 0; i < button_number.length; i++) {
        button_number[i].addEventListener('click', function () {
            str_input += button_number[i].value;
            input.value = str_input;
        });
    }

    for (let i = 0; i < button_operation.length; i++) {
        button_operation[i].addEventListener('click', function () {
            if (button_operation[i].value == "reset") {
                str_input = "";
                input.value = str_input;
            } else {
                switch (button_operation[i].value) {
                    case "sum":
                        str_input += "+";
                        input.value = str_input;
                        break;
                    case "min":
                        str_input += "-";
                        input.value = str_input;
                        break;
                    case "div":
                        str_input += "/";
                        input.value = str_input;
                        break;
                    case "mul":
                        str_input += "*";
                        input.value = str_input;
                        break;
                    case "result":
                        let result = eval(str_input);
                        if (result == undefined || result == NaN) {
                            input.value = "Error";
                        } else input.value = result;
                        
                        str_input = "";
                        break;
                }
            }
        });
    }
}

readValueButton();