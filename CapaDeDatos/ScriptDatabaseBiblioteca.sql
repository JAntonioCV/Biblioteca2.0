CREATE DATABASE Biblioteca

USE Biblioteca

CREATE TABLE Categorias (
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](3) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL 
	CONSTRAINT [PK_Categorias] PRIMARY KEY (Id)
)