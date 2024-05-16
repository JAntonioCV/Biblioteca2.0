CREATE DATABASE Biblioteca

USE Biblioteca

CREATE TABLE Categorias (
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](3) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL 
	CONSTRAINT [PK_Categorias] PRIMARY KEY (Id)
)

CREATE TABLE Libros (
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](3) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Autor] [varchar](100) NOT NULL,
	[CategoriaId] [INT] NOT NULL
	CONSTRAINT [PK_Libros] PRIMARY KEY (Id)
)

	ALTER TABLE [Libros] ADD CONSTRAINT [FK_Libros_Categorias_CategoriaId] FOREIGN KEY([CategoriaId])
    REFERENCES  [Categorias] ([Id]);