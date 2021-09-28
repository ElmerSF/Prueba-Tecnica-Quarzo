-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Elmer Salazar
-- Create date: 27 de septiembre de 2021
-- Description:	devuelve los detalles de los productos de una categor�a indicada
-- =============================================
CREATE PROCEDURE Usp_Sel_Co_Produtos 
	-- Recibi el Id de Categor�a del producto
	@Id_Categoria int
AS
BEGIN
--realiza la selecci�n de los elementos de la tabla con unos t�tulos m�s representativos
	select 
nIdProduct as 'Codigo de Producto',
cNombProdu as 'Nombre del Producto',
nPrecioProd as 'Precio',
cNombCateg as 'Categoria de Producto'

from coProducto

--se realiza la uni�n de la tabla Categor�a y Producto
inner join coCategoria
on coProducto.nIdCategori
= coCategoria.nIdCategori

--se indica el par�metro de la selecci�n 
where coCategoria.nIdCategori = @Id_Categoria;
END
GO
