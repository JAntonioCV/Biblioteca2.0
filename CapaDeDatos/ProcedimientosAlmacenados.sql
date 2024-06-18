
--CATEGORIAS

CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
    SELECT * FROM Categorias
END

CREATE PROCEDURE InsertarCategoria
(
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100)
)
AS
BEGIN
    INSERT INTO Categorias (Codigo, Descripcion)
    VALUES (@Codigo, @Descripcion)
END

CREATE PROCEDURE ActualizarCategoria
(
    @Id INT,
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100)
)
AS
BEGIN
    UPDATE Categorias
    SET Codigo = @Codigo, Descripcion = @Descripcion
    WHERE Id = @Id;
END

CREATE PROCEDURE EliminarCategoria
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Categorias
    WHERE Id = @Id;
END

CREATE PROCEDURE ExisteCategoria
(
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100)
)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Categorias 
    WHERE Codigo = @Codigo AND Descripcion = @Descripcion;
END;

CREATE PROCEDURE ExisteOtraCategoria
(
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100),
    @Id INT
)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Categorias 
    WHERE Codigo = @Codigo AND Descripcion = @Descripcion AND Id != @Id;
END;

CREATE PROCEDURE CategoriaConLibros
(
    @CategoriaId INT
)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Libros 
    WHERE CategoriaId = @CategoriaId;
END;

--Libros

CREATE PROCEDURE ObtenerLibros
AS
BEGIN
    SELECT L.*, C.Descripcion AS Categoria
    FROM Libros L
    INNER JOIN Categorias C ON L.CategoriaId = C.Id
END

CREATE PROCEDURE InsertarLibro
    @Codigo VARCHAR(3),
    @Titulo VARCHAR(100),
    @ISBN VARCHAR(13),
    @Autor VARCHAR(100),
    @CategoriaId INT
AS
BEGIN
    INSERT INTO Libros (Codigo, Titulo, ISBN, Autor, CategoriaId)
    VALUES (@Codigo, @Titulo, @ISBN, @Autor, @CategoriaId);
END

CREATE PROCEDURE ActualizarLibro
    @Id INT,
    @Codigo VARCHAR(3),
    @Titulo VARCHAR(100),
    @ISBN VARCHAR(13),
    @Autor VARCHAR(100),
    @CategoriaId INT
AS
BEGIN
    UPDATE Libros
    SET Codigo = @Codigo,
        Titulo = @Titulo,
        ISBN = @ISBN,
        Autor = @Autor,
        CategoriaId = @CategoriaId
    WHERE Id = @Id;
END

CREATE PROCEDURE EliminarLibro
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Libros
    WHERE Id = @Id;
END


--Copias

CREATE PROCEDURE ObtenerCopias
AS
BEGIN
    SELECT L.Titulo, C.NumeroCopia
    FROM Copias C
    INNER JOIN Libros L ON C.LibroId = L.Id;
END

CREATE PROCEDURE InsertarCopia
@NumeroCopia INT,
@EsPrestada BIT,
@LibroId INT
AS
BEGIN
    INSERT INTO Copias (NumeroCopia, EsPrestada, LibroId)
    VALUES (@NumeroCopia, @EsPrestada, @LibroId)
END

CREATE PROCEDURE ActualizarCopia
@Id INT,
@NumeroCopia INT,
@EsPrestada BIT,
@LibroId INT
AS
BEGIN
    UPDATE Copias
    SET NumeroCopia = @numeroCopia, Prestada = @prestada, LibroId = @libroId
    WHERE Id = @id
END

CREATE PROCEDURE EliminarCopia
@Id int
AS
BEGIN
    DELETE FROM Copias
    WHERE Id = @Id
END






--CLIENTE

CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
    SELECT * FROM Categorias;
END



