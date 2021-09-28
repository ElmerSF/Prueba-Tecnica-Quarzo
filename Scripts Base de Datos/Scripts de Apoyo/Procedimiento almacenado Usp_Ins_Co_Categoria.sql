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
-- Create date: 27 de septiembre
-- Description:	Agrega, actualiza o borra una categoria
-- =============================================
Alter PROCEDURE Usp_Ins_Co_Categoria
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
