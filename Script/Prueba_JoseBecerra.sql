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
('Carlos Sánchez', 28, 'carlos.sanchez@email.com'),
('Ana López', 34, 'ana.lopez@email.com'),
('Luis Gómez', 22, 'luis.gomez@email.com'),
('Marta Pérez', 40, 'marta.perez@email.com'),
('David Martínez', 25, 'david.martinez@email.com'),
('Laura García', 31, 'laura.garcia@email.com'),
('José Rodríguez', 38, 'jose.rodriguez@email.com'),
('Sofía Fernández', 27, 'sofia.fernandez@email.com'),
('Pedro Hernández', 33, 'pedro.hernandez@email.com'),
('María González', 29, 'maria.gonzalez@email.com'),
('Antonio López', 24, 'antonio.lopez@email.com'),
('Elena Sánchez', 35, 'elena.sanchez@email.com'),
('Raúl Díaz', 26, 'raul.diaz@email.com'),
('Verónica Martínez', 32, 'veronica.martinez@email.com'),
('Ricardo Torres', 30, 'ricardo.torres@email.com');