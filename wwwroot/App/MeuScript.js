function LimparFormulario() {
    //Limpar formulario
    //Essa função foi criada para a pagina Login
    //pega todos os itens do form e limpa os campos
    $("#log").each(function () {
        this.reset();
    });
};


//Essa função foi criada para a pagina delete
function Del() {
    alert('Usuario Excluído com sucesso')
};

//Essa função foi criada para a pagina edit
function sucesso() {
    alert('Alteração salva')
};

//A função 'valida' no código abaixo é usada para verificar se algum input do formulario não ficara em branco 
//quando o usuario clicar no botão adicionar e chamar a janela pop up "MeuModal"
//function valida() {
//    if (document.getElementById('busca').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca').focus();
//        return false;
//    }
//    $("#MeuModal").modal();
//    return true;
//}

//function valida() {
//    if (document.getElementById('busca').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca').focus();
//        return false;
//    }
//    if (document.getElementById('busca1').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca1').focus();
//        return false;
//    }
//    if (document.getElementById('busca2').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca2').focus();
//        return false;
//    }
//    if (document.getElementById('busca3').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca3').focus();
//        return false;
//    }
//    if (document.getElementById('busca4').value == '') {
//        alert('Prencha todos os Campos');
//        document.getElementById('busca4').focus();
//        return false;
//    }
//    $("#MeuModal").modal();
//    return true;
//};

function valida1() {
   if (document.getElementById('busca').value == '') {
       alert('Prencha todos os Campos');
       document.getElementById('busca').focus();
       return false;
    }
    if (document.getElementById('busca1').value == '') {
        alert('Prencha todos os Campos');
        document.getElementById('busca1').focus();
        return false;
    }
    $("#MeuModal1").modal();
    return true;
};