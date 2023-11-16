-- INSERTS

SELECT 'Dump' AS Estado $$
-- Cursos
CALL altaCursos(@id58, 5, 8);

-- Alumnos
CALL altaAlumnos(46912870, "Vanina", "Condorpocco", 1132675353,"vanyabrilconblas@gmail.com", 'cake', @id58);
CALL altaAlumnos(95847780, "Mariangel", "Valerio", 1164505763, "valeriomariangel855@gmail.com", 'mariangelmar', @id58);
CALL altaAlumnos(47046671, "Iliana", "Duarte", 1164505763, "iliana.duarteet12d1@gmail.com", 'iluduarte', @id58);


-- Títulos disponibles
CALL altaTitulos(1, "Orgullo y prejuicio", '1813');
CALL altaAutores(@idJaneAusten, "Jane", "Austen");
CALL altaTitulosAutores(1, @idJaneAusten);
CALL altaTitulos(2, "Proyecto Hail Mary", 2021);
CALL altaAutores(@idAndyWeir, "Andy", "Weir");
CALL altaTitulosAutores(2, @idAndyWeir);

-- Editoriales 
CALL altaEditoriales(1, "Austral");
CALL altaEditoriales(2, "Planeta");
CALL altaEditoriales(3, "Penguin");

-- Acá doy de alta 4 ejemplares de diferentes editoriales:

-- Orgullo y prejuicio
CALL altaEjemplares(9788418037058, 1, 1, 1, 0);
CALL altaEjemplares(4588428077058, 2, 1, 1, 0);
CALL altaEjemplares(6588321077050, 3, 1, 1, 0);
-- Proyecto Hail Mary
CALL altaEjemplares(9788418037016, 2, 50, 2, 0);

-- Fuera de circulación
CALL altaFueraCirculaciones(NOW(), 1, 9788418037058);
CALL altaFueraCirculaciones(now(),20, 9788418037016);
CALL altaFueraCirculaciones(now(), 10, 9788418037016 );
CALL altaFueraCirculaciones(now(), 15,9788418037016 );
CALL altaFueraCirculaciones(now(), 16,9788418037016 );
CALL altaFueraCirculaciones(now(), 17,9788418037016 );

-- Prestamos 
INSERT INTO prestamos (`ISBN`, `numCopia`, `DNI`, `fechaSalida`, `fechaRegreso`) VALUES (9788418037016, 1, 46912870, '2023-09-28 10:18:08', NULL);

-- Mostrar el porcentaje de libros que están fuera de circulación 
SELECT PorcentajeFuera(9788418037016);

SELECT 'Falla por trigger' Descripcion;
-- Si se trata de ejecutar el siguiente prestamo, el trigger que verifica si está fuera de circulación mostrará el mensaje de error:
INSERT INTO prestamos (`ISBN`, `numCopia`, `DNI`, `fechaSalida`, `fechaRegreso`) VALUES (9788418037058, 1, 95847780, '2023-09-28 11:10:09', NULL);

-- Si se trata de ejecutar el siguiente prestamo luego del anterior, el trigger que verifica si está prestado mostrará el mensaje de error:
INSERT INTO prestamos (`ISBN`, `numCopia`, `DNI`, `fechaSalida`, `fechaRegreso`) VALUES (9788418037016, 1, 95847780, '2023-09-28 11:07:07', NULL);