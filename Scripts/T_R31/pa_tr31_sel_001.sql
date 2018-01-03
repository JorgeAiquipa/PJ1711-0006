IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr31_sel001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr31_sel001;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2018.1.3
-- Table : T_R31 -> Mano de obra
-- Descripcion : Listamos los datos de mano de obra
-- =============================================
CREATE PROCEDURE pa_tr31_sel001
	--@p_TR31_ID INT,

	@p_TR31_TR29_ID INT,
	@p_TR31_TR27_ID INT,
	@p_TR31_TR28_ID INT,

	@p_TM2_ID VARCHAR(10)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 

			 TR31_ID
			,TR31_TR29_ID
			,TR31_TR27_ID
			,TR31_TR28_ID
			,TR31_CANT_PERSONAS
			,TR31_DESCRIP
			,TR31_TM2_ID
			,TR31_ST
			,TR31_FLG_ELIMINADO
			,TR31_UCREA
			,TR31_FCREA
			,TR31_UACTUALIZA
			,TR31_FACTUALIZA
		FROM

			DBO.T_R31

		WHERE
			TR31_FLG_ELIMINADO = 0
			AND
			TR31_TM2_ID = @p_TM2_ID
			AND
			TR31_TR29_ID = @p_TR31_TR29_ID
			AND
			TR31_TR28_ID = @p_TR31_TR28_ID
			AND
			TR31_TR27_ID = @p_TR31_TR27_ID


END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

EXEC pa_tr31_sel001  147, 3892, 205, 'PIS'

SELECT * FROM T_R31

SELECT * FROM T_R27 --Cotizacion Local
SELECT * FROM T_R28 --Cotizacion Servicio 
SELECT * FROM T_R29 --Servicio Cargo