-- STORED PROCEDURES
DELIMITER $$
DROP PROCEDURE IF EXISTS altaTitulos $$
CREATE PROCEDURE altaTitulos(unIdTitulo SMALLINT UNSIGNED,
                            unNombre VARCHAR(45),
                            unAnioPrimero SMALLINT UNSIGNED)
BEGIN
    INSERT INTO titulos(idTitulo,nombre,anio_primero)
        VALUES(unIdTitulo, unNombre, unAnioPrimero);
END $$
-- Dar de alta a los autores
DELIMITER $$
DROP PROCEDURE IF EXISTS altaAutores $$
CREATE PROCEDURE altaAutores(unIdAutor SMALLINT UNSIGNED,
                            unNombre VARCHAR(45),
                            unApellido VARCHAR(45))
BEGIN
    INSERT INTO autores(idAutor, nombre, apellido)
        VALUES(unIdAutor, unNombre, unApellido);
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
CREATE PROCEDURE altaEditoriales(unIdEditorial SMALLINT UNSIGNED,
                                unEditorial VARCHAR(45))

BEGIN
    INSERT INTO editoriales(idEditorial, editorial)
        VALUES(unIdEditorial, unEditorial);
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
DROP PROCEDURE IF EXISTS altaFueraCirculaciones $$
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
CREATE PROCEDURE altaCursos(unIdCurso TINYINT UNSIGNED,
                            unAnio TINYINT UNSIGNED,
                            unDivision TINYINT UNSIGNED)

BEGIN 
    INSERT INTO cursos(idCurso, anio, division)
        VALUES(unIdCurso, unAnio, unDivision);
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
                            unIdCUrso TINYINT UNSIGNED)

BEGIN
    INSERT INTO alumnos(DNI, nombre, apellido, celular, email, contrasenia, idCurso)
        VALUES(unDNI, unNombre, unApellido, unCelular, unEmail, unContrasenia,  unIdCUrso);
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