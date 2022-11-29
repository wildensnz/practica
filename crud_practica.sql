create database Practica
use Practica

//*Creacion de tablas*//

create table Usuarios(
ID int identity (1,1),
Nombres varchar(50),
Apellidos varchar(50),
Fecha date,
Usuario varchar(50),
Clave varbinary(max)
);
go

alter table Usuarios add Id_rol int
go

create table Permisos(
Id_Permiso int identity(1,1),
Nombre_Permiso varchar(50)
)

go
create table Roles(
Id_Rol int identity(1,1),
Nombre_Rol varchar(50)
)
go

create table Roles_Permisos(
Id_rol_permiso int identity(1,1),
Id_Rol int,
Id_Permiso int,
Estado bit
)

go
create table Productos(
Id_Producto int identity(1,1),
Nombre varchar(50),
Tipo varchar(50),
Precio int,
)

go
create table Empleados(
Id_Empleado int identity(1,1),
Nombre varchar(50),
Apellido varchar(50),
Edad int,
Email varchar(50),
Producto varchar(50)
)

go
create table Imagen(
IdUsuario int,
Imagen image
);

//*Insertar valores a las tablas de asignacion de roles*//


INSERT INTO Roles VALUES('Admin')
INSERT INTO Roles VALUES('User')

INSERT INTO Permisos VALUES('Create')
INSERT INTO Permisos VALUES('Read')
INSERT INTO Permisos VALUES('Update')
INSERT INTO Permisos VALUES('Delete')

INSERT INTO Roles_Permisos VALUES(1,1,1)
INSERT INTO Roles_Permisos VALUES(1,2,1)
INSERT INTO Roles_Permisos VALUES(1,3,1)
INSERT INTO Roles_Permisos VALUES(1,4,1)

INSERT INTO Roles_Permisos VALUES(2,1,0)
INSERT INTO Roles_Permisos VALUES(2,2,1)
INSERT INTO Roles_Permisos VALUES(2,3,0)
INSERT INTO Roles_Permisos VALUES(2,4,0)



//*Procedimientos almacenados*//

create procedure Registrar
@Nombres varchar(50),
@Apellidos varchar(50),
@Fecha date,
@Usuario nvarchar(50),
@Clave varchar(50),
@Patron varchar(50),
@IdUsuario int,
@Id_rol int = 2,
@Imagen image
as
begin
INSERT INTO Usuarios VALUES(@Nombres, @Apellidos, @Fecha, @Usuario, ENCRYPTBYPASSPHRASE(@Patron,@Clave), @Id_rol);
set @IdUsuario=(SELECT ID from Usuarios WHERE Usuario=@Usuario);
INSERT INTO Imagen VALUES (@IdUsuario,@Imagen)
end


create procedure sp_Permisos
@Id_rol int
as
begin
SELECT Nombre_Permiso, Estado FROM Roles_Permisos inner join Permisos on Permisos.Id_Permiso = Roles_Permisos.Id_Permiso WHERE Id_rol = @Id_rol
end


create procedure Validar
@Usuario varchar(50),
@Clave varchar(50),
@Patron varchar(50)
as
begin
SELECT * FROM Usuarios WHERE Usuario=@Usuario and CONVERT(varchar(50), DECRYPTBYPASSPHRASE(@Patron, Clave))=@Clave
end


create procedure Perfil
@ID int
as
begin
SELECT * FROM Usuarios WHERE ID=@ID;
SELECT * FROM Imagen WHERE IdUsuario=@ID;
end


create procedure CargarImagen
@ID int
as
begin
SELECT Imagen FROM Imagen WHERE IdUsuario=@ID
end


create procedure CambiarClave
@ID int,
@Clave varchar(50),
@Patron varchar(50)
as
begin
UPDATE Usuarios set Clave=(ENCRYPTBYPASSPHRASE(@Patron, @Clave)) WHERE ID=@ID
end


create procedure CambiarImagen
@ID int,
@Imagen image
as
begin
UPDATE Imagen set Imagen=@Imagen WHERE IdUsuario=@ID
end


create procedure ContarUsuario
@Usuario varchar(50)
as
begin
SELECT COUNT(*) FROM Usuarios WHERE Usuario=@Usuario
end


create procedure Eliminar
@Id int
as
begin
delete from Usuarios where Id=@ID;
delete from Imagen where IdUsuario=@Id
end


create procedure CargarProductos
as
begin
SELECT * FROM Productos
end


create procedure CrearProductos
@Nombre varchar(50),
@Tipo varchar(50),
@Precio int
as
begin
INSERT INTO Productos VALUES(@Nombre, @Tipo, @Precio)
end


create procedure LeerProducto
@Id_Producto int
as
begin
SELECT * FROM Productos WHERE Id_Producto=@Id_Producto
end


create procedure ActualizarProductos
@Id_Producto int,
@Nombre varchar(50),
@Tipo varchar(50),
@Precio int
as
begin
UPDATE Productos SET Nombre=@Nombre, Tipo=@Tipo, Precio=@Precio WHERE Id_Producto = @Id_Producto
end


create procedure EliminarProductos
@Id_Producto int
as
begin
DELETE FROM Productos WHERE Id_Producto=@Id_Producto
end


create procedure CargarEmpleados
as
begin
SELECT * FROM Empleados
end


create procedure CrearEmpleados
@Nombre varchar(50),
@Apellido varchar(50),
@Edad int,
@Email varchar(50),
@Producto varchar(50)
as
begin
INSERT INTO Empleados VALUES(@Nombre, @Apellido,@Edad, @Email, @Producto)
end


create procedure LeerEmpleados
@Id_Empleado int
as
begin
SELECT * FROM Empleados WHERE Id_Empleado=@Id_Empleado
end


create procedure ActualizarEmpleados
@Id_Empleado int,
@Nombre varchar(50),
@Apellido varchar(50),
@Edad int,
@Email varchar(50),
@Producto varchar(50)
as
begin
UPDATE Empleados SET Nombre=@Nombre, Apellido=@Apellido, Edad=@Edad, Email=@Email, Producto=@Producto WHERE Id_Empleado = @Id_Empleado
end


create procedure EliminarEmpleados
@Id_Empleado int
as
begin
DELETE FROM Empleados WHERE Id_Empleado=@Id_Empleado
end

//*SELECT*//
SELECT Id_Producto, Nombre FROM Productos ORDER BY Id_Producto


