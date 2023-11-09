DELIMITER ;
SELECT 'Creando Usuarios y Permisos' AS 'Estado';
# Creacion de Usuarios
DROP USER IF EXISTS 'test'@'localhost';
CREATE USER 'test'@'localhost' IDENTIFIED BY 'test';
GRANT ALL ON Biblioteca.* to 'test'@'localhost';