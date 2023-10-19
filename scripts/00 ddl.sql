DROP DATABASE IF EXISTS Biblioteca;
CREATE DATABASE Biblioteca;

USE Biblioteca; 

CREATE TABLE Titulos
(
    idTitulo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    anio_primero SMALLINT UNSIGNED,
    CONSTRAINT PK_Titulos PRIMARY KEY (idTitulo),
    CONSTRAINT UQ_nombre UNIQUE(nombre)
);

CREATE TABLE Autores
(
    idAutor SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    CONSTRAINT PK_Autores PRIMARY KEY (idAutor)
);
CREATE TABLE Cursos
(
    idCurso TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    anio TINYINT UNSIGNED NOT NULL,
    division TINYINT UNSIGNED NOT NULL,
    CONSTRAINT PK_Cursos PRIMARY KEY (idCurso),
    CONSTRAINT UQ_Cursos UNIQUE(anio, division)
);
CREATE TABLE Editoriales
(
    idEditorial SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    editorial VARCHAR(45) NOT NULL,
    CONSTRAINT PK_editoriales PRIMARY KEY (idEditorial),
    CONSTRAINT UQ_editorial UNIQUE(editorial)
);
CREATE TABLE Alumnos
(
    DNI INT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    celular BIGINT UNSIGNED,
    email VARCHAR(45) NOT NULL,
    contrasenia CHAR(64) NOT NULL,
    idCurso TINYINT UNSIGNED,
    CONSTRAINT PK_Alumnos PRIMARY KEY (DNI),
    CONSTRAINT FK_Alumnos_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso)
);
CREATE TABLE Ejemplares
(
    ISBN BIGINT UNSIGNED NOT NULL,
    idEditorial SMALLINT UNSIGNED NOT NULL,
    cant_copias TINYINT UNSIGNED NOT NULL,
    idTitulo SMALLINT UNSIGNED NOT NULL,
    cant_prestamos SMALLINT UNSIGNED NOT NULL,
    CONSTRAINT PK_Ejemplares PRIMARY KEY (ISBN),
    CONSTRAINT FK_Ejemplares_Editorial FOREIGN KEY (idEditorial) REFERENCES Editoriales (idEditorial),
    CONSTRAINT FK_Ejemplares_Titulo FOREIGN KEY (idTitulo) REFERENCES Titulos (idTitulo)
);
CREATE TABLE FueraCirculacion
(
    fechaSalida DATETIME NOT NULL,
    numCopia TINYINT UNSIGNED NOT NULL,
    ISBN BIGINT UNSIGNED NOT NULL,
    CONSTRAINT PK_FueraCirculacion PRIMARY KEY(ISBN, numCopia),
    CONSTRAINT FK_FueraCirculacion_Ejemplares FOREIGN KEY (ISBN) REFERENCES Ejemplares (ISBN)
);
CREATE TABLE TitulosAutores
(
    idAutor SMALLINT UNSIGNED NOT NULL,
    idTitulo SMALLINT UNSIGNED NOT NULL,
    CONSTRAINT PK_TitulosAutores PRIMARY KEY (idAutor, idTitulo),
    CONSTRAINT FK_TitulosAutores_Titulos FOREIGN KEY (idTitulo) REFERENCES Titulos (idTitulo),
    CONSTRAINT FK_TitulosAutores_Autor FOREIGN KEY (idAutor) REFERENCES Autores (idAutor)
);



CREATE TABLE Prestamos
(
    ISBN BIGINT UNSIGNED NOT NULL,
    numCopia TINYINT UNSIGNED NOT NULL,
    DNI INT UNSIGNED NOT NULL,
    fechaSalida DATETIME NOT NULL,
    fechaRegreso DATETIME,
    CONSTRAINT PK_Prestamos PRIMARY KEY(ISBN,numCopia, fechaSalida),
    CONSTRAINT FK_Prestamos_Ejemplares FOREIGN KEY (ISBN) REFERENCES Ejemplares (ISBN),
    CONSTRAINT FK_Prestamos_Alumnos FOREIGN KEY (DNI) REFERENCES Alumnos (DNI)
);