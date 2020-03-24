-----Script para o Banco de Dados
create database teste_webmotors
go 

use teste_webmotors
go
create table tb_AnuncioWebmotors(
ID INT identity not null,
marca varchar (45) not null,
modelo varchar (45) not null,
versao varchar (250) not null,
ano INT not null,
quilometragem INT not null,
observacao text not null
)

Create table tb_Marca(
Id Int not null,
Name varchar(45) not null
)

Create table tb_Modelo(
Id Int not null,
MakeId int not null,
Name varchar(45) not null
)

create table tb_veiculo(
Id Int not null,
Make varchar(45) not null,
Model varchar(45) not null,
Version varchar(250) not null,
Image varchar(max) not null,
KM int not null,
Price decimal(18,2) not null,
YearModel int not null,
YearFab int not null,
Color varchar(45)
)

Create table tb_versao(
Id Int not null,
ModelId int not null,
Name  varchar(250)
)
