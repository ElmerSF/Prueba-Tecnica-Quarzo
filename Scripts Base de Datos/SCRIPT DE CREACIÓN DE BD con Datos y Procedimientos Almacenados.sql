USE [master]
GO
/****** Object:  Database [BDCrudTest]    Script Date: 27/9/2021 7:41:56:p. m. ******/
CREATE DATABASE [BDCrudTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDCrudTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ELMERSERVER\MSSQL\DATA\BDCrudTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDCrudTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ELMERSERVER\MSSQL\DATA\BDCrudTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BDCrudTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDCrudTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDCrudTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDCrudTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDCrudTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDCrudTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDCrudTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDCrudTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDCrudTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDCrudTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDCrudTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDCrudTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDCrudTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDCrudTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDCrudTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDCrudTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDCrudTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDCrudTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDCrudTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDCrudTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDCrudTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDCrudTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDCrudTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDCrudTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDCrudTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDCrudTest] SET  MULTI_USER 
GO
ALTER DATABASE [BDCrudTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDCrudTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDCrudTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDCrudTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDCrudTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDCrudTest] SET QUERY_STORE = OFF
GO
USE [BDCrudTest]
GO
/****** Object:  User [ElmerUNED]    Script Date: 27/9/2021 7:41:56:p. m. ******/
CREATE USER [ElmerUNED] FOR LOGIN [ElmerUNED] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[coCategoria]    Script Date: 27/9/2021 7:41:56:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coCategoria](
	[nIdCategori] [int] NOT NULL,
	[cNombCateg] [varchar](50) NOT NULL,
	[cEsActiva] [bit] NOT NULL,
 CONSTRAINT [PK_coCategoria] PRIMARY KEY CLUSTERED 
(
	[nIdCategori] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[coProducto]    Script Date: 27/9/2021 7:41:56:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[coProducto](
	[nIdProduct] [int] IDENTITY(1,1) NOT NULL,
	[cNombProdu] [varchar](50) NOT NULL,
	[nPrecioProd] [int] NOT NULL,
	[nIdCategori] [int] NOT NULL,
 CONSTRAINT [PK_coProducto] PRIMARY KEY CLUSTERED 
(
	[nIdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (1, N'Abarrotes', 1)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (2, N'Hogar', 1)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (3, N'Automovil', 0)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (4, N'Ferreteria', 1)
GO
INSERT [dbo].[coCategoria] ([nIdCategori], [cNombCateg], [cEsActiva]) VALUES (5, N'Bebes', 1)
GO
SET IDENTITY_INSERT [dbo].[coProducto] ON 
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (2, N'Arroz', 1250, 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (3, N'Frijoles', 900, 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (4, N'Sal', 700, 1)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (5, N'Bombillo 75w', 550, 4)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (6, N'Manguera Fregadero', 7500, 4)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (7, N'Plato Grande', 1300, 2)
GO
INSERT [dbo].[coProducto] ([nIdProduct], [cNombProdu], [nPrecioProd], [nIdCategori]) VALUES (8, N'Limpion pequeño', 1000, 2)
GO
SET IDENTITY_INSERT [dbo].[coProducto] OFF
GO
ALTER TABLE [dbo].[coProducto]  WITH CHECK ADD  CONSTRAINT [FK_coProducto_coCategoria] FOREIGN KEY([nIdCategori])
REFERENCES [dbo].[coCategoria] ([nIdCategori])
GO
ALTER TABLE [dbo].[coProducto] CHECK CONSTRAINT [FK_coProducto_coCategoria]
GO
/****** Object:  StoredProcedure [dbo].[Usp_Ins_Co_Categoria]    Script Date: 27/9/2021 7:41:56:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Elmer Salazar
-- Create date: 27 de septiembre
-- Description:	Agrega, actualiza o borra una categoria
-- =============================================
CREATE PROCEDURE [dbo].[Usp_Ins_Co_Categoria]
	-- Estos son los parametros que recibe el procedimiento
	@nIdCategori int, --codigo de la categoria
	@cNombCateg varchar(50) , --nombre
	@cEsActiva bit, --estatus activo o no
	@borrar bit --es un borrado
AS
BEGIN
	-- Revisa a ver si existe el codigo indicado
	if exists (select nIdCategori from coCategoria where nIdCategori = @nIdCategori )
	--si existe comprueba
	begin	
		if (@borrar = 0) --se trata de una actualizacion
			begin
				update coCategoria set 
				 nIdCategori = @nIdCategori, 
				cNombCateg = @cNombCateg, 
				cEsActiva = @cEsActiva
				where nIdCategori = @nIdCategori;
				select * from coCategoria where nIdCategori = @nIdCategori;
				return
			end
				begin
					 -- se trata de borrar un registro
					delete coCategoria where nIdCategori = @nIdCategori;
					print ('Registro eliminado');
					return --termina el procedimiento
				end
		end

	begin --el valor indicado no existe
		insert into coCategoria values --se registra la nueva categoria
			(@nIdCategori, @cNombCateg, @cEsActiva)
			select * from coCategoria where nIdCategori = @nIdCategori;
	end
END

GO
/****** Object:  StoredProcedure [dbo].[Usp_Sel_Co_Produtos]    Script Date: 27/9/2021 7:41:56:p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Elmer Salazar
-- Create date: 27 de septiembre de 2021
-- Description:	devuelve los detalles de los productos de una categoría indicada
-- =============================================
CREATE PROCEDURE [dbo].[Usp_Sel_Co_Produtos] 
	-- Recibi el Id de Categoría del producto
	@Id_Categoria int
AS
BEGIN
--realiza la selección de los elementos de la tabla con unos títulos más representativos
	select 
nIdProduct as 'Codigo de Producto',
cNombProdu as 'Nombre del Producto',
nPrecioProd as 'Precio',
cNombCateg as 'Categoria de Producto'

from coProducto

--se realiza la unión de la tabla Categoría y Producto
inner join coCategoria
on coProducto.nIdCategori
= coCategoria.nIdCategori

--se indica el parámetro de la selección 
where coCategoria.nIdCategori = @Id_Categoria;
END
GO
USE [master]
GO
ALTER DATABASE [BDCrudTest] SET  READ_WRITE 
GO
