
--CATEGORIAS

CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
    SELECT * FROM Categorias
END

GO

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

GO

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

GO

CREATE PROCEDURE EliminarCategoria
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Categorias
    WHERE Id = @Id;
END

GO

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
END

GO

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
END

GO

CREATE PROCEDURE CategoriaConLibros
(
    @CategoriaId INT
)
AS
BEGIN
    SELECT COUNT(*) 
    FROM Libros 
    WHERE CategoriaId = @CategoriaId;
END

GO

--Libros

CREATE PROCEDURE ObtenerLibros
AS
BEGIN
    SELECT L.*, C.Descripcion AS Categoria
    FROM Libros L
    INNER JOIN Categorias C ON L.CategoriaId = C.Id
END

GO

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

GO

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

GO

CREATE PROCEDURE EliminarLibro
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Libros
    WHERE Id = @Id;
END

GO

--Copias

CREATE PROCEDURE ObtenerCopias
AS
BEGIN
    SELECT L.Titulo, C.NumeroCopia
    FROM Copias C
    INNER JOIN Libros L ON C.LibroId = L.Id;
END

GO

CREATE PROCEDURE InsertarCopia
@NumeroCopia INT,
@EsPrestada BIT,
@LibroId INT
AS
BEGIN
    INSERT INTO Copias (NumeroCopia, EsPrestada, LibroId)
    VALUES (@NumeroCopia, @EsPrestada, @LibroId)
END

GO

CREATE PROCEDURE ActualizarCopia
@Id INT,
@NumeroCopia INT,
@EsPrestada BIT,
@LibroId INT
AS
BEGIN
    UPDATE Copias
    SET NumeroCopia = @NumeroCopia, EsPrestada = @EsPrestada, LibroId = @LibroId
    WHERE Id = @id
END

GO

CREATE PROCEDURE EliminarCopia
@Id int
AS
BEGIN
    DELETE FROM Copias
    WHERE Id = @Id
END

GO

--CLIENTE

CREATE PROCEDURE ObtenerClientes
AS
BEGIN
    SELECT * FROM Clientes
END

GO

CREATE PROCEDURE InsertarCliente
    @Cedula VARCHAR(14),
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(100)
AS
BEGIN
    INSERT INTO Clientes (Cedula, Nombres, Apellidos)
    VALUES (@Cedula, @Nombres, @Apellidos)
END

GO

CREATE PROCEDURE ActualizarCliente
    @Id INT,
    @Cedula VARCHAR(14),
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(100)
AS
BEGIN
    UPDATE Clientes
    SET Cedula = @Cedula,
        Nombres = @Nombres,
        Apellidos = @Apellidos
    WHERE Id = @Id
END

GO

CREATE PROCEDURE EliminarCliente
    @Id INT
AS
BEGIN
    DELETE FROM Clientes
    WHERE Id = @Id
END

GO

--Prestamo

CREATE PROCEDURE ObtenerPrestamos
AS
BEGIN
    SELECT p.*, c.Nombres + ' ' + c.Apellidos AS Cliente
    FROM Prestamos p
    INNER JOIN Clientes c ON p.ClienteId = c.Id;
END

GO

CREATE PROCEDURE ObtenerPrestamosFiltrados
    @Codigo VARCHAR(3) = NULL,
	@ClienteId INT = NULL
AS
BEGIN

	SELECT p.*, c.Nombres + ' ' + c.Apellidos AS Cliente
	FROM Prestamos p
	INNER JOIN Clientes c ON p.ClienteId = c.Id
	WHERE (@ClienteId IS NULL OR P.ClienteId = @ClienteId)
	AND (@Codigo IS NULL OR P.Codigo = @Codigo)
END
GO




