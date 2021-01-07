
$(function () {

    carregaMascaraInput();
    carregaCepApi();
    tentaCadastrar()
    deletarAluno();
    carregarAluno();
});




function carregaMascaraInput() {
    $("#CadastrAluno_Cpf").mask('000.000.000-00', { reverse: true });

    $("#CadastrAluno_CpfMae").mask('000.000.000-00', { reverse: true });

    $("#CadastrAluno_CpfPai").mask('000.000.000-00', { reverse: true });

    $("#CadastrAluno_Rg").mask('99.999.999-9', { reverse: true });

    $("#CadastrAluno_Telefone").mask("(99) 9999-9999")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-9999");
            } else {
                element.mask("(99) 9999-9999");
            }
        });


    $("#CadastrAluno_TelefoneResponavel").mask("(99) 9999-9999")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-9999");
            } else {
                element.mask("(99) 9999-9999");
            }
        });


    $("#CadastrAluno_Cep").mask("99999-999")
}



function carregaCepApi() {
    $("#CadastrAluno_Cep").change(function (e) {
        let cep = e.target.value

        let cepFormatado = cep.replace(/\.|\-/g, '');


        $.ajax({
            url: `https://viacep.com.br/ws/${cepFormatado}/json`,
            type: 'get',
        }).done(function (response) {
            if (response.erro) {
                alert('Não encontrado dados, baseado no cep informado, preencha os campos');

            } else {

                $("#CadastrAluno_Logadouro").val(response.logradouro);

                $("#CadastrAluno_Cidade").val(response.localidade);

                $("#CadastrAluno_Estado").val(response.uf);


            }

        })



    })
}




function tentaCadastrar() {

    
    $('form[name="cadastroAluno"]').submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: `/alunos/cadastro`,
            type: 'post',
            data: $(this).serialize(),
            dataType: 'json',
            beforeSend: function () {
                Swal.fire({
                    title: 'Processando',
                    allowOutsideClick: false,
                    showConfirmButton: false,
                    onBeforeOpen: () => {
                        Swal.showLoading()
                    },
                });
            },
        }).done(function (response) {

            if (response.sucesso) {

                Swal.fire({
                    icon: 'success',
                    title: 'Cadastro de aluno',
                    text: response.msg,
                    timer: 1700
                })

                setTimeout(() => {
                    window.location = '/alunos/listagem';
                }, 1700)

            }

        });
    })

}


function deletarAluno() {


    $('.deletarAluno').click(function (event) {

        var id = $(this).data("id");
        Swal.fire({
            title: 'Deseja deletar?',
            text: "Após deletar, será inrreversivel!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Não, cancelar!',
            confirmButtonText: 'Sim, desejo, deletar'
        }).then((result) => {
            if (result.isConfirmed) {

                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )


                $.ajax({
                    url: `/alunos/deletar/${id}`,
                    type: 'get',
                    beforeSend: function () {
                        Swal.fire({
                            title: 'Processando',
                            //html: 'data uploading',// add html attribute if you want or remove
                            allowOutsideClick: false,
                            showConfirmButton: false,
                            onBeforeOpen: () => {
                                Swal.showLoading()
                            },
                        });
                    },
                }).done(function (response) {

                    if (response.sucesso) {

                        Swal.fire({
                            icon: 'success',
                            title: 'Aluno',
                            text: response.msg,
                            timer: 1700
                        })

                        setTimeout(() => {
                            window.location = '/alunos/listagem';
                        }, 1700)

                    }

                }).catch(function (response) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Opss..',
                        text: response.msg,
                    })
                })

            }
        })
    });
}

function carregarAluno() {


    $('.editarAluno').click(function (event) {

        var id = $(this).data("id");
        let input = $(this)
        input.context.innerText = "Carregando"



        //$.ajax({
        //    url: `/alunos/editar/${id}`,
        //    type: 'get',
        //    success: function (response) {
        //        console.log(result);
        //    }
        //});

        $.ajax({
            url: `/alunos/editar/${id}`,
            type: 'get',
        }).done(function (response) {
            input.context.innerText = "Editar"

            console.log(response)
            if (response.resultado !== undefined) {

                let body = response.resultado

                $('#CadastrAluno_Nome').val(body.nome)
                $('#CadastrAluno_Cpf').val(body.cpf)
                $('#CadastrAluno_Cep').val(body.cep)
                $('#CadastrAluno_Logadouro').val(body.logadouro)
                $('#CadastrAluno_DataNascimento').val(body.dataNascimento)
                $('#CadastrAluno_Sexo select').val(body.sexo)
                $('#CadastrAluno_Email').val(body.email)
                $('#CadastrAluno_Telefone').val(body.telefone)
                $('#CadastrAluno_TelefoneResponavel').val(body.telefoneResponavel)
                $('#CadastrAluno_Estado').val(body.estado)
                $('#CadastrAluno_Cidade').val(body.cidade)
                $('#CadastrAluno_Mae').val(body.mae)
                $('#CadastrAluno_CpfMae').val(body.cpfMae)
                $('#CadastrAluno_Pai').val(body.pai)
                $('#CadastrAluno_CpfPai').val(body.cpfPai)
                $('#CadastrAluno_Rg').val(body.rg)
                $('#CadastrAluno_EmissaoRg').val(body.emissaoRg)
                $('#CadastrAluno_Nacionalidade').val(body.nacionalidade)
                $('#CadastrAluno_Id').val(body.id)





            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Opss..',
                    text: 'Ocorreu algo inesperado',
                })
            }

        });

    });
}