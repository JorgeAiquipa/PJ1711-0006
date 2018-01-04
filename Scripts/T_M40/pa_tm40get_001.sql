IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm40get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm40get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.20
-- Descripcion :Obtiene lista de conceptos remunerativos
-- =============================================
CREATE PROCEDURE pa_tm40get_001
AS

BEGIN TRY
	
	SET NOCOUNT ON;


	SELECT
		 TM40_ID
		,TM40_DESCRIP
		,TM40_DESCRIP2
		--,TM40_ST
		--,TM40_UCREA
		--,TM40_FCREA
		--,TM40_UACTUALIZA
		--,TM40_FACTUALIZA
		,TM40_IMPORTE
		,TM40_PORCENTAJE
	FROM 
		T_M40
	WHERE
		TM40_ST = 1
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	--SET @p_mensaje_respuesta = ERROR_MESSAGE()
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
