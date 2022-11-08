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
quantidade_recebimentos_cai int
);

create table Venda(
id_ven int not null primary key auto_increment,
valor_ven double,
data_ven date,
hora_ven time,
forma_pagamento_ven varchar(300),

id_fun_fk integer not null,
id_cli_fk integer not null,
foreign key (id_fun_fk) references Funcionario (id_fun),
foreign key (id_cli_fk) references Cliente (id_cli)
);

create table Compra(
id_com int not null primary key auto_increment,
valor_com double,
data_com date,
hora_com time,
forma_pagamento_com varchar(300),

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
tipo_rec varchar(300),
status_rec varchar (300),
parcelamento_rec varchar(300),
forma_pagamento_rec varchar(300),

id_ven_fk integer not null,
id_cai_fk integer not null,
foreign key (id_ven_fk) references Venda (id_ven),
foreign key (id_cai_fk) references Caixa (id_cai)
);

create table Produto_Venda(
id_pro_ven int not null primary key auto_increment,
quantidade_pro_ven int, 

id_pro_fk integer not null,
id_ven_fk integer not null,
foreign key (id_pro_fk) references Produto (id_pro),
foreign key (id_ven_fk) references Venda (id_ven)
);

create table Produto_Compra(
id_pro_com int not null primary key auto_increment,
quantidade_pro_com int, 

id_pro_fk integer not null,
id_com_fk integer not null,
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
CALL InserirSexo('Não Informar');

#INSERIR FUNCIONARIO
DELIMITER $$
CREATE PROCEDURE InserirFuncionario(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, carteiraTrabalho varchar(300), salario double, foto blob, idSexo int)
BEGIN
    insert into Funcionario values (null, nome, email, cpf, telefone, rua, numero, bairro, rg, dataNasc, carteiraTrabalho, salario, foto, idSexo);
END
$$ DELIMITER ;

#INSERIR USUARIO
DELIMITER $$
CREATE PROCEDURE InserirUsuario(nome varchar(300), senha varchar(300), nivelPermissao varchar(300), idFuncionario int)
BEGIN
    insert into Usuario values (null, nome, senha, nivelPermissao, idFuncionario);
END
$$ DELIMITER ;

#INSERIR CLIENTE
DELIMITER $$
CREATE PROCEDURE InserirCliente(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, rendaFamiliar double, foto blob, idSexo int)
BEGIN
    insert into Cliente values (null, nome, email, cpf, telefone, rua, numero, bairro, rg, dataNasc, rendaFamiliar, foto, idSexo);
END
$$ DELIMITER ;

#INSERIR FORNECEDOR
DELIMITER $$
CREATE PROCEDURE InserirFornecedor(nomeFantasia varchar(300), razaoSocial varchar(300), cnpj varchar(300), email varchar(300), rua varchar(300), numero int, bairro varchar(300), telefone varchar(300))
BEGIN
    insert into Fornecedor values (null, nomeFantasia, razaoSocial, cnpj, email, rua, numero, bairro, telefone);
END
$$ DELIMITER ;

#INSERIR DESPESA
DELIMITER $$
CREATE PROCEDURE InserirDespesa(valor double, dataVencimento date, dataPagamento date, formaPagamento varchar(300), descricao varchar(300))
BEGIN
    insert into Despesa values (null, valor, dataVencimento, dataPagamento, formaPagamento, descricao);
END
$$ DELIMITER ;

#INSERIR PRODUTO
DELIMITER $$
CREATE PROCEDURE InserirProduto(nome varchar(300), valorCompra double, valorVenda double, estoque int, descricao varchar(300), foto blob)
BEGIN
    insert into Produto values (null, nome, valorCompra, valorVenda, estoque, descricao, foto);
END
$$ DELIMITER ;

#INSERIR CAIXA
DELIMITER $$
CREATE PROCEDURE InserirCaixa(saldoInicial double, saldoFinal double, dataAbertura date, dataFechamento date, horaAbertura time, horaFechamento time, qtdPagamentos int, qtdRecebimentos int)
BEGIN
    insert into Caixa values (null, saldoInicial, saldoFinal, dataAbertura, dataFechamento, horaAbertura, horaFechamento, qtdPagamentos, qtdRecebimentos);
END
$$ DELIMITER ;

#INSERIR VENDA
DELIMITER $$
CREATE PROCEDURE InserirVenda(valor double, dataVenda date, horaVenda time, formaPagamento varchar(300), idFuncionario int, idCliente int)
BEGIN
    insert into Venda values (null, valor, dataVenda, horaVenda, formaPagamento, idFuncionario, idCliente);
END
$$ DELIMITER ;

#INSERIR COMPRA
DELIMITER $$
CREATE PROCEDURE InserirCompra(valor double, dataCompra date, horaCompra time, formaPagamento varchar(300), idFuncionario int, idFornecedor int)
BEGIN
    insert into Compra values (null, valor, dataCompra, horaCompra, formaPagamento, idFuncionario, idFornecedor);
END
$$ DELIMITER ;

#INSERIR PAGAMENTO
DELIMITER $$
CREATE PROCEDURE InserirPagamento(valor double, dataVencimento date, hora time, descricao varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idDespesa int, idCaixa int)
BEGIN
    insert into Pagamento values (null, valor, dataVencimento, hora, descricao, status, parcelamento, formaPagamento, idDespesa, idCaixa);
END
$$ DELIMITER ;

#INSERIR RECEBIMENTO
DELIMITER $$
CREATE PROCEDURE InserirRecebimento(valor double, dataRecebimento date, hora time, descricao varchar(300), tipo varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idVenda int, idCaixa int)
BEGIN
    insert into Recebimento values (null, valor, dataRecebimento, hora, descricao, tipo, status, parcelamento, formaPagamento, idVenda, idCaixa);
END
$$ DELIMITER ;

#INSERIR PRODUTO_VENDA
DELIMITER $$
CREATE PROCEDURE InserirProdutoVenda(quantidade int, idProduto int, idVenda int)
BEGIN
    insert into Produto_Venda values (null, quantidade, idProduto, idVenda);
END
$$ DELIMITER ;

#INSERIR PRODUTO_COMPRA
DELIMITER $$
CREATE PROCEDURE InserirProdutoCompra(quantidade int, idProduto int, idCompra int)
BEGIN
    insert into Produto_Compra values (null, quantidade, idProduto, idCompra);
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
    delete from Usuario where (id_usu = id);
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

#DELETAR VENDA
DELIMITER $$
CREATE PROCEDURE DeletarVenda(id int)
BEGIN
    delete from Venda where (id_ven = id);
END
$$ DELIMITER ;

#DELETAR Compra
DELIMITER $$
CREATE PROCEDURE DeletarCompra(id int)
BEGIN
    delete from Compra where (id_com = id);
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
CREATE PROCEDURE DeletarProdutoVenda(id int)
BEGIN
    delete from Produto_Venda where (id_pro_ven = id);
END
$$ DELIMITER ;

#DELETAR PRODUTO_COMPRA
DELIMITER $$
CREATE PROCEDURE DeletarProdutoCompra(id int)
BEGIN
    delete from Produto_Compra where (id_pro_com = id);
END
$$ DELIMITER ;

#PROCEDIMENTOS UPDATE

#ATUALIZAR SEXO
DELIMITER $$
CREATE PROCEDURE AtualizarSexo(id int, tipo varchar(300))
BEGIN
    update Sexo set tipo_sex = tipo where (id_sex = id);
END
$$ DELIMITER ;

#ATUALIZAR FUNCIONARIO
/*
DELIMITER $$
CREATE PROCEDURE AtualizarFuncionario(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, carteiraTrabalho varchar(300), salario double, foto blob, idSexo int)
BEGIN
    update Funcionario set nome_fun = nome, email_fun = email, cpf_fun = cpf, telefone_fun = telefone, rua_fun = rua, numero_fun = numero, bairro_fun = bairro, rg_fun = rg, data_nasc_fun = dataNasc, carteira_de_trabalho_fun = carteiraTrabalho, salario_fun = salario, foto_fun = foto where (id_fun = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR USUARIO
/*
DELIMITER $$
CREATE PROCEDURE AtualizarUsuario(nome varchar(300), senha varchar(300), nivelPermissao varchar(300), idFuncionario int)
BEGIN
    update Usuario set nome_usu = nome, senha_usu = senha, nivel_permissao_usu = nivelPermissao, id_fun_fk = idFuncionario where (id_usu = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR CLIENTE
/*
DELIMITER $$
CREATE PROCEDURE AtualizarCliente(nome varchar(300), email varchar(300), cpf varchar(300), telefone varchar(300), rua varchar(300), numero int, bairro varchar(300), rg varchar(300), dataNasc date, rendaFamiliar double, foto blob, idSexo int)
BEGIN
    update Cliente set nome_cli = nome, email_cli = email, cpf_cli = cpf, telefone_cli = telefone, rua_cli = rua, numero_cli = numero, bairro_cli = bairro, rg_cli = rg, data_nasc_cli = dataNasc, renda_familiar_cli = rendaFamiliar, foto_cli = foto, id_sex_fk = idSexo where (id_cli = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR FORNECEDOR
/*
DELIMITER $$
CREATE PROCEDURE AtualizarFornecedor(nomeFantasia varchar(300), razaoSocial varchar(300), cnpj varchar(300), email varchar(300), rua varchar(300), numero int, bairro varchar(300), telefone varchar(300))
BEGIN
    update Fornecedor set nome_fantasia_for = @nomeFantasia, razao_social_for = razaoSocial, cnpj_for = @cnpj, email_for = @email, rua_for = @rua, numero_for = @numero, bairro_for = @bairro, telefone_for = @telefone where (id_for = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR DESPESA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarDespesa(valor double, dataVencimento date, dataPagamento date, formaPagamento varchar(300), descricao varchar(300))
BEGIN
    update Despesa set valor_des = valor, data_vencimento_des = dataVencimento, data_pagamento_des = dataPagamento, forma_pagamento_des = formaPagamento, descricao_des = descricao where (id_des = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR PRODUTO
/*
DELIMITER $$
CREATE PROCEDURE AtualizarProduto(nome varchar(300), valorCompra double, valorVenda double, estoque int, descricao varchar(300), foto blob)
BEGIN
    update Produto set nome_pro = nome, valor_compra_pro = valorCompra, valor_venda_pro = valorVenda, estoque_pro = estoque, descricao_pro = descricao, foto_pro = foto where (id_pro = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR CAIXA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarCaixa(saldoInicial double, saldoFinal double, dataAbertura date, dataFechamento date, horaAbertura time, horaFechamento time, qtdPagamentos int, qtdRecebimentos int)
BEGIN
    update Caixa set saldo_inicial_cai = saldoInicial, saldo_final_cai = saldoFinal, data_abertura_cai = dataAbertura, data_fechamento_cai = dataFechamento, hora_abertura_cai = horaAbertura, hora_fechamento_cai = horaFechamento, quantidade_pagamentos_cai = qtdPagamentos, quantidade_recebimentos_cai = qtdRecebimentos where (id_cai = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR VENDA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarVenda(valor double, dataVenda date, horaVenda time, formaPagamento varchar(300), idFuncionario int, idCliente int)
BEGIN
    update Venda set valor_ven = valor, data_ven = dataVenda, hora_ven = horaVenda, forma_pagamento_ven = formaPagamento, id_fun_fk = idFuncionario, id_cli_fk = idCliente where (id_ven = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR COMPRA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarCompra(valor double, dataCompra date, horaCompra time, formaPagamento varchar(300), idFuncionario int, idFornecedor int)
BEGIN
    update Compra set valor_com = valor, data_com = dataCompra, hora_com = horaCompra, forma_pagamento_com = formaPagamento, id_fun_fk = idFuncionario, id_for_fk = idFornecedor where (id_com = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR PAGAMENTO
/*
DELIMITER $$
CREATE PROCEDURE AtualizarPagamento(valor double, dataVencimento date, hora time, descricao varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idDespesa int, idCaixa int)
BEGIN
    update Pagamento set valor_pag = valor, data_vencimento_pag = dataVencimento, hora_pag = hora, descricao_pag = descricao, status_pag = status, parcelamento_pag = parcelamento, forma_pagamento_pag = formaPagamento, id_des_fk = idDespesa, id_cai_fk = idCaixa where (id_pag = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR RECEBIMENTO
/*
DELIMITER $$
CREATE PROCEDURE AtualizarRecebimento(valor double, dataRecebimento date, hora time, descricao varchar(300), tipo varchar(300), status varchar(300), parcelamento varchar(300), formaPagamento varchar(300), idVenda int, idCaixa int)
BEGIN
    update Recebimento set valor_rec = valor, data_recebimento_rec = dataRecebimento, hora_rec = hora, descricao_rec = descricao, tipo_rec = tipo, status_rec = status, parcelamento_rec = parcelamento, forma_pagamento_rec = formaPagamento, id_ven_fk = idVenda, id_cai_fk = idCaixa where (id_rec = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR PRODUTO_VENDA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarProdutoVenda(quantidade int, idProduto int, idVenda int)
BEGIN
    update Produto_Venda set quantidade_pro_ven = quantidade, id_pro_fk = idProduto, id_ven_fk = idVenda where (id_pro_ven = id);
END
$$ DELIMITER ;
*/

#ATUALIZAR PRODUTO_COMPRA
/*
DELIMITER $$
CREATE PROCEDURE AtualizarProdutoCompra(quantidade int, idProduto int, idCompra int)
BEGIN
    update Produto_Compra set quantidade_pro_com = quantidade, id_pro_fk = idProduto, id_com_fk = idCompra where (id_pro_com = id);
END
$$ DELIMITER ;
*/