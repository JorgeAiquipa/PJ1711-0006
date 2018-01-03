IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr31_set_002]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr31_set_002;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2018.1.3
-- Descripcion : Procedimiento para actualizar el numero de personas 
--               del servicio mano de obra.
-- =============================================
CREATE PROCEDURE pa_tr31_set_002

	@p_TR31_ID INT,
	@p_TR31_CANT_PERSONAS smallint,
	@P_TR31_UACTUALIZA varchar(20),
	@p_TM2_ID VARCHAR(10)

AS

BEGIN TRY
	
	SET NOCOUNT ON;

	UPDATE DBO.T_R31
	SET TR31_CANT_PERSONAS = @p_TR31_CANT_PERSONAS,
	TR31_UACTUALIZA = @P_TR31_UACTUALIZA,
	TR31_FACTUALIZA = GETDATE()

	WHERE

		TR31_TM2_ID = @p_TM2_ID
		AND
		TR31_ID = @p_TR31_ID
	
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

EXEC pa_tr31_sel_001  147, 3892, 205, 'PIS'

EXEC pa_tr31_set_002  237, 8, 'DGOMEZ', 'PIS'

SELECT * FROM T_R31

SELECT * FROM T_R27 --Cotizacion Local
SELECT * FROM T_R28 --Cotizacion Servicio 
SELECT * FROM T_R29 --Servicio Cargo