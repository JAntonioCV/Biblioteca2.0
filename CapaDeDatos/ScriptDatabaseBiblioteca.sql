CREATE DATABASE Biblioteca

USE Biblioteca

CREATE TABLE Categorias (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](3) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL 
	CONSTRAINT [PK_Categorias] PRIMARY KEY (Id)
)

CREATE TABLE Libros (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](3) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Autor] [varchar](100) NOT NULL,
	[CategoriaId] [int] NOT NULL
	CONSTRAINT [PK_Libros] PRIMARY KEY (Id)
)

	ALTER TABLE [Libros] ADD CONSTRAINT [FK_Libros_Categorias_CategoriaId] FOREIGN KEY([CategoriaId])
    REFERENCES  [Categorias] ([Id]);

CREATE TABLE Copias (
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [NumeroCopia] [varchar](3) NOT NULL,
    [EsPrestada] [bit] DEFAULT 0,
	[LibroId] [int] NOT NULL,
	CONSTRAINT [PK_Copias] PRIMARY KEY (Id)
)
	ALTER TABLE [Copias] ADD CONSTRAINT [FK_Copias_Libros_LibroId] FOREIGN KEY([LibroId])
    REFERENCES  [Libros] ([Id]);

CREATE TABLE Clientes (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](14) NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	CONSTRAINT [PK_Clientes] PRIMARY KEY (Id)
)

CREATE TABLE Prestamos (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](5) NOT NULL,
	[FechaPrestamo] [datetime] NOT NULL,
	[FechaDevolucion] [datetime] NOT NULL,
	[ClienteId] [int] NOT NULL,
	CONSTRAINT [PK_Prestamos] PRIMARY KEY (Id)
)

	ALTER TABLE [Prestamos] ADD CONSTRAINT [FK_Prestamos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
    REFERENCES  [Clientes] ([Id]);


CREATE TABLE DetallesPrestamo (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrestamoId] [int] NOT NULL,
	[CopiaId] [int] NOT NULL,
	CONSTRAINT [PK_DetallesPrestamo] PRIMARY KEY (Id)
)

	ALTER TABLE [DetallesPrestamo] ADD CONSTRAINT [FK_DetallesPrestamo_Prestamos_PrestamoId] FOREIGN KEY([PrestamoId])
    REFERENCES  [Prestamos] ([Id]);

	ALTER TABLE [DetallesPrestamo] ADD CONSTRAINT [FK_DetallesPrestamo_Copias_CopiaId] FOREIGN KEY([CopiaId])
    REFERENCES  [Copias] ([Id]);



