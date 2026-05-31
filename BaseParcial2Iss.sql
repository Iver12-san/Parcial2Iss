CREATE DATABASE Parcial2Iss;
GO
USE master
GO
CREATE LOGIN usrparcial2 WITH PASSWORD = '12345678',
  DEFAULT_DATABASE = Parcial2Iss,
  CHECK_EXPIRATION = OFF,
  CHECK_POLICY = ON
GO
------
USE Parcial2Iss
GO
CREATE USER usrparcial2 FOR LOGIN usrparcial2
GO
ALTER ROLE db_owner ADD MEMBER usrparcial2
GO 
-----------
DROP TABLE IF EXISTS Canal;
DROP TABLE IF EXISTS Programa;
DROP TABLE IF EXISTS ProgramaControl;

---Creamos las tablas--
CREATE TABLE Canal (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    frecuencia VARCHAR(20) NOT NULL,
    usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    estado SMALLINT NOT NULL DEFAULT 1 
);
CREATE TABLE ProgramaControl (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1
);

CREATE TABLE Programa (
    id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idCanal INT NOT NULL,
    idProgramaControl INT NOT NULL,
    titulo VARCHAR(100) NOT NULL,
    descripcion VARCHAR(250) NULL,
    duracion INT NOT NULL,
    productor VARCHAR(100) NOT NULL,
    fechaEstreno DATE NOT NULL,
    usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME(),
    fechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    estado SMALLINT NOT NULL DEFAULT 1,

    CONSTRAINT fk_Programa_Canal FOREIGN KEY (idCanal) REFERENCES Canal(id),

    CONSTRAINT fk_Programa_ProgramaControl FOREIGN KEY (idProgramaControl) REFERENCES ProgramaControl(id)
);



------Para la autoria---
ALTER TABLE Canal ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Canal ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();

ALTER TABLE Programa ADD usuarioRegistro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Programa ADD fechaRegistro DATETIME NOT NULL DEFAULT GETDATE();



----Procedimientos de Crear, Leer, Actualizar y Eliminar de forma lógica para Canal---
-- LISTAR
DROP PROC IF EXISTS paCanalLeer;
GO
CREATE PROC paCanalLeer @parametro VARCHAR(50)
AS
BEGIN
    SELECT id, nombre, frecuencia, estado, usuarioRegistro, fechaRegistro
    FROM Canal
    WHERE estado = 1 AND nombre + frecuencia LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY nombre;
END
GO

DROP PROC IF EXISTS paCanalCrear;
GO
CREATE PROC paCanalCrear @nombre VARCHAR(50), @frecuencia VARCHAR(20)
AS
BEGIN
    INSERT INTO Canal (nombre, frecuencia, estado) VALUES (@nombre, @frecuencia, 1);
    SELECT SCOPE_IDENTITY();
END
GO

DROP PROC IF EXISTS paCanalActualizar;
GO
CREATE PROC paCanalActualizar @id INT, @nombre VARCHAR(50), @frecuencia VARCHAR(20)
AS
BEGIN
    UPDATE Canal SET nombre = @nombre, frecuencia = @frecuencia WHERE id = @id;
END
GO

DROP PROC IF EXISTS paCanalEliminarLogico;
GO
CREATE PROC paCanalEliminarLogico @id INT
AS
BEGIN
    UPDATE Canal SET estado = -1 WHERE id = @id;
END
GO

----Procedimientos de Crear, Leer, Actualizar y Eliminar de forma lógica para Canal---
-- LISTAR
DROP PROC IF EXISTS paProgramaLeer;
GO
CREATE PROC paProgramaLeer @parametro VARCHAR(100)
AS
BEGIN
    SELECT p.id, p.idCanal, c.nombre AS nombreCanal, p.titulo, p.descripcion, p.duracion, p.productor, p.fechaEstreno, p.estado,
    p.fechaRegistro,p.idProgramaControl,pc.nombre AS nombreProgramaControl
    FROM Programa p
    INNER JOIN Canal c ON c.id = p.idCanal INNER JOIN ProgramaControl pc ON pc.id = p.idProgramaControl
    WHERE p.estado = 1 AND p.titulo + c.nombre + p.productor LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY p.titulo;
END
GO

DROP PROC IF EXISTS paProgramaCrear;
GO
CREATE PROC paProgramaCrear @idCanal INT,@idProgramaControl INT, @titulo VARCHAR(100), @descripcion VARCHAR(250), @duracion INT, @productor VARCHAR(100), @fechaEstreno DATE
AS
BEGIN
    INSERT INTO Programa (idCanal, idProgramaControl, titulo, descripcion, duracion, productor, fechaEstreno, estado)
    VALUES (@idCanal, @idProgramaControl, @titulo, @descripcion, @duracion, @productor, @fechaEstreno, 1);
    SELECT SCOPE_IDENTITY();
END
GO

DROP PROC IF EXISTS paProgramaActualizar;
GO
CREATE PROC paProgramaActualizar @id INT, @idCanal INT, @idProgramaControl INT, @titulo VARCHAR(100), @descripcion VARCHAR(250), @duracion INT, @productor VARCHAR(100), @fechaEstreno DATE
AS
BEGIN
    UPDATE Programa SET idCanal = @idCanal, idProgramaControl = @idProgramaControl, titulo = @titulo, descripcion = @descripcion, duracion = @duracion, productor = @productor, fechaEstreno = @fechaEstreno
    WHERE id = @id;
END
GO

DROP PROC IF EXISTS paProgramaEliminarLogico;
GO
CREATE PROC paProgramaEliminarLogico @id INT
AS
BEGIN
    UPDATE Programa SET estado = -1 WHERE id = @id;
END
GO
--Insertamos por base datos a las tablas de Canal--
INSERT INTO Canal (nombre, frecuencia) VALUES
( 'Red Uno', 'VHF-Canal 11'),
('Unitel','UHF-Canal 32');
INSERT INTO ProgramaControl(nombre)
VALUES ('Prueva1'), ('Prueva2'), ('Prueva3'), ('Prueva4');
---vemos los datos--
SELECT * FROM Programa;
SELECT * FROM Programa WHERE nombre LIKE 'Red Uno';
EXEC paProgramaLeer 'papel carta';