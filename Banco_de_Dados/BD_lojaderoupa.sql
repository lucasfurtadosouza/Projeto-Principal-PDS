create database Loja_roupa;
use Loja_roupa;
#Alunos: Daniel Delfino Neto, Lucas Furtado Souza, Lucas Tozo Monção, Maria Eduarda Alves Moriá e Taynara da Silva Pereira.
#Turma: 3°B          Curso: Técnico em Informática

create table Funcionario (
id_fun int not null primary key auto_increment,
nome_fun varchar (300) not null,
email_fun varchar (300),
cpf_fun varchar (300),
telefone_fun varchar (300),
endereco_fun varchar (300),
rg_fun varchar (300),
data_nasc_fun date,
sexo_fun varchar (300),
carteira_de_trabalho_fun varchar (300),
salario_fun float,
foto_fun blob
);

create table Cliente (
id_cli int not null primary key auto_increment,
nome_cli varchar (300) not null,
email_cli varchar (300),
cpf_cli varchar (300),
telefone_cli varchar (300),
endereco_cli varchar (300),
rg_cli varchar (300),
data_nasc_cli date,
sexo_cli varchar (300),
renda_familiar_cli float,
foto_cli blob
);

create table Fornecedor (
id_for int not null primary key auto_increment,
nome_fantasia_for varchar (300) not null,
razao_social_for varchar (300) not null,
cnpj_for varchar (300),
email_for varchar (300),
endereco_for varchar (300),
telefone_for varchar (300)
);

create table Despesa(
id_des int not null primary key auto_increment,
valor_des float,
data_vencimento_des date,
data_pagamento_des date,
forma_pagamento_des varchar(300),
descricao_des varchar(300)
);

create table Produto(
id_pro int not null primary key auto_increment,
nome_pro varchar (300),
valor_compra_pro float,
valor_venda_pro float,
estoque_pro int,
descricao_pro varchar(300),
foto_pro blob
);

create table Caixa(
id_cai int not null primary key auto_increment,
saldo_inicial_cai float,
saldo_final_cai float,
data_abertura_cai date,
data_fechamento_cai date,
hora_abertura_cai time,
hora_fechamento time,
quantidade_pagamentos_cai int,
quantidade_recebimentos_cai int
);

create table Venda(
id_ven int not null primary key auto_increment,
valor_ven float,
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
valor_com float,
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
valor_pag float,
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
valor_rec float,
data_recebimento_rac date,
hora_rac time,
descricao_rac varchar(300),
tipo_rac varchar(300),
status_rac varchar (300),
parcelamento_rac varchar(300),
forma_pagamento_rac varchar(300),

id_ven_fk integer not null,
id_cai_fk integer not null,
foreign key (id_ven_fk) references Venda (id_ven),
foreign key (id_cai_fk) references Caixa (id_cai)
);

create table Produto_Venda(
id_pro_ven int not null primary key auto_increment,
quantidade_pro_ven varchar(300), 

id_pro_fk integer not null,
id_ven_fk integer not null,
foreign key (id_pro_fk) references Produto (id_pro),
foreign key (id_ven_fk) references Venda (id_ven)
);

create table Produto_Compra(
id_pro_com int not null primary key auto_increment,
quantidade_pro_com varchar(300), 

id_pro_fk integer not null,
id_com_fk integer not null,
foreign key (id_pro_fk) references Produto (id_pro),
foreign key (id_com_fk) references Compra (id_com)
);