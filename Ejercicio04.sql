CREATE DATABASE db_tarea
GO

USE db_tarea
GO


CREATE TABLE Materia (
    CodigoMateria CHAR(5) NOT NULL PRIMARY KEY,
    NombreMateria VARCHAR(25) NULL,
    UV INT NULL,
    Prerrequisitos VARCHAR(150) NULL
);

CREATE TABLE Alumno (
    CodigoAlumno CHAR(8) NOT NULL PRIMARY KEY,
    PrimerNombre VARCHAR(20) NULL,
    SegundoNombre VARCHAR(20) NOT NULL,
    PrimerApellido VARCHAR(20) NULL,
    SegundoApellido VARCHAR(20) NOT NULL,
    Edad INT NULL,
    Direccion VARCHAR(100) NULL
);

SELECT * FROM Alumno;