--Obtener todas las categorias
CREATE PROCEDURE ObtenerCategorias
AS
BEGIN
    SELECT * FROM Categorias;
END

--
CREATE PROCEDURE InsertarCategoria
(
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100)
)
AS
    INSERT INTO Categorias (Codigo, Descripcion)
    VALUES (@Codigo, @Descripcion);
--
CREATE PROCEDURE ActualizarCategoria
(
    @Id INT,
    @Codigo VARCHAR(3),
    @Descripcion VARCHAR(100)
)
AS
    UPDATE Categorias
    SET Codigo = @Codigo, Descripcion = @Descripcion
    WHERE Id = @Id;
END

--

CREATE PROCEDURE EliminarCategoria
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Categorias
    WHERE Id = @Id;
END

--

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

--

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



