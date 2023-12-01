-- STORED PROCEDURES
DELIMITER $$
SELECT 'Creando Stored Procedure' AS Estado $$
DROP PROCEDURE IF EXISTS altaTitulos $$
CREATE PROCEDURE altaTitulos(OUT unIdTitulo SMALLINT UNSIGNED,
                            unNombre VARCHAR(45),
                            unAnioPrimero SMALLINT UNSIGNED)
BEGIN
    INSERT INTO titulos(nombre, anio_primero) 
    VALUES(unNombre, unAnioPrimero);
        SET unIdTitulo = LAST_INSERT_ID();
END $$
-- Dar de alta a los autores
DELIMITER $$
DROP PROCEDURE IF EXISTS altaAutores $$
CREATE PROCEDURE altaAutores(OUT unIdAutor SMALLINT UNSIGNED,
                            unNombre VARCHAR(45),
                            unApellido VARCHAR(45))
BEGIN
    INSERT INTO autores(nombre, apellido) VALUES (unNombre, unApellido);
    SET unIdAutor = LAST_INSERT_ID();
END $$

-- Dar de alta los títulos
DELIMITER $$
DROP PROCEDURE IF EXISTS altaTitulosAutores $$
CREATE PROCEDURE altaTitulosAutores(unIdTitulo SMALLINT UNSIGNED,
                                    unIdAutor SMALLINT UNSIGNED)

BEGIN 
    INSERT INTO titulosautores(idTitulo, idAutor)
        VALUES(unIdTitulo, unIdAutor);
END $$
DELIMITER $$

-- Dar de alta las editoriales
DROP PROCEDURE IF EXISTS altaEditoriales $$
CREATE PROCEDURE altaEditoriales(OUT unIdEditorial SMALLINT UNSIGNED,
                                unEditorial VARCHAR(45))

BEGIN
    INSERT INTO editoriales(editorial) VALUES(unEditorial);
    SET unIdEditorial= LAST_INSERT_ID();
END $$

-- Dar de alta los ejemplares
DELIMITER $$
DROP PROCEDURE IF EXISTS altaEjemplares $$
CREATE PROCEDURE altaEjemplares(unISBN BIGINT UNSIGNED,
                                unIdEditorial SMALLINT UNSIGNED,
                                unCant_copias TINYINT UNSIGNED , 
                                unIdTitulo SMALLINT UNSIGNED,
                                unCant_prestamos SMALLINT UNSIGNED)

BEGIN
    INSERT INTO ejemplares(ISBN, idEditorial, cant_copias, idTitulo, cant_prestamos)
        VALUES(unISBN, unIdEditorial, unCant_copias, unIdTitulo, unCant_prestamos);
END $$

-- Dar de alta los ejemplares fuera de circulación
DELIMITER $$
DROP PROCEDURE IF EXISTS altaFueraCirculacion $$
CREATE PROCEDURE altaFueraCirculaciones(unFecha_salida DATETIME,
                                        unNum_copia TINYINT UNSIGNED, 
                                        unISBN BIGINT UNSIGNED)

BEGIN
    INSERT INTO fueracirculacion(fechaSalida, numCopia, ISBN)
        VALUES(unFecha_salida, unNum_copia, unISBN);
END $$

-- Dar de alta los cursos
DELIMITER $$
DROP PROCEDURE IF EXISTS altaCursos $$
CREATE PROCEDURE altaCursos(OUT unIdCurso TINYINT UNSIGNED,
                            unAnio TINYINT UNSIGNED,
                            unDivision TINYINT UNSIGNED)

BEGIN 
    INSERT INTO cursos(anio, division) VALUES(unAnio, unDivision);
        SET unIdCurso = LAST_INSERT_ID();
END $$

-- Dar de alta a los alumnos
DELIMITER $$
DROP PROCEDURE IF EXISTS altaAlumnos $$
CREATE PROCEDURE altaAlumnos(unDNI INT UNSIGNED,
                            unNombre VARCHAR(45),
                            unApellido VARCHAR(45),
                            unCelular BIGINT UNSIGNED, 
                            unEmail VARCHAR(45),
                            unContrasenia CHAR(64),
                            unIdCurso TINYINT UNSIGNED)

BEGIN
    INSERT INTO alumnos(DNI, nombre, apellido, celular, email, contrasenia, idCurso)
        VALUES(unDNI, unNombre, unApellido, unCelular, unEmail, unContrasenia,  unIdCurso);
END $$


-- Realizar la función “PorcentajeFuera”, que reciba por parámetro un ISBN y la función tiene que devolver el porcentaje de copias fuera de circulación (0% a 100%, con 2 decimales a lo sumo).
DELIMITER $$
DROP FUNCTION IF EXISTS PorcentajeFuera $$
CREATE FUNCTION PorcentajeFuera (unISBN BIGINT UNSIGNED) RETURNS FLOAT READS SQL DATA
BEGIN
    DECLARE porcentaje FLOAT;
    DECLARE cantidad_ejemplares TINYINT UNSIGNED;
    DECLARE cantidad_fuera TINYINT UNSIGNED;

    SELECT cant_copias INTO cantidad_ejemplares
    FROM ejemplares
    WHERE ISBN = unISBN;
    SELECT COUNT(*) INTO cantidad_fuera
    FROM fueracirculacion
    WHERE ISBN = unISBN;
    SELECT ((cantidad_fuera/cantidad_ejemplares)*100) INTO porcentaje;


    RETURN ROUND(porcentaje, 2);
END $$