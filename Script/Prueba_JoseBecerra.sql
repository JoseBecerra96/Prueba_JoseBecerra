CREATE DATABASE Prueba_JoseBecerra
USE Prueba_JoseBecerra

CREATE TABLE Usuario
(
IdUsuario INT IDENTITY(1,1),
Nombre VARCHAR(50) NOT NULL,
Email VARCHAR(254) NOT NULL,
Edad TINYINT NOT NULL,
)

GO

CREATE PROCEDURE UsuarioAdd 
@Nombre VARCHAR(50),
@Edad TINYINT,
@Email VARCHAR(254)
AS
INSERT INTO Usuario(Nombre,Edad,Email) VALUES (@Nombre,@Edad,@Email)

GO 

CREATE PROCEDURE UsuarioGetAll
AS
SELECT IdUsuario,Nombre,Edad,Email From Usuario


GO 

CREATE PROCEDURE UsuarioDelete 
@IdUsuario TINYINT
AS
DELETE FROM Usuario
WHERE IdUsuario = @IdUsuario


GO 

CREATE PROCEDURE UsuarioUpdate 
@IdUsuario TINYINT,
@Nombre VARCHAR(50),
@Edad TINYINT,
@Email VARCHAR(254)
AS
UPDATE Usuario SET Nombre = @Nombre, Edad = @Edad, Email = @Email
WHERE IdUsuario = @IdUsuario


GO 

CREATE PROCEDURE UsuarioGetById
@IdUsuario TINYINT
AS
SELECT IdUsuario,Nombre,Edad,Email From Usuario
WHERE IdUsuario = @IdUsuario


GO

INSERT INTO Usuario (Nombre, Edad, Email) VALUES
('Carlos S�nchez', 28, 'carlos.sanchez@email.com'),
('Ana L�pez', 34, 'ana.lopez@email.com'),
('Luis G�mez', 22, 'luis.gomez@email.com'),
('Marta P�rez', 40, 'marta.perez@email.com'),
('David Mart�nez', 25, 'david.martinez@email.com'),
('Laura Garc�a', 31, 'laura.garcia@email.com'),
('Jos� Rodr�guez', 38, 'jose.rodriguez@email.com'),
('Sof�a Fern�ndez', 27, 'sofia.fernandez@email.com'),
('Pedro Hern�ndez', 33, 'pedro.hernandez@email.com'),
('Mar�a Gonz�lez', 29, 'maria.gonzalez@email.com'),
('Antonio L�pez', 24, 'antonio.lopez@email.com'),
('Elena S�nchez', 35, 'elena.sanchez@email.com'),
('Ra�l D�az', 26, 'raul.diaz@email.com'),
('Ver�nica Mart�nez', 32, 'veronica.martinez@email.com'),
('Ricardo Torres', 30, 'ricardo.torres@email.com');