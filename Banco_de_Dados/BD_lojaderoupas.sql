drop database if exists Loja_roupa;
create database Loja_roupa;
use Loja_roupa;
#Alunos: Daniel Delfino Neto, Lucas Furtado Souza, Lucas Tozo Monção, Maria Eduarda Alves Moriá e Taynara da Silva Pereira.
#Turma: 3°B          Curso: Técnico em Informática

create table Sexo(
id_sex int not null primary key auto_increment,
tipo_sex varchar(300)
);
create table Funcionario(
id_fun int not null primary key auto_increment,
nome_fun varchar (300) not null,
email_fun varchar (300),
cpf_fun varchar (300),
telefone_fun varchar (300),
rua_fun varchar (300),
numero_fun int,
bairro_fun varchar (300),
rg_fun varchar (300),
data_nasc_fun date,
carteira_de_trabalho_fun varchar (300),
salario_fun double,
foto_fun blob,
id_sex_fk integer,
foreign key (id_sex_fk) references Sexo (id_sex)
);

create table Usuario(
id_usu int primary key auto_increment,
nome_usu varchar(300),
senha_usu varchar(300),
nivel_permissao_usu varchar(300),
id_fun_fk int, 
foreign key (id_fun_fk) references Funcionario(id_fun)
);

create table Cliente(
id_cli int not null primary key auto_increment,
nome_cli varchar (300) not null,
email_cli varchar (300),
cpf_cli varchar (300),
telefone_cli varchar (300),
rua_cli varchar (300),
numero_cli int,
bairro_cli varchar (300),
rg_cli varchar (300),
data_nasc_cli date,
renda_familiar_cli double,
foto_cli blob,
id_sex_fk integer,
foreign key (id_sex_fk) references Sexo (id_sex)
);

create table Fornecedor(
id_for int not null primary key auto_increment,
nome_fantasia_for varchar (300) not null,
razao_social_for varchar (300) not null,
cnpj_for varchar (300),
email_for varchar (300),
rua_for varchar (300),
numero_for int,
bairro_for varchar (300),
telefone_for varchar (300)
);

create table Despesa(
id_des int not null primary key auto_increment,
valor_des double,
data_vencimento_des date,
data_pagamento_des date,
forma_pagamento_des varchar(300),
descricao_des varchar(300)
);

create table Produto(
id_pro int not null primary key auto_increment,
nome_pro varchar (300),
valor_compra_pro double,
valor_venda_pro double,
estoque_pro int,
descricao_pro varchar(300),
foto_pro blob
);

create table Caixa(
id_cai int not null primary key auto_increment,
saldo_inicial_cai double,
saldo_final_cai double,
data_abertura_cai date,
data_fechamento_cai date,
hora_abertura_cai time,
hora_fechamento_cai time,
quantidade_pagamentos_cai int,
quantidade_recebimentos_cai int,
status_cai varchar(100)
);

create table Venda(
id_ven int not null primary key auto_increment,
valor_ven double,
data_ven date,
hora_ven time,
forma_pagamento_ven varchar(300),
status_ven varchar(100),

id_fun_fk integer not null,
id_cli_fk integer not null,
foreign key (id_fun_fk) references Funcionario (id_fun),
foreign key (id_cli_fk) references Cliente (id_cli)
);

create table Controle(
id_con int primary key auto_increment,
usuario_con varchar(300),
senha_con varchar(300)
);

create table Compra(
id_com int not null primary key auto_increment,
valor_com double,
data_com date,
hora_com time,
forma_pagamento_com varchar(300),
status_com varchar(100),

id_fun_fk integer not null,
foreign key (id_fun_fk) references Funcionario (id_fun),
id_for_fk integer not null,
foreign key (id_for_fk) references Fornecedor (id_for)
);

create table Pagamento(
id_pag int not null primary key auto_increment,
valor_pag double,
data_vencimento_pag date,
hora_pag time,
descricao_pag varchar(300),
status_pag varchar (300),
parcelamento_pag varchar(300),
forma_pagamento_pag varchar(300),

id_des_fk integer not null,
id_cai_fk integer not null,
foreign key (id_des_fk) references Despesa (id_des),
foreign key (id_cai_fk) references Caixa (id_cai)
);

create table Recebimento(
id_rec int not null primary key auto_increment,
valor_rec double,
data_recebimento_rec date,
hora_rec time,
descricao_rec varchar(300),
status_rec varchar (300),
parcelamento_rec varchar(300),
forma_pagamento_rec varchar(300),

id_ven_fk integer not null,
id_cai_fk integer not null,
foreign key (id_ven_fk) references Venda (id_ven),
foreign key (id_cai_fk) references Caixa (id_cai)
);

create table Venda_Produto(
id_pro_ven int not null primary key auto_increment,
quantidade_pro_ven int,
valor_pro_ven double,
valor_total_pro_ven double,

id_pro_fk integer,
id_ven_fk integer,
foreign key (id_pro_fk) references Produto (id_pro),
foreign key (id_ven_fk) references Venda (id_ven)
);

create table Compra_Produto(
id_pro_com int not null primary key auto_increment,
quantidade_pro_com int, 
valor_pro_com double,
valor_total_pro_com double,

id_pro_fk integer,
id_com_fk integer,
foreign key (id_pro_fk) references Produto (id_pro),
foreign key (id_com_fk) references Compra (id_com)
);

#PROCEDIMENTOS INSERT

#INSERIR SEXO
DELIMITER $$
CREATE PROCEDURE InserirSexo(tipo varchar(300))
BEGIN
    insert into Sexo values (null, tipo);
END
$$ DELIMITER ;

CALL InserirSexo('Masculino');
CALL InserirSexo('Feminino');
CALL InserirSexo('Outros');

#INSERIR FUNCIONARIO
DELIMITER $$
CREATE PROCEDURE InserirFuncionario(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, carteiraTrabalho varchar(300), salario double, foto blob, idSexo int)
BEGIN
    if(nome <> '') or (nome is not null) then
        if(email <> '') or (email is not null) then
            insert into Funcionario values (null, nome, email, cpf, telefone, rua, numero, bairro, rg, dataNasc, carteiraTrabalho, salario, foto, idSexo);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
    
END
$$ DELIMITER ;

CALL InserirFuncionario('Vitória Marcela Alves', 'vitoriaalves@gmail.com', '982.015.552-52', '(69) 98766-3791', 'Rua Triângulo Mineiro', '519', 'Nova Brasília', '46.877.444-0', '2002-02-25', '746.99192.34-7', 2500, null, 2);
CALL InserirFuncionario('Luiz Francisco Isaac', 'luizrezende@gmail.com', '195.288.362-83', '(69) 99306-8988', 'Rua Estrada Velha', '838', 'Primavera', '25.355.141-9', '2000-07-20', '985.77786.34-1', 2600, null, 1);

#INSERIR USUARIO
DELIMITER $$
CREATE PROCEDURE InserirUsuario(nome varchar(300), senha varchar(300), nivelPermissao varchar(300), idFuncionario int)
BEGIN
    declare check_usuario varchar(300);
    set check_usuario = (select nome_usu from Usuario where (nome_usu = nome));

    if(nome <> '') or (nome is not null) then
        if(check_usuario is null) then
            insert into Usuario values (null, nome, senha, nivelPermissao, idFuncionario);
        else
            select 'O usuário já existe.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR CLIENTE
DELIMITER $$
CREATE PROCEDURE InserirCliente(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, rendaFamiliar double, foto blob, idSexo int)
BEGIN
    if(nome <> '') or (nome is not null) then
        if(email <> '') or (email is not null) then
            insert into Cliente values (null, nome, email, cpf, telefone, rua, numero, bairro, rg, dataNasc, rendaFamiliar, foto, idSexo);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

CALL InserirCliente('Gustavo Cauã Danilo', 'gustavocaua@gmail.com', '202.730.772-95', '(69) 9 8725-6535', 'Rua Padre Sílvio', '360', 'Riachuelo', '24.077.427-9', '1998-05-20', 3000, null, 1);
CALL InserirCliente('Fernando Gonçalves Filho', 'fernandofilho@gmail.com', '202.730.772-95', '(69) 9 8434-4382', 'Rua Saia Bonita', '432', 'Mastodonte', '19.683.220-2', '1995-02-18', 3600, null, 1);

#INSERIR FORNECEDOR
DELIMITER $$
CREATE PROCEDURE InserirFornecedor(nomeFantasia varchar(300), razaoSocial varchar(300), cnpj varchar(300), email varchar(300), rua varchar(300), numero int, bairro varchar(300), telefone varchar(300))
BEGIN
    if(nomeFantasia <> '') or (nomeFantasia is not null) then
        if(razaoSocial <> '') or (razaoSocial is not null) then
            insert into Fornecedor values (null, nomeFantasia, razaoSocial, cnpj, email, rua, numero, bairro, telefone);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

CALL InserirFornecedor('Abibas', 'Abibas Calçados', '27.999.116/0001-32', 'abibascontato@gmail.com', 'Rua Nova Itália', '643', 'Marasol', '(69) 95324-5483');
CALL InserirFornecedor('Caçoali', 'Caçoali Roupas', '05.745.943/0001-67', 'caçoaliempresa@gmail.com', 'Rua Bamé Lurdes', '433', 'Trutânia', '(69) 92345-7422');

#INSERIR DESPESA
DELIMITER $$
CREATE PROCEDURE InserirDespesa(valor double, dataVencimento date, dataPagamento date, formaPagamento varchar(300), descricao varchar(300))
BEGIN
    if(valor > 0) then
        if(descricao <> '') or (descricao is not null) then
            insert into Despesa values (null, valor, dataVencimento, dataPagamento, formaPagamento, descricao);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

CALL InserirDespesa(450, '2022-11-30', '2022-11-07', 'Crédito', 'Energia');
CALL InserirDespesa(500, '2022-11-29', '2022-11-08', 'Crédito', 'Internet');

#INSERIR PRODUTO
DELIMITER $$
CREATE PROCEDURE InserirProduto(nome varchar(300), valorCompra double, valorVenda double, estoque int, descricao varchar(300), foto blob)
BEGIN
    if(nome <> '') or (nome is not null) then
        if(valorCompra > 0) then
            insert into Produto values (null, nome, valorCompra, valorVenda, estoque, descricao, foto);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

CALL InserirProduto('Tênis Pegasos', 300, 350, 30, 'Tênis "Pegasos" marca Abibas', null);
CALL InserirProduto('Jaqueta de Couro', 250, 300, 15, 'Jaqueta para frio de couro', null);

#INSERIR CAIXA
DELIMITER $$
CREATE PROCEDURE InserirCaixa(saldoInicial double, saldoFinal double, dataAbertura date, horaAbertura time, qtdPagamentos int, qtdRecebimentos int, status_caixa varchar(100))
BEGIN
    if(saldoInicial is not null) then
        if(saldoFinal is not null) then
            insert into Caixa values (null, saldoInicial, saldoFinal, dataAbertura, '1111-11-11', horaAbertura, '00:00:00', qtdPagamentos, qtdRecebimentos, status_caixa);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

CALL InserirCaixa(10, 0, '2022-11-19', '12:30:00', 20, 30, 'Aberto');
CALL InserirCaixa(100, 2000, '2022-11-21', '07:20:00', 12, 20, 'Aberto');

#INSERIR VENDA
DELIMITER $$
CREATE PROCEDURE InserirVenda(valor double, dataVenda date, horaVenda time, formaPagamento varchar(300), status_venda varchar(100), idFuncionario int, idCliente int)
BEGIN
    if(valor > 0) then
        if(formaPagamento <> '') or (formaPagamento is not null) then
            insert into Venda values (null, valor, dataVenda, horaVenda, formaPagamento, status_venda, idFuncionario, idCliente);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR COMPRA
DELIMITER $$
CREATE PROCEDURE InserirCompra(valor double, dataCompra date, horaCompra time, formaPagamento varchar(300), status_compra varchar(100), idFuncionario int, idFornecedor int)
BEGIN
    if(valor > 0) then
        if(formaPagamento <> '') or (formaPagamento is not null) then
            insert into Compra values (null, valor, dataCompra, horaCompra, formaPagamento, status_compra, idFuncionario, idFornecedor);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR PAGAMENTO
DELIMITER $$
CREATE PROCEDURE InserirPagamento(valor double, dataVencimento date, hora time, descricao varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idDespesa int, idCaixa int)
BEGIN
    if(valor > 0) then
        if(descricao <> '') or (descricao is not null) then
            insert into Pagamento values (null, valor, dataVencimento, hora, descricao, status, parcelamento, formaPagamento, idDespesa, idCaixa);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR RECEBIMENTO
DELIMITER $$
CREATE PROCEDURE InserirRecebimento(valor double, dataRecebimento date, hora time, descricao varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idVenda int, idCaixa int)
BEGIN
    if(valor > 0) then
        if(descricao <> '') or (descricao is not null) then
            insert into Recebimento values (null, valor, dataRecebimento, hora, descricao, status, parcelamento, formaPagamento, idVenda, idCaixa);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR PRODUTO_VENDA
DELIMITER $$
CREATE PROCEDURE InserirVendaProduto(quantidade int, valor double, valorTotal double, idProduto int, idVenda int)
BEGIN
    if(quantidade > 0) then
        if(valorTotal is not null) then
            insert into Venda_Produto values (null, quantidade, valor, valorTotal, idProduto, idVenda);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#INSERIR PRODUTO_COMPRA
DELIMITER $$
CREATE PROCEDURE InserirCompraProduto(quantidade int, valor double, valorTotal double, idProduto int, idCompra int)
BEGIN
    if(quantidade > 0) then
        if(valorTotal is not null) then
            insert into Compra_Produto values (null, quantidade, valor, valorTotal, idProduto, idCompra);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#PROCEDIMENTOS DELETE

#DELETAR SEXO
DELIMITER $$
CREATE PROCEDURE DeletarSexo(id int)
BEGIN
    delete from Sexo where (id_sex = id);
END
$$ DELIMITER ;

#DELETAR FUNCIONARIO
DELIMITER $$
CREATE PROCEDURE DeletarFuncionario(id int)
BEGIN
    delete from Funcionario where (id_fun = id);
END
$$ DELIMITER ;

#DELETAR USUARIO
DELIMITER $$
CREATE PROCEDURE DeletarUsuario(id int)
BEGIN
	declare verificar int;
	set verificar = (select id_fun_fk from Usuario where (id_usu = id));
	if(busca <> '') or (busca is not null) then
		Update Usuario set id_fun_fk = null where(id_usu = id);
        delete from Usuario where (id_usu = id);
    else
		delete from Usuario where (id_usu = id);
    end if;
END
$$ DELIMITER ;

#DELETAR CLIENTE
DELIMITER $$
CREATE PROCEDURE DeletarCliente(id int)
BEGIN
    delete from Cliente where (id_cli = id);
END
$$ DELIMITER ;

#DELETAR FORNECEDOR
DELIMITER $$
CREATE PROCEDURE DeletarFornecedor(id int)
BEGIN
    delete from Fornecedor where (id_for = id);
END
$$ DELIMITER ;

#DELETAR DESPESA
DELIMITER $$
CREATE PROCEDURE DeletarDespesa(id int)
BEGIN
    delete from Despesa where (id_des = id);
END
$$ DELIMITER ;

#DELETAR PRODUTO
DELIMITER $$
CREATE PROCEDURE DeletarProduto(id int)
BEGIN
    delete from Produto where (id_pro = id);
END
$$ DELIMITER ;

#DELETAR CAIXA
DELIMITER $$
CREATE PROCEDURE DeletarCaixa(id int)
BEGIN
    delete from Caixa where (id_cai = id);
END
$$ DELIMITER ;

#CANCELAR VENDA
DELIMITER $$
CREATE PROCEDURE CancelarVenda(id int)
BEGIN
    Update Venda set status_ven = "Cancelada" where (id_ven = id);
END
$$ DELIMITER ;

#CANCELAR COMPRA
DELIMITER $$
CREATE PROCEDURE CancelarCompra(id int)
BEGIN
    Update Compra set status_com = "Cancelada" where (id_com = id);
END
$$ DELIMITER ;

#DELETAR PAGAMENTO
DELIMITER $$
CREATE PROCEDURE DeletarPagamento(id int)
BEGIN
    delete from Pagamento where (id_pag = id);
END
$$ DELIMITER ;

#DELETAR RECEBIMENTO
DELIMITER $$
CREATE PROCEDURE DeletarRecebimento(id int)
BEGIN
    delete from Recebimento where (id_rec = id);
END
$$ DELIMITER ;

#DELETAR PRODUTO_VENDA
DELIMITER $$
CREATE PROCEDURE DeletarVendaProduto(id int)
BEGIN
    delete from Venda_Produto where (id_pro_ven = id);
END
$$ DELIMITER ;

#DELETAR PRODUTO_COMPRA
DELIMITER $$
CREATE PROCEDURE DeletarCompraProduto(id int)
BEGIN
    delete from Compra_Produto where (id_pro_com = id);
END
$$ DELIMITER ;

#PROCEDIMENTOS UPDATE

#ATUALIZAR FUNCIONARIO
DELIMITER $$
CREATE PROCEDURE AtualizarFuncionario(id int, nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, carteiraTrabalho varchar(300), salario double, foto blob, idSexo int)
BEGIN
    if(id is not null) then
        if(nome <> '') or (nome is not null) then
            update Funcionario set nome_fun = nome, email_fun = email, cpf_fun = cpf, telefone_fun = telefone, rua_fun = rua, numero_fun = numero, bairro_fun = bairro, rg_fun = rg, data_nasc_fun = dataNasc, carteira_de_trabalho_fun = carteiraTrabalho, salario_fun = salario, foto_fun = foto, id_sex_fk = idSexo where (id_fun = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#ATUALIZAR USUARIO
DELIMITER $$
CREATE PROCEDURE AtualizarUsuario(nome varchar(300), senha varchar(300), nivelPermissao varchar(300), idFuncionario int)
BEGIN
    if(nome <> '') or (nome is not null) then
        if(senha <> '') or (senha is not null) then
            update Usuario set nome_usu = nome, senha_usu = senha, nivel_permissao_usu = nivelPermissao, id_fun_fk = idFuncionario where (id_usu = id);
        else
			select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
		select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#ATUALIZAR CLIENTE
DELIMITER $$
CREATE PROCEDURE AtualizarCliente(id int, nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, rendaFamiliar double, foto blob, idSexo int)
BEGIN
    if(id is not null) then
        if(nome <> '') or (nome is not null) then
            update Cliente set nome_cli = nome, email_cli = email, cpf_cli = cpf, telefone_cli = telefone, rua_cli = rua, numero_cli = numero, bairro_cli = bairro, rg_cli = rg, data_nasc_cli = dataNasc, renda_familiar_cli = rendaFamiliar, foto_cli = foto, id_sex_fk = idSexo where (id_cli = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#ATUALIZAR FORNECEDOR
DELIMITER $$
CREATE PROCEDURE AtualizarFornecedor(id int, nomeFantasia varchar(300), razaoSocial varchar(300), cnpj varchar(300), email varchar(300), rua varchar(300), numero int, bairro varchar(300), telefone varchar(300))
BEGIN
    if(id is not null) then
        if(nomeFantasia <> '') or (nomeFantasia is not null) then
            update Fornecedor set nome_fantasia_for = nomeFantasia, razao_social_for = razaoSocial, cnpj_for = @cnpj, email_for = @email, rua_for = @rua, numero_for = @numero, bairro_for = @bairro, telefone_for = @telefone where (id_for = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#ATUALIZAR DESPESA
DELIMITER $$
CREATE PROCEDURE AtualizarDespesa(id int, valor double, dataVencimento date, dataPagamento date, formaPagamento varchar(300), descricao varchar(300))
BEGIN
    if(id is not null) then
        if(valor > 0) then
            update Despesa set valor_des = valor, data_vencimento_des = dataVencimento, data_pagamento_des = dataPagamento, forma_pagamento_des = formaPagamento, descricao_des = descricao where (id_des = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#ATUALIZAR PRODUTO
DELIMITER $$
CREATE PROCEDURE AtualizarProduto(id int, nome varchar(300), valorCompra double, valorVenda double, estoque int, descricao varchar(300), foto blob)
BEGIN
    if(id is not null) then
        if(nome <> '') or (nome is not null) then
            update Produto set nome_pro = nome, valor_compra_pro = valorCompra, valor_venda_pro = valorVenda, estoque_pro = estoque, descricao_pro = descricao, foto_pro = foto where (id_pro = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;

#FECHAR CAIXA
DELIMITER $$
CREATE PROCEDURE FecharCaixa(id int, saldoFinal double, dataFechamento date, horaFechamento time, qtdPagamentos int, qtdRecebimentos int, status_caixa varchar(100))
BEGIN
    if(id is not null) then
        if(status_caixa is not null) then
            update Caixa set saldo_final_cai = saldoFinal, data_fechamento_cai = dataFechamento, hora_fechamento_cai = horaFechamento, quantidade_pagamentos_cai = qtdPagamentos, quantidade_recebimentos_cai = qtdRecebimentos, status_cai = status_caixa where (id_cai = id);
        else
            select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
        end if;
    else
        select 'Ocorreu um erro ao realizar a ação.' as 'Erro';
    end if;
END
$$ DELIMITER ;
CALL FecharCaixa(1, 1400, '2022-11-20', '08:00:00', 20, 30, "Fechado");

#LISTAR SEXO
DELIMITER $$
CREATE PROCEDURE ListarSexo()
BEGIN
	select * from Sexo;
END
$$ DELIMITER ;

#LISTAR CAIXA ABERTO
DELIMITER $$
CREATE PROCEDURE ListarCaixaAberto()
BEGIN
    select * from Caixa where(status_cai = "Aberto");
END
$$ DELIMITER ;

#LISTAR CAIXA(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarCaixa()
BEGIN
	select * from Caixa;
END
$$ DELIMITER ;

#LISTAR CLIENTE(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarCliente(busca varchar(300))
BEGIN
    if(busca <> '') or (busca is not null) then
		Select
        Cliente.id_cli,
		Cliente.nome_cli,
		Cliente.email_cli,
		Cliente.cpf_cli,
		Cliente.telefone_cli,
        Cliente.rua_cli,
        Cliente.numero_cli,
        Cliente.bairro_cli,
        Cliente.rg_cli,
        Cliente.data_nasc_cli,
        Cliente.renda_familiar_cli,
        Cliente.foto_cli,
        Sexo.id_sex,
        Sexo.tipo_sex
        From 
        Cliente, Sexo
        Where
        (nome_cli like (select concat('%', busca, '%'))) and (Cliente.id_sex_fk = Sexo.id_sex);
    else
        Select
        Cliente.id_cli,
		Cliente.nome_cli,
		Cliente.email_cli,
		Cliente.cpf_cli,
		Cliente.telefone_cli,
        Cliente.rua_cli,
        Cliente.numero_cli,
        Cliente.bairro_cli,
        Cliente.rg_cli,
        Cliente.data_nasc_cli,
        Cliente.renda_familiar_cli,
        Cliente.foto_cli,
        Sexo.id_sex,
        Sexo.tipo_sex
        From 
        Cliente, Sexo
        Where
        (Cliente.id_sex_fk = Sexo.id_sex);
    end if;
END
$$ DELIMITER ;

#LISTAR DESPESA(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarDespesa(busca varchar(300))
BEGIN
    if(busca <> '') or (busca is not null) then
        select * from Despesa where (descricao_des like (select concat('%', busca, '%')));
    else
        select * from Despesa;
    end if;
END
$$ DELIMITER ;

#LISTAR FORNECEDOR(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarFornecedor(busca varchar(300))
BEGIN
    if(busca <> '') or (busca is not null) then
        select * from Fornecedor where (nome_fantasia_for like (select concat('%', busca, '%')));
    else
        select * from Fornecedor;
    end if;
END
$$ DELIMITER ;

#LISTAR FUNCIONARIO(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarFuncionario(busca varchar(300))
BEGIN
    if(busca <> '') or (busca is not null) then
        Select
        Funcionario.id_fun,
		Funcionario.nome_fun,
		Funcionario.email_fun,
		Funcionario.cpf_fun,
		Funcionario.telefone_fun,
        Funcionario.rua_fun,
        Funcionario.numero_fun,
        Funcionario.bairro_fun,
        Funcionario.rg_fun,
        Funcionario.data_nasc_fun,
        Funcionario.carteira_de_trabalho_fun,
        Funcionario.salario_fun,
        Funcionario.foto_fun,
        Sexo.id_sex,
        Sexo.tipo_sex
        From 
        Funcionario, Sexo
        Where
        (nome_fun like (select concat('%', busca, '%'))) and (Funcionario.id_sex_fk = Sexo.id_sex);
    else
        Select
        Funcionario.id_fun,
		Funcionario.nome_fun,
		Funcionario.email_fun,
		Funcionario.cpf_fun,
		Funcionario.telefone_fun,
        Funcionario.rua_fun,
        Funcionario.numero_fun,
        Funcionario.bairro_fun,
        Funcionario.rg_fun,
        Funcionario.data_nasc_fun,
        Funcionario.carteira_de_trabalho_fun,
        Funcionario.salario_fun,
        Funcionario.foto_fun,
        Sexo.id_sex,
        Sexo.tipo_sex
        From 
        Funcionario, Sexo 
        Where
        (Funcionario.id_sex_fk = Sexo.id_sex);
    end if;
END
$$ DELIMITER ;

#LISTAR PRODUTO(SELECT)
DELIMITER $$
CREATE PROCEDURE ListarProduto(busca varchar(300))
BEGIN
    if(busca <> '') or (busca is not null) then
        select * from Produto where (nome_pro like (select concat('%', busca, '%')));
    else
        select * from Produto;
    end if;
END
$$ DELIMITER ;

#buscar usuario
DELIMITER $$
CREATE PROCEDURE buscarUsuario(usuario1 varchar(300))
BEGIN
	declare buscar int;
	declare usuario varchar(300);
	declare senha varchar(300);
	declare buscar2 int;
	set buscar = (select id_usu from usuario where (nome_usu like usuario1 ));
	set usuario = (select nome_usu from usuario where(buscar = id_usu));
	set senha = (select senha_usu from usuario where(buscar = id_usu));
	set buscar2 = (select id_con from controle where(id_con = 1));
		if(buscar2 <> '') or (buscar2 is not null) then
			delete from controle;
		else
			insert into controle values(null,usuario,senha);
		end if;
END
$$ DELIMITER ;

#CALCULAR LUCRO
DELIMITER $$
CREATE PROCEDURE Lucro()
BEGIN
    declare valorPag double;
    declare valorRec double;
    declare lucro double;
    set valorRec = (select SUM(valor_rec) from Recebimento);
    set valorPag = (select SUM(valor_pag) from Pagamento);
    
    if(valorPag = '') or (valorPag is null) then
		set valorPag = 0;
	end if;
    if(valorRec = '') or (valorRec is null) then
		set valorRec = 0;
	end if;
    
    set lucro = valorRec - valorPag;
    
    if(lucro <> '') or (lucro is not null) then
		select lucro as lucro;
	else
		select 0 as lucro;
	end if;
END
$$ DELIMITER ;

#CALCULAR ITENS VENDIDOS
DELIMITER $$
CREATE PROCEDURE ItensVendidos()
BEGIN
    declare itensVem int;
    set itensVem = (select SUM(quantidade_pro_ven) from Venda_Produto);
    
    if(itensVem = '') or (itensVem is null) then
		select 0 as itensVem;
	else
		select itensVem as itensVem;
	end if;
END
$$ DELIMITER ;

#CALCULAR ESTOQUE
DELIMITER $$
CREATE PROCEDURE EstoqueDisponivel()
BEGIN
    declare estoque int;
    set estoque = (select SUM(estoque_pro) from Produto);
    
    if(estoque = '') or (estoque is null) then
		select 0 as estoque;
	else
		select estoque as estoque;
	end if;
END
$$ DELIMITER ;

#TRIGGERS
#Triggers de Caixa
DELIMITER $$
CREATE TRIGGER aumentarRecebimentosCaixa AFTER INSERT
ON Recebimento FOR EACH ROW
BEGIN
	UPDATE Caixa SET saldo_final_cai = saldo_final_cai +
	NEW.valor_rec, quantidade_recebimentos_cai = quantidade_recebimentos_cai + 1 WHERE (id_cai = NEW.id_cai_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER aumentarPagamentosCaixa AFTER INSERT
ON Pagamento FOR EACH ROW
BEGIN
	UPDATE Caixa SET saldo_final_cai = saldo_final_cai -
	NEW.valor_pag, quantidade_pagamentos_cai = quantidade_pagamentos_cai + 1 WHERE (id_cai = NEW.id_cai_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER diminuirPagamentosCaixa AFTER DELETE
ON Pagamento FOR EACH ROW
BEGIN
	UPDATE Caixa SET saldo_final_cai = saldo_final_cai +
	OLD.valor_pag, quantidade_pagamentos_cai = quantidade_pagamentos_cai - 1 WHERE (id_cai = OLD.id_cai_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER diminuirRecebimentosCaixa AFTER DELETE
ON Recebimento FOR EACH ROW
BEGIN
	UPDATE Caixa SET saldo_final_cai = saldo_final_cai -
	OLD.valor_rec, quantidade_recebimentos_cai = quantidade_recebimentos_cai - 1 WHERE (id_cai = OLD.id_cai_fk);
END;
$$ DELIMITER ;

#Triggers de Estoque
DELIMITER $$
CREATE TRIGGER baixarEstoque AFTER INSERT
ON Venda_Produto FOR EACH ROW
BEGIN
	UPDATE Produto SET estoque_pro = estoque_pro - NEW.quantidade_pro_ven WHERE (id_pro = NEW.id_pro_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER aumentarEstoque AFTER INSERT
ON Compra_Produto FOR EACH ROW
BEGIN
	UPDATE Produto SET estoque_pro = estoque_pro +
	NEW.quantidade_pro_com WHERE (id_pro = NEW.id_pro_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER diminuirEstoque AFTER DELETE
ON Compra_Produto FOR EACH ROW
BEGIN
	UPDATE Produto SET estoque_pro = estoque_pro - OLD.quantidade_pro_com WHERE (id_pro = OLD.id_pro_fk);
END;
$$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER acrescentarEstoque AFTER DELETE
ON Venda_Produto FOR EACH ROW
BEGIN
	UPDATE Produto SET estoque_pro = estoque_pro + OLD.quantidade_pro_ven WHERE (id_pro = OLD.id_pro_fk);
END;
$$ DELIMITER ;