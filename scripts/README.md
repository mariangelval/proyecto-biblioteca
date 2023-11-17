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