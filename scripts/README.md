### DER 
```mermaid
erDiagram
    Titulos{
        SMALLINTUNSIGNED id_titulo PK
        VARCHAR(45) nombre UK
        SMALLINTUNSIGNED anio_primero
    }

    Titulos_Autores{
        SMALLINTUNSIGNED id_titulo FK,PK
        SMALLINTUNSIGNED id_autor FK,PK
    }
    Autores{
        SMALLINTUNSIGNED  id_autor PK
        VARCHAR(45) nombre
        VARCHAR(45) apellido
    }
    Editoriales{
        SMALLINTUNSIGNED id_editorial PK
        VARCHAR(45) Editorial UK
    }
    Ejemplares{
        BIGINTUNSIGNED ISBN PK
        SMALLINTUNSIGNED id_editorial FK
        TINYUNSIGNED cant_copias
        SMALLINTUNSIGNED cant_prestamos
        SMALLINTUNSIGNED id_titulo FK
    }
    Cursos{
        TINYUNSIGNED id_curso PK
        TINYUNSIGNED anio UK
        TINYUNSIGNED division UK
    }
    Alumnos{
        INTUNSIGNED DNI PK
        VARCHAR(45) nombre
        VARCHAR(45) apellido
        BIGINTUNSIGNED celular
        VARCHAR(45) email
        CHAR(64) contrasenia
        TINYUNSIGNED id_curso FK
    }
    Prestamos{
        BIGINTUNSIGNED ISBN  FK,PK
        TINYUNSIGNED num_copia PK
        INTUNSIGNED DNI FK
        DATETIME fecha_salida PK
        DATETIME fecha_regreso
    }
    Fuera_Circulaciones{
        DATETIME fecha_salida
        TINYUNSIGNED num_copia PK
        BIGINTUNSIGNED ISBN FK,PK
    }
    Titulos }|--|| Titulos_Autores : ""
    Autores }|--|| Titulos_Autores : ""
    Titulos }|--|| Ejemplares : ""
    Editoriales }|--|| Ejemplares : ""
    Ejemplares }|--|| Fuera_Circulaciones : ""
    Cursos }|--|| Alumnos : ""
    Ejemplares }|--|| Prestamos : ""
    Alumnos }|--|| Prestamos : ""
```

### Como correr DB

1. Venir a este directorio (`/scripts`) y ejecutar el comando `mysql -u user -p` donde `user` es el usuario.
1. Ingresar la pass
1. Ejecutar desde la shell de MySQL el comando `SOURCE install.sql`

### Diagrama de clases
```mermaid
classDiagram
    Titulos  o-- "1..*"Autores
    Ejemplares o-- Titulos
    Ejemplares *-- "0..*" FueraCirculaciones
    Alumnos "1" --o Prestamos
    Ejemplares "1" --o Prestamos
    Editoriales "1" --o Ejemplares
    Alumnos o-- "1" Cursos
    class Titulos{
        + ushort idTitulo;
        + string nombre;
        + ushort anioPrimero;
    }
    class Autores{
        + ushort idAutor;
        + string nombre;
        + string apellido;
    }
    class Ejemplares{
        + ulong isbn;
        + ushort idEditorial;
        + ubyte cantCopias;
        + ushort cantPrestamos;
        + ushort idTitulo;
    }
    class Editoriales{
        + ushort idEditorial;
        + string editorial;
    }
    class Cursos{
        + ubyte idCurso;
        + ubyte anio; 
        + ubyte division;
    }
    class Alumnos{
        + uint dni;
        + string nombre;
        + string apellido;
        + ulong celular;
        + string email;
        + ubyte idCurso;
    }
    class Prestamos{
        + ulong isbn;
        + ubyte numCopia;
        + uint dni;
        + datetime fechaSalida;
        + datetime fechaRegreso;
    }
    class FueraCirculaciones{
        + datetime fechaSalida;
        + ubyte numCopia;
        + ulong isbn;
    }
```