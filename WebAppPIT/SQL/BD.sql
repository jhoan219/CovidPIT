 use master
go
if Db_Id('PIT') is not null
  drop database PIT
go
create database PIT
go
use PIT
go
 
 --==========================================================
--------------TABLA PAIS------------------
If Object_id ('pais') is not null
begin
drop table pais
end
create table pais
(
idpais int identity(1,1) primary key,
descripcion varchar(20)
)
go
 
--==========================================================
--------------TABLA Departamento------------------
If Object_id ('departamento') is not null
begin
drop table departamento
end
create table departamento
(
iddepartamento int identity(1,1) primary key,
descripcion varchar(20)
)
go
--==========================================================
--------------TABLA PROVINCIA------------------
If Object_id ('provincia') is not null
begin
drop table provincia
end
create table provincia
(
idprovincia int identity(1,1) primary key,
nombre varchar(45) not null
)
go
--==========================================================
--------------TABLA DISTRITO------------------
If Object_id ('distrito') is not null
begin
drop table distrito
end
create table distrito
(
iddistrito int identity(1,1) primary key,
nombre varchar(45) not null
)
go
--==========================================================
--------------TABLA DOCUMENTO------------------
If Object_id ('documento') is not null
begin
drop table documento
end
create table documento
(
iddocumento int identity(1,1) primary key,
nombre varchar(45) not null
)
go
--==========================================================
--------------TABLA UBICACION------------------
If Object_id ('ubicacion') is not null
begin
drop table ubicacion
end
create table ubicacion
(
idubicacion int identity(1,1) primary key,
ubicacion varchar(45) not null,
latitud varchar(45) not null,
longitud varchar(45) not null
)
go
--==========================================================
--------------TABLA ESTADO------------------
If Object_id ('estado') is not null
begin
drop table estado
end
create table estado
(
idestado int identity(1,1) primary key,
descripcion varchar(45) not null,
)
go
--==========================================================
--------------TABLA CIUDADANO------------------
If Object_id ('ciudadano') is not null
begin
drop table ciudadano
end   
create  table ciudadano
(
idciudadano int identity(1,1) primary key,
nombres varchar(45) not null,
nacionalidad varchar(45) not null,
iddocumento int not null,
numdocumento varchar(45) not null,
tipodocumento int not null,
iddepartamento int not null,
idprovincia int not null,
iddistrito int not null,
idestado int not null,
FOREIGN KEY (idestado) REFERENCES documento(iddocumento),
FOREIGN KEY (iddepartamento) REFERENCES departamento(iddepartamento),
FOREIGN KEY (idprovincia) REFERENCES provincia(idprovincia),
FOREIGN KEY (iddistrito) REFERENCES distrito(iddistrito),
FOREIGN KEY (iddocumento) REFERENCES documento(iddocumento)
)
go 

-----------TABLE USER--------------
If Object_id ('Users') is not null
begin
drop table Users
end
create table Users(
id varchar(20)not null primary key ,
nombre varchar(45) not null,
apellido varchar(50) not null,
dni int not null,
direccion int not null,
usuario varchar(25) not null,
email varchar(60) not null,
password varchar(30) not null,
FOREIGN KEY (idpais) REFERENCES pais(idpais),
)
GO 

-------------------------------------

create procedure   USP_ListarCiudadano
as
begin
select * from ciudadano1
end
exec USP_ListarCiudadano
go
-------------------------------------------
 
--AGREGAR
create proc USP_AgregarCiudadano
@nombres varchar(50),
@nacionalidad varchar(50),
@tipodocumento varchar(50),
@numdocumento varchar(50),
@iddepartamento varchar(50),
@idprovincia varchar(50),
@iddistrito varchar(50),
@idestado varchar(50)
as
begin 
	insert into Ciudadano1 (nombres,nacionalidad,tipodocumento,numdocumento,iddepartamento,idprovincia,iddistrito,idestado)

	values (@nombres,@nacionalidad,@tipodocumento,@numdocumento,@iddepartamento,@idprovincia,@iddistrito,@idestado)
	end
go

 
--ACTUALIZAR
create proc USP_ActualizarCiudadano
@IdVehiculo int,
@Placa varchar(8),
@PesoMaximo decimal(10,2),
@AñoFabricacion int,
@IdMarca int
as
update Vehiculo set @IdVehiculo=IdVehiculo,@Placa=Placa,@PesoMaximo=PesoMaximo,@AñoFabricacion=AñoFabricacion,@IdMarca=IdMarca
where @IdVehiculo=IdVehiculo
go
-----------------------
create proc USP_DetalleCiudadano
@idciudadano  varchar(50)
as
select * from ciudadano1 where idciudadano=@idciudadano
go
---------------------------------------
 





--insert into ciudadano values ('Luis Perez Guzman','peruana',1,'1',1,1,1,1,1)


--==========================================================
--------------TABLA CIUDADANO------------------
If Object_id ('ciudadano1') is not null
begin
drop table ciudadano1
end   
create  table ciudadano1
(
idciudadano int identity(1,1) primary key,
nombres varchar(45) not null,
nacionalidad varchar(45) not null,
tipodocumento varchar(45)  not null,
numdocumento varchar(45) not null,
iddepartamento varchar(45)  not null,
idprovincia varchar(45)  not null,
iddistrito varchar(45)  not null,
idestado varchar(45)  not null, 
)


go 
select * from departamento
select * from documento
select * from estado
select * from pais
select * from provincia
select * from distrito
select * from ciudadano1

insert into distrito values ('Ventanilla')
insert into departamento values ('Callao')
insert into documento values ('Dni')
insert into estado values ('Enfermo')
insert into pais values ('Peru')
insert into provincia values ('Callao')



insert into ciudadano1 values ('Luis Perez Guzman','Peru','Dni','89562312','Lima','Lima','Los Olivos','Enfermo')
insert into ciudadano1 values ('Pedro Rojas Gonzales','Peru','Dni','11223568','Callao','Callao','Ventanilla','Enfermo')
insert into ciudadano1 values ('Maria Lopez Pereida','Peru','Dni','12235678','Lima','Miraflores','Los Olivos','Recuperado')
insert into ciudadano1 values ('Ana Mendoza Loaiza','Peru','Dni','56781223','Lima','Surco','Los Olivos','Fallecido')
insert into ciudadano1 values ('Luisa Campos Robles','Peru','Dni','56234578','Lima','San Martin','Los Olivos','Enfermo')