
create database BDCrud
go
use BDCrud
go

create table Pessoa
(
  Id            int           primary key   identity,
  Nome          varchar(60)   not null,
  Email         varchar(100)  not null,
  DDD           numeric(3)    null,
  Telefone      numeric(10)   null,
  Endereco      varchar(100)  not null,
  Num_endereco 	numeric(7)    not null
 )

 select * from pessoa


insert into Pessoa values ('Fulano', 'fulano@gmail.com', '011', '995412321', 'Rua dos Alpes', '99')
insert into Pessoa values ('Ciclano', 'ciclano@hotmail.com', '013', '995326987', 'Rua Vergueiro', '1250')