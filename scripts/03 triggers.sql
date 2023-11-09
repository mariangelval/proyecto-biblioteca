-- TRIGGERS 
-- Antes de realizar un préstamo, se tiene que verificar que el ejemplar NO se encuentre entre los ejemplares fuera de circulación o que esté prestado a otra persona; en caso de que se encuentre se tiene que cancelar la operación con la leyenda “Ejemplar fuera de circulación”.
DELIMITER $$
SELECT 'Creando Triggers' AS Estado $$
DROP TRIGGER IF EXISTS ejemplarFueraCirculacion $$
CREATE TRIGGER ejemplarFueraCirculacion AFTER INSERT ON prestamos
FOR EACH ROW
BEGIN
    IF(EXISTS(SELECT *
                FROM fueracirculacion
                WHERE `numCopia` = NEW.`numCopia` AND `ISBN` = NEW.`ISBN`)) THEN
                SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'Ejemplar fuera de circulación';
    END IF;
END $$

-- Verificar si lo tiene prestado otra persona
DELIMITER $$
DROP TRIGGER IF EXISTS ejemplarPrestado $$
CREATE TRIGGER ejemplarPrestado BEFORE INSERT ON prestamos
FOR EACH ROW
BEGIN 
    IF(EXISTS(SELECT *
                FROM prestamos 
                WHERE numCopia = NEW.numCopia AND ISBN = NEW.ISBN AND fechaRegreso IS NULL)) THEN
                SIGNAL SQLSTATE '45000'
                SET MESSAGE_TEXT = 'Ejemplar prestado';
    END IF;
END $$

-- Al efectuar un préstamo, realizar un trigger que incremente el contador de préstamos del libro en cuestión.
DELIMITER $$
DROP TRIGGER IF EXISTS incrementarPrestamos $$
CREATE TRIGGER incrementarPrestamos BEFORE INSERT ON prestamos
FOR EACH ROW
BEGIN
    UPDATE ejemplares
    SET cant_prestamos = cant_prestamos + 1
    WHERE ISBN = NEW.ISBN;
END $$
